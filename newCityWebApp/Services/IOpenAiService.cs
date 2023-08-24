using System;
namespace newCityWebApp;

public interface IOpenAiService
{
	Task<string> getResult(string text);
}

