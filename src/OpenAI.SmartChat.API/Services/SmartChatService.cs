using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel;
using System.Text;
using static OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel.ImageCreateResponse;

namespace OpenAI.SmartChat.API.Services;

public class SmartChatService : ISmartChatService
{
    public async Task<string> AskQuestion(string text) => await AskQuestions(new[] { text });

    public async Task<string> AskQuestions(string[] texts)
    {
        var completionResult = await InstantiateService()
            .Completions.CreateCompletion(new CompletionCreateRequest()
            {
                PromptAsList = texts?.ToList(),
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

    public async Task<List<ImageDataResult>> SearchImages(string text, short imageResultLimit, string responseFormat)
    {
        var imageResult = await InstantiateService()
            .Image.CreateImage(new ImageCreateRequest
            {
                Prompt = text,
                N = imageResultLimit,
                Size = StaticValues.ImageStatics.Size.Size1024,
                ResponseFormat = responseFormat,
                User = "TestUser"
            });

        return GetResponseMessage(imageResult);
    }

    #region Private Methods

    /// <summary>
    /// Create an instance of the service and add the api token
    /// </summary>
    /// <returns></returns>
    private static OpenAIService InstantiateService() => new(new OpenAiOptions()
    {
        ApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "", // put API key in OPENAI_APIK_EY in properties/launchSettings.json file
        ApiVersion = "v1",
    });

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

    /// <summary>
    /// Transform response obtained into "string"
    /// </summary>
    /// <param name="createResult"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private static List<ImageDataResult> GetResponseMessage(ImageCreateResponse createResult)
    {
        if (createResult.Successful)
            return createResult.Results;
        else
        {
            var error = createResult.Error is null ? "Unknown Error" : $"{createResult.Error.Code}: {createResult.Error.Message}";
            throw new Exception(error);
        }
    }

    #endregion Private Methods
}