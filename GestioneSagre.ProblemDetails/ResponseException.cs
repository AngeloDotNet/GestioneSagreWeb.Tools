using System.Net;

namespace GestioneSagre.ProblemDetails;

public class ResponseException : System.Exception
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorCode { get; }
    public string ErrorMessage { get; }
    public object ResponseBody { get; }

    public ResponseException(HttpStatusCode statusCode, string errorCode, string errorMessage)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    public ResponseException(HttpStatusCode statusCode, string errorCode, string errorMessage, object responseBody)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
        ResponseBody = responseBody;
    }
}