namespace GestioneSagre.ProblemDetails.Common;

public class CustomProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public int? TypeCode { get; set; }
}