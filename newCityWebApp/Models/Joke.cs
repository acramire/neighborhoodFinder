using System;
using System.ComponentModel.DataAnnotations;

namespace newCityWebApp.Models;

public class Joke
{
	public int Id { get; set; }

	public string JokeQuestion  { get; set; }

	
	public string JokeAnswer { get; set; }

	public Joke()
	{

	}
}

