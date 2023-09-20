using System.Net;

namespace GestioneSagre.ProblemDetails;

public class ResultConfirm
{
    public HttpStatusCode StatusCode { get; }
    public bool Success { get; set; }
    public object Message { get; set; }

    public ResultConfirm()
    {
        StatusCode = HttpStatusCode.OK;
        Success = true;
    }

    public ResultConfirm(object message)
    {
        StatusCode = HttpStatusCode.OK;
        Success = true;
        Message = message;
    }

    public ResultConfirm(HttpStatusCode statusCode, bool success)
    {
        StatusCode = statusCode;
        Success = success;
    }

    public ResultConfirm(HttpStatusCode statusCode, bool success, object message)
    {
        StatusCode = statusCode;
        Success = success;
        Message = message;
    }
}