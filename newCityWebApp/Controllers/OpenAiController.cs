using System;
using Microsoft.AspNetCore.Mvc;

namespace newCityWebApp.Controllers;

/*	Decided NOT TO USE but kept as example, practice, etc. 
 *	
 *	(old)Decision to use Web API 
 *	 - Decided to use to practice WebAPI but could have kept this functionality 
 *     within a traditional MVC controller.
 *   - The Web API approach allows for greater reusability and can be consumed 
 *     by different types of clients such as web browsers, mobile apps, or other servers.
 *   - It offers a more flexible architecture, making it easier to modify or extend 
 *     the backend or frontend independently.
 *   - The controller is stateless, adhering to RESTful principles, making it easier 
 *     to scale and maintain.
 */
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

