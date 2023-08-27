using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using newCityWebApp.Models;
using newCityWebApp.ViewModels;

namespace newCityWebApp.Controllers;

// HomeController class inherits from Controller base class
// This controller manages the Home views and related actions
public class HomeController : Controller
{
    
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;


    // Constructor w/ Dependency injection for  Ilogger and UserManager 
    public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;

    }

    // Index action method
    // Checks if the user is authenticated, populates ViewData w/ # of submissions
    public async Task<IActionResult> Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(User);
            ViewData["NumberOfSubmissions"] = user.NumberOfSubmissions;
        }

        // Initialize view model for submission
        SubmissionViewModel viewModel = new SubmissionViewModel();

        return View(viewModel);
       
    }


    // Privacy Action Method
    public IActionResult Privacy()
    {
        return View();
    }


    //Default Error Action Method
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

