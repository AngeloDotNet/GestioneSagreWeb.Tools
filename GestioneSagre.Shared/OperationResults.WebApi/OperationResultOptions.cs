using Microsoft.AspNetCore.Http;

namespace GestioneSagre.Shared.OperationResults.WebApi;

public class OperationResultOptions
{
    public ErrorResponseFormat ErrorResponseFormat { get; set; }
    public Dictionary<int, int> StatusCodesMapping { get; }
    public bool UseHttpStatusCodes { get; set; }

    public OperationResultOptions()
    {
        StatusCodesMapping = new Dictionary<int, int>
        {
            [FailureReasons.None] = StatusCodes.Status200OK,
            [FailureReasons.BadRequest] = StatusCodes.Status400BadRequest,
            [FailureReasons.Forbidden] = StatusCodes.Status403Forbidden,
            [FailureReasons.NotFound] = StatusCodes.Status404NotFound,
            [FailureReasons.Conflict] = StatusCodes.Status409Conflict,
            [FailureReasons.Unauthorized] = StatusCodes.Status401Unauthorized,
            [FailureReasons.GenericError] = StatusCodes.Status500InternalServerError
        };
    }

    internal int GetStatusCode(int failureReason, int? defaultStatusCode = null)
    {
        if (!StatusCodesMapping.TryGetValue(failureReason, out var statusCode))
        {
            statusCode = defaultStatusCode.GetValueOrDefault(StatusCodes.Status501NotImplemented);
        }

        return statusCode;
    }
}