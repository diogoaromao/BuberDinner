using BuberDinner.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

public class ErrorsController : ApiController
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;

        var (statusCode, message) = exception switch
        {
            IServiceException service => ((int)service.StatusCode, service.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred."),
        };

        return Problem(statusCode: statusCode, title: message);
    }
}