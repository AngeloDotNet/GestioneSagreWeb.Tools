using System.Diagnostics;
using GestioneSagre.ProblemDetails.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestioneSagre.ProblemDetails;

public static class ResultException
{
    public static ObjectResult NotFound(HttpContext httpContext, System.Exception exc)
    {
        var statusCode = StatusCodes.Status404NotFound;
        var problemDetails = new CustomProblemDetails
        {
            Status = statusCode,
            Type = $"https://httpstatuses.com/{statusCode}",
            Instance = httpContext.Request.Path,
            Title = "NotFound"
        };

        problemDetails.Extensions.Add("traceId", Activity.Current?.Id ?? httpContext.TraceIdentifier);
        problemDetails.Extensions.Add("errors", exc.Message);

        var result = new ObjectResult(problemDetails)
        {
            StatusCode = statusCode
        };

        return result;
    }
}