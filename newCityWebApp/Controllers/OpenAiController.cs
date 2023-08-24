using System;
using Microsoft.AspNetCore.Mvc;

namespace newCityWebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenAiController : ControllerBase
{
	private readonly ILogger<OpenAiController> _logger;
	private readonly IOpenAiService _openAiService;

	public OpenAiController(ILogger<OpenAiController> logger, IOpenAiService openAiService) 
	{
		_logger = logger;
		_openAiService = openAiService;

	}

	[HttpPost()]
	[Route("CreateConversation")]
	public async Task<IActionResult> CreateConversation(string text)
	{
		var result = await _openAiService.getResult(text);
		return Ok(result);
	}
}

