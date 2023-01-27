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
}
