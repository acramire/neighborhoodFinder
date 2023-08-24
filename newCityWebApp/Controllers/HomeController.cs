using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using newCityWebApp.Models;
using newCityWebApp.ViewModels;

namespace newCityWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;


    public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;

    }

    /*
    public IActionResult Index()
    {
        return View();
    }
    */
    public async Task<IActionResult> Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(User);
            ViewData["NumberOfSubmissions"] = user.NumberOfSubmissions;
        }
        SubmissionViewModel viewModel = new SubmissionViewModel();
        /*{
            AvailableCities = new List<SelectListItem>
            {
                new SelectListItem { Value = "San Diego", Text = "San Diego" },
                new SelectListItem { Value = "New York", Text = "New York" },
                new SelectListItem { Value = "Los Angeles", Text = "Los Angeles" },
                //new SelectListItem { Value = "Seattle", Text = "Seattle" },
            }
        }; */

        return View(viewModel);
       
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

