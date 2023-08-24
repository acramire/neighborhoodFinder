using System;
using Microsoft.AspNetCore.Identity;

namespace newCityWebApp.Models;

public class ApplicationUser: IdentityUser
{
    public int NumberOfSubmissions { get; set; } = 0;
    public ICollection<Submission> Submissions { get; set; }

    public ApplicationUser()
	{
	}
}

