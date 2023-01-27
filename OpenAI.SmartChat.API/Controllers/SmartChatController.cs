using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OpenAI.SmartChat.API.DTO;
using OpenAI.SmartChat.API.Services;
using OpenAI.SmartChat.API.Utils;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace OpenAI.SmartChat.API.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/smart-chat")]
public partial class SmartChatController : MainController
{
    private readonly ISmartChatService _SmartChatService;
    private readonly IMapper _mapper;

    public SmartChatController(ISmartChatService SmartChatService, IMapper mapper)
    {
        _SmartChatService = SmartChatService;
        _mapper = mapper;
    }

    /// <summary>
    /// Write a sentence about something or ask a question
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [Consumes(MediaTypeNames.Application.Json)]
    [SwaggerResponse(StatusCodes.Status200OK, "", typeof(string))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "", typeof(string))]
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
    /// <param name="texts"></param>
    /// <returns></returns>
    [Consumes(MediaTypeNames.Application.Json)]
    [SwaggerResponse(StatusCodes.Status200OK, "", typeof(string))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "", typeof(string))]
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

    /// <summary>
    /// Search images on the internet via ChatGPT
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="typeFormat"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    [Consumes(MediaTypeNames.Application.Json)]
    [SwaggerResponse(StatusCodes.Status200OK, "", typeof(List<ImageResultDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "", typeof(string))]
    [HttpGet("search-images/{limit}/{typeFormat}")]
    public async Task<ActionResult> SearchImages([FromQuery] string text, short limit = 2, ResponseFormat typeFormat = ResponseFormat.Url)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
        {
            AddProcessingError("Text is required: enter some text to fetch images.");
            return CustomResponse();
        }

        try
        {
            var response = await _SmartChatService.SearchImages(text, limit, SetTypeFormat(typeFormat));

            if (response is null || !response.Any())
            {
                AddProcessingError("Request returned no results");
                return CustomResponse();
            }

            return CustomResponse(_mapper.Map<ImageResultDto>(response));
        }
        catch (Exception ex)
        {
            AddProcessingError(ex.Message);
            return CustomResponse();
        }
    }
}