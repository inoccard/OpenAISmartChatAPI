using static OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel.ImageCreateResponse;

namespace OpenAI.SmartChat.API.Services;

public interface ISmartChatService
{
    /// <summary>
    /// Ask a question
    /// </summary>
    /// <param name="texto"></param>
    /// <returns></returns>
    public Task<string> AskQuestion(string texto);

    /// <summary>
    /// Ask one or more questions
    /// </summary>
    /// <param name="textos"></param>
    /// <returns></returns>
    public Task<string> AskQuestions(string[] textos);

    /// <summary>
    /// search images
    /// </summary>
    /// <param name="text"></param>
    /// <param name="imageResultLimit"></param>
    /// <returns></returns>
    public Task<List<ImageDataResult>> SearchImages(string text, short imageResultLimit, string responseFormat);
}