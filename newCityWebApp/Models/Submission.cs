using System;
namespace newCityWebApp.Models;

public class Submission
{

    public int Id { get; set; }
    public string UserId { get; set; } // Foreign Key

    // Navigation Property
    public ApplicationUser User { get; set; }

    // Form Fields
    public string City { get; set; }
    public int NumberOfChildren { get; set; } // TODO does this need to be string or int?
    public int SafetyImportance { get; set; }
    public int SocialImportance { get; set; } //funnes/clubs
    public int DiversityImportance { get; set; }
    public int PublicTransportationImportance { get; set; }
    public int AffordabilityImportance { get; set; }
    public int Age { get; set; }
    


    public Submission()
	{
	}
}

