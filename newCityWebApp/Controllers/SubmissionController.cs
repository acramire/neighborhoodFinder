using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using newCityWebApp.Data;
using newCityWebApp.Models;
using newCityWebApp.ViewModels;

namespace newCityWebApp.Controllers;

public class SubmissionController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOpenAiService _openAiService;

    public SubmissionController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, IOpenAiService openAiService)
    {
        _db = db;
        _userManager = userManager;
        _openAiService = openAiService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        SubmissionViewModel viewModel = new SubmissionViewModel();

        return View(viewModel);

    }

    [HttpPost]
    public async Task<ActionResult> Create(SubmissionViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
           
            var user = await _userManager.GetUserAsync(User);
            
            // Map the ViewModel to the Model
            Submission submission = new Submission
            {
                City = viewModel.SelectedCity,
                NumberOfChildren = viewModel.NumberOfChildren,
                SafetyImportance = viewModel.SafetyImportance,
                SocialImportance = viewModel.SocialImportance,
                DiversityImportance = viewModel.DiversityImportance,
                PublicTransportationImportance = viewModel.DiversityImportance,
                AffordabilityImportance = viewModel.AffordabilityImportance,
                Age = viewModel.Age,
                UserId = user.Id,
                    



            };
            
            

            // Save to the database (e.g., using Entity Framework)
            _db.Submissions.Add(submission);
            _db.SaveChanges();


            

        

            // Increment the number of submissions
            if (user != null)
            {
                // Assuming you have a property called NumberOfSubmissions in ApplicationUser
                user.NumberOfSubmissions++;

                user.Submissions.Add(submission);

                // Update the user
                await _userManager.UpdateAsync(user);
            }



            // Save all changes to the database
            await _db.SaveChangesAsync();

            // Redirect to another action, such as the results page
            return RedirectToAction("Results");
        }



        /*
        

        */


        // Save all changes to the database
        //await _db.SaveChangesAsync();

        return RedirectToAction("Index", "Home", viewModel);
        //return Viwew(viewModel);
    }



    public async Task<IActionResult> Results()
    {
        /*
         * OLD SHOW ALL SUBMISSONS GIVENUSE 
        // Get the current user's ID
        var userId = _userManager.GetUserId(User);

        // Filter submissions by the user's ID
        var submissions = await _db.Submissions
            .Where(s => s.UserId == userId)
            .Include(s => s.User) // Include user details if needed
            .ToListAsync();

        return View(submissions);
        */

        // Get the current user's ID
        var userId = _userManager.GetUserId(User);

        // Retrieve the latest submission for the user
        var latestSubmission = await _db.Submissions
            .Where(s => s.UserId == userId)
            .Include(s => s.User)
            .OrderByDescending(s => s.Id)
            .FirstOrDefaultAsync();

        // Format the details of the submission into a prompt (customize as needed)
        string preprompt = "Give me a list of the top 3 neighborhoods given my following preferences. Do the best you can given the data you have!";

        string prompt = $"{preprompt} City: {latestSubmission.City}, Number of Children: {latestSubmission.NumberOfChildren}, Age(Matters for Clubbing/Social Scene): {latestSubmission.Age}, Importance is on a scale of (1/5), Public Transportation Importance: {latestSubmission.PublicTransportationImportance}, Safety Importance: {latestSubmission.SafetyImportance}, Diversity Importance: {latestSubmission.DiversityImportance}, Social Life Importance: {latestSubmission.SocialImportance}, Affordability Importance: {latestSubmission.AffordabilityImportance}. Dont be concise, explain why each neighborhood does or doesn't fit given my preferences."; // Add other details


        // Call the OpenAI API with the prompt
        string response = await _openAiService.getResult(prompt);

        // Pass both the submission and the API response to the view
        ViewBag.Response = response;
        return View(latestSubmission);
    }


}