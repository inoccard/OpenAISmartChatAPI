using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OpenAI.GPT3.ObjectModels;
using OpenAI.SmartChat.API.Utils;

namespace OpenAI.SmartChat.API.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    protected ICollection<string> Erros = new List<string>();

    protected ActionResult CustomResponse(object? result = null)
    {
        return ValidOperation()
            ? Ok(result)
            : BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages: ", Erros.ToArray() }
            }));
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        var erros = modelState.Values.SelectMany(e => e.Errors);
        foreach (var erro in erros)
            AddProcessingError(erro.ErrorMessage);

        return CustomResponse();
    }

    protected bool ValidOperation() => !Erros.Any();

    /// <summary>
    /// Adicionar erro
    /// </summary>
    /// <param name="erro"></param>
    protected void AddProcessingError(string erro) => Erros.Add(erro);

    /// <summary>
    /// Limpar erros
    /// </summary>
    protected void ClearProcessingError() => Erros.Clear();

    protected string SetTypeFormat(ResponseFormat type)
        => type switch
        {
            ResponseFormat.Url => StaticValues.ImageStatics.ResponseFormat.Url,
            ResponseFormat.Base64 => StaticValues.ImageStatics.ResponseFormat.Base64,
            _ => throw new Exception("Invalid image return type. Choose 1: url or 2: Base64"),
        };
}