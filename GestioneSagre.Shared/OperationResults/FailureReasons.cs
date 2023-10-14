namespace GestioneSagre.Shared.OperationResults;

public static class FailureReasons
{
    public const int None = 0;
    public const int BadRequest = 1;
    public const int Forbidden = 2;
    public const int NotFound = 3;
    public const int Conflict = 4;
    public const int Unauthorized = 5;
    public const int GenericError = 6;
}