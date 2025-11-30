using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ResultPattern.MiddleWares;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;

    public GlobalExceptionHandler(IProblemDetailsService problemDetailsService)
    {
        _problemDetailsService = problemDetailsService;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var problem = new ProblemDetails
        {
            Title = "An unexpected error occurred.",
            Detail = exception.Message,
            Status = StatusCodes.Status500InternalServerError,
            Type = "https://httpstatuses.com/500"
        };

        httpContext.Response.StatusCode = problem.Status.Value;

        // Automatically formats the response as RFC 9457 JSON
        return await _problemDetailsService.TryWriteAsync(
            new ProblemDetailsContext
            {
                HttpContext = httpContext,
                ProblemDetails = problem,
                Exception = exception
            });
    }
}
