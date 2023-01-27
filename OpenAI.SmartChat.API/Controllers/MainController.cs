using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OpenAI.SmartChat.API.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    protected ICollection<string> Erros = new List<string>();

    protected ActionResult CustomResponse(object? result = null)
    {
        if (ValidOperation())
            return Ok(result);

        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
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
}