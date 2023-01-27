using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using System.Text;

namespace OpenAI.SmartChat.API.Services;

public class SmartChatService : ISmartChatService
{
    public async Task<string> AskQuestion(string texto) => await AskQuestions(textos: new[] { texto });

    public async Task<string> AskQuestions(string[] textos)
    {
        var completionResult = await new OpenAIService(new OpenAiOptions()
        {
            ApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "", // put API key in OPENAI_APIK_EY in properties/launchSettings.json file
            ApiVersion = "v1",
        }).Completions.CreateCompletion(new CompletionCreateRequest()
        {
            PromptAsList = textos?.ToList(),
            Model = Models.TextDavinciV3,
            Temperature = (float?)0.9,
            PresencePenalty = (float?)0.6,
            BestOf = 1,
            MaxTokens = 150,
            TopP = 1,
            FrequencyPenalty = 0
        });

        return GetResponseMessage(completionResult);
    }

    /// <summary>
    /// Transform response obtained into "string"
    /// </summary>
    /// <param name="completionResult"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private static string GetResponseMessage(CompletionCreateResponse completionResult)
    {
        if (completionResult.Successful)
        {
            var messages = new StringBuilder();
            completionResult.Choices?.ForEach(c => messages.AppendLine(c.Text));
            return messages.ToString();
        }
        else
        {
            if (completionResult.Error == null) throw new Exception("Unknown Error");

            return $"{completionResult.Error.Code}: {completionResult.Error.Message}";
        }
    }
}
