using Microsoft.AspNetCore.Mvc;
using OpenAI.SmartChat.API.Services;
using System.Net.Mime;

namespace OpenAI.SmartChat.API.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/smart-chat")]
public class SmartChatController : MainController
{
    private readonly ISmartChatService _SmartChatService;

    public SmartChatController(ISmartChatService SmartChatService)
    {
        _SmartChatService = SmartChatService;
    }

    /// <summary>
    /// Write a sentence about something or ask a question
    /// </summary>
    /// <param name="texto"></param>
    /// <returns></returns>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)]
    [HttpGet("ask-a-question")]
    public async Task<ActionResult> AskQuestion([FromQuery] string text)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
        {
            AddProcessingError("Text is required: Write a sentence about something or ask a question.");
            return CustomResponse();
        }

        var response = await _SmartChatService.AskQuestion(text);

        if (string.IsNullOrEmpty(response) || string.IsNullOrWhiteSpace(response))
        {
            AddProcessingError("Request returned no results");
            return CustomResponse();
        }

        return CustomResponse(response);
    }

    /// <summary>
    /// Write one or more sentences about something or ask questions
    /// </summary>
    /// <param name="textos"></param>
    /// <returns></returns>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)]
    [HttpGet("ask-questions")]
    public async Task<ActionResult<string>> AskQuestions([FromQuery] string[] texts)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (texts is null || !texts.Any())
        {
            AddProcessingError("Text is required: Write at least one sentence about something or ask a question.");
            return CustomResponse();
        }

        var response = await _SmartChatService.AskQuestions(texts);

        if (string.IsNullOrEmpty(response) || string.IsNullOrWhiteSpace(response))
        {
            AddProcessingError("Request returned no results");
            return CustomResponse();
        }

        return CustomResponse(response);
    }
}
