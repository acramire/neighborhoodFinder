using System;
using Microsoft.Extensions.Options;
using newCityWebApp.Configurations;

namespace newCityWebApp.Services;

public class OpenAiService : IOpenAiService
{
    private readonly OpenAiConfig _openAiConfig;

	public OpenAiService(IOptionsMonitor<OpenAiConfig> optionsMonitor)
	{
        _openAiConfig = optionsMonitor.CurrentValue;
	}

    public async Task<string> getResult(string text)
    {
        var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);

        var chat = api.Chat.CreateConversation();

        chat.AppendSystemMessage(text);

        string response = await chat.GetResponseFromChatbotAsync();
        Console.WriteLine(response);

        return response;
    }
}

