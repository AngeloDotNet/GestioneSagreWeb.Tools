﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestioneSagre.Shared.OperationResults.WebApi;

public static class HttpContextExtensions
{
    public static IActionResult CreateResponse(this HttpContext httpContext, Result result, int? successStatusCode = null)
        => result.ToResponse(httpContext, successStatusCode);

    public static IActionResult CreateResponse(this HttpContext httpContext, Result result, string routeName, object routeValues = null, int? successStatusCode = null)
        => result.ToResponse(httpContext, routeName, routeValues, successStatusCode);

    public static IActionResult CreateResponse<T>(this HttpContext httpContext, Result<T> result, int? successStatusCode = null)
        => result.ToResponse(httpContext, null, null, successStatusCode);

    public static IActionResult CreateResponse<T>(this HttpContext httpContext, Result<T> result, string routeName, object routeValues = null, int? successStatusCode = null)
        => result.ToResponse(httpContext, routeName, routeValues, successStatusCode);
}