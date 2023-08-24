using System;
namespace newCityWebApp.ViewModels;

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


public class SubmissionViewModel
{
    // User selection for the city, corresponds to the Submission.City property

    [Required(ErrorMessage = "City is required.")]
    public string SelectedCity { get; set; }

    // Preselected list of cities for the dropdown
    public List<SelectListItem> AvailableCities { get; set; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "San Diego", Text = "San Diego" },
        new SelectListItem { Value = "New York", Text = "New York" },
        new SelectListItem { Value = "Los Angeles", Text = "Los Angeles" },
        new SelectListItem { Value = "Seattle", Text = "Seattle" },
        new SelectListItem { Value = "Test", Text = "Test" },
    };
    //public List<SelectListItem> AvailableCities { get; set; } 

    // Other form fields, corresponding to the properties in the Submission model
    [Required(ErrorMessage = "City is required.")]
    [Display(Name = "Number of Children")]
    public int NumberOfChildren { get; set; }

    public int SafetyImportance { get; set; }
    public int SocialImportance { get; set; }
    public int DiversityImportance { get; set; }
    public int PublicTransportationImportance { get; set; }
    public int AffordabilityImportance { get; set; }
    public int Age { get; set; }


}

