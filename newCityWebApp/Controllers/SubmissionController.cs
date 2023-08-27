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

//Submission Controller -
// submit Button (home view) -> create(SubmissionViewModel..)
//  if valid -> Results Action Method - uses OpenAISerice 
public class SubmissionController : Controller
{

    //Dependency Injection - DB, userManager, and openAiService
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOpenAiService _openAiService;

    //Constructor for D.I.
    public SubmissionController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, IOpenAiService openAiService)
    {
        _db = db;
        _userManager = userManager;
        _openAiService = openAiService;
    }

    //Index Action Controller
    public IActionResult Index()
    {
        return View();
    }

    //Default empty submission view
    public IActionResult Create()
    {
        SubmissionViewModel viewModel = new SubmissionViewModel();

        return View(viewModel);

    }

    //Create Action Controller, submission by user with SubmissionViewModel 
    [HttpPost]
    public async Task<ActionResult> Create(SubmissionViewModel viewModel)
    {

        //if submission is valid, continue; else: return back to home w/ old data
        if (ModelState.IsValid)
        {
            //get user 
            var user = await _userManager.GetUserAsync(User);

            //Map the user submission (viewModel) to a new Submission - for database
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



            //Save to the database 
            _db.Submissions.Add(submission);
            _db.SaveChanges();


            //Increment the number of submissions and save user info
            if (user != null)
            {
                //Adjust user info 
                user.NumberOfSubmissions++;
                user.Submissions.Add(submission);

                //update user info in database
                await _userManager.UpdateAsync(user);
            }



            //Save all changes to the database
            await _db.SaveChangesAsync();

            //Redirect to another action, such as the results page
            return RedirectToAction("Results");
        }

        //else:
        //Submission Incorrect - return to current webpage (home) w/ curr. data 
        return RedirectToAction("Index", "Home", viewModel);
    }


    //Results Controller - uses OpenAiService 
    public async Task<IActionResult> Results()
    {


        //Get the current user's ID
        var userId = _userManager.GetUserId(User);


        //Retrieve the latest submission for the user
        var latestSubmission = await _db.Submissions
            .Where(s => s.UserId == userId)
            .Include(s => s.User)
            .OrderByDescending(s => s.Id)
            .FirstOrDefaultAsync();



        //Formulate Prompt for OpenAI API 
        string preprompt = "Give me a list of the top 3 neighborhoods given my following preferences. Do the best you can given the data you have!";

        string prompt = $"{preprompt} City: {latestSubmission.City}, Number of Children: {latestSubmission.NumberOfChildren}, Age(Matters for Clubbing/Social Scene): {latestSubmission.Age}, Importance is on a scale of (1/5), Public Transportation Importance: {latestSubmission.PublicTransportationImportance}, Safety Importance: {latestSubmission.SafetyImportance}, Diversity Importance: {latestSubmission.DiversityImportance}, Social Life Importance: {latestSubmission.SocialImportance}, Affordability Importance: {latestSubmission.AffordabilityImportance}. Dont be concise, explain why each neighborhood does or doesn't fit given my preferences."; // Add other details


        //Call the OpenAI Service with finalized prompt
        string response = await _openAiService.getResult(prompt);



        //Pass both the submission and the API response to the view
        ViewBag.Response = response;
        return View(latestSubmission);
    }


}