using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestioneSagre.ProblemDetails;

public static class ResultException
{
    public static ObjectResult NotFound(HttpContext httpContext, System.Exception exc)
    {
        var statusCode = StatusCodes.Status404NotFound;
        var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
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

    public static ObjectResult BadRequest(HttpContext httpContext, System.Exception exc)
    {
        var statusCode = StatusCodes.Status400BadRequest;
        var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Status = statusCode,
            Type = $"https://httpstatuses.com/{statusCode}",
            Instance = httpContext.Request.Path,
            Title = "BadRequest"
        };

        problemDetails.Extensions.Add("traceId", Activity.Current?.Id ?? httpContext.TraceIdentifier);
        problemDetails.Extensions.Add("errors", exc.Message);

        var result = new ObjectResult(problemDetails)
        {
            StatusCode = statusCode
        };

        return result;
    }

    public static ObjectResult NotModified(HttpContext httpContext, System.Exception exc)
    {
        var statusCode = StatusCodes.Status304NotModified;
        var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Status = statusCode,
            Type = $"https://httpstatuses.com/{statusCode}",
            Instance = httpContext.Request.Path,
            Title = "NotModified"
        };

        problemDetails.Extensions.Add("traceId", Activity.Current?.Id ?? httpContext.TraceIdentifier);
        problemDetails.Extensions.Add("errors", exc.Message);

        var result = new ObjectResult(problemDetails)
        {
            StatusCode = statusCode
        };

        return result;
    }

    public static ObjectResult NotAcceptable(HttpContext httpContext, System.Exception exc)
    {
        var statusCode = StatusCodes.Status406NotAcceptable;
        var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Status = statusCode,
            Type = $"https://httpstatuses.com/{statusCode}",
            Instance = httpContext.Request.Path,
            Title = "NotAcceptable"
        };

        problemDetails.Extensions.Add("traceId", Activity.Current?.Id ?? httpContext.TraceIdentifier);
        problemDetails.Extensions.Add("errors", exc.Message);

        var result = new ObjectResult(problemDetails)
        {
            StatusCode = statusCode
        };

        return result;
    }

    public static ObjectResult Conflict(HttpContext httpContext, System.Exception exc)
    {
        var statusCode = StatusCodes.Status409Conflict;
        var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Status = statusCode,
            Type = $"https://httpstatuses.com/{statusCode}",
            Instance = httpContext.Request.Path,
            Title = "Conflict"
        };

        problemDetails.Extensions.Add("traceId", Activity.Current?.Id ?? httpContext.TraceIdentifier);
        problemDetails.Extensions.Add("errors", exc.Message);

        var result = new ObjectResult(problemDetails)
        {
            StatusCode = statusCode
        };

        return result;
    }

    public static ObjectResult UnprocessableEntity(HttpContext httpContext, System.Exception exc)
    {
        var statusCode = StatusCodes.Status422UnprocessableEntity;
        var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Status = statusCode,
            Type = $"https://httpstatuses.com/{statusCode}",
            Instance = httpContext.Request.Path,
            Title = "UnprocessableEntity"
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