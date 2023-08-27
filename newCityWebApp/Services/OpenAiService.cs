using System;
using Microsoft.Extensions.Options;
using newCityWebApp.Configurations;

namespace newCityWebApp.Services;

//OpenAIService - implement interface 
public class OpenAiService : IOpenAiService
{
    //Dependecy Injection for API key
    private readonly OpenAiConfig _openAiConfig;

    //constructor for D.I. 
	public OpenAiService(IOptionsMonitor<OpenAiConfig> optionsMonitor)
	{
        _openAiConfig = optionsMonitor.CurrentValue;
	}

    //Get result method, use OpenAI api, return response
    public async Task<string> getResult(string text)
    {
        //get API 
        var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);

        //new chat & append prompt 
        var chat = api.Chat.CreateConversation();
        chat.AppendSystemMessage(text);

        //get & return response 
        string response = await chat.GetResponseFromChatbotAsync();
       
        return response;
    }
}

