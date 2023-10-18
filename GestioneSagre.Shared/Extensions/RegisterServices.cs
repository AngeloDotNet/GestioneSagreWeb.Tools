using GestioneSagre.Shared.OperationResults;
using GestioneSagre.Shared.OperationResults.WebApi;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace GestioneSagre.Shared.Extensions;

public static class RegisterServices
{
    public static IServiceCollection AddDefaultOperationResult(this IServiceCollection services)
    {
        services.AddOperationResult(options =>
        {
            options.ErrorResponseFormat = ErrorResponseFormat.Default;

            options.StatusCodesMapping.Add(CustomFailureReasons.NotModified, StatusCodes.Status304NotModified);
            options.StatusCodesMapping.Add(CustomFailureReasons.NotAcceptable, StatusCodes.Status406NotAcceptable);
            options.StatusCodesMapping.Add(CustomFailureReasons.UnprocessableEntity, StatusCodes.Status422UnprocessableEntity);
            options.StatusCodesMapping.Add(CustomFailureReasons.NotImplemented, StatusCodes.Status501NotImplemented);
        },
        validationErrorDefaultMessage: "Errors occurred");

        return services;
    }

    public static IServiceCollection AddDefaultOperationResultFormatList(this IServiceCollection services)
    {
        services.AddOperationResult(options =>
        {
            options.ErrorResponseFormat = ErrorResponseFormat.List;

            options.StatusCodesMapping.Add(CustomFailureReasons.NotModified, StatusCodes.Status304NotModified);
            options.StatusCodesMapping.Add(CustomFailureReasons.NotAcceptable, StatusCodes.Status406NotAcceptable);
            options.StatusCodesMapping.Add(CustomFailureReasons.UnprocessableEntity, StatusCodes.Status422UnprocessableEntity);
            options.StatusCodesMapping.Add(CustomFailureReasons.NotImplemented, StatusCodes.Status501NotImplemented);
        },
        validationErrorDefaultMessage: "Errors occurred");

        return services;
    }

    public static IServiceCollection AddOperationResultHttpStatusCodes(this IServiceCollection services)
    {
        services.AddOperationResult(options =>
        {
            options.ErrorResponseFormat = ErrorResponseFormat.Default;

            options.StatusCodesMapping.Add(CustomFailureReasons.NotModified, StatusCodes.Status304NotModified);
            options.StatusCodesMapping.Add(CustomFailureReasons.NotAcceptable, StatusCodes.Status406NotAcceptable);
            options.StatusCodesMapping.Add(CustomFailureReasons.UnprocessableEntity, StatusCodes.Status422UnprocessableEntity);
            options.StatusCodesMapping.Add(CustomFailureReasons.NotImplemented, StatusCodes.Status501NotImplemented);

            options.UseHttpStatusCodes = true;
        },
        validationErrorDefaultMessage: "Errors occurred");

        return services;
    }

    public static IServiceCollection AddOperationResultHttpStatusCodesFormatList(this IServiceCollection services)
    {
        services.AddOperationResult(options =>
        {
            options.ErrorResponseFormat = ErrorResponseFormat.List;

            options.StatusCodesMapping.Add(CustomFailureReasons.NotModified, StatusCodes.Status304NotModified);
            options.StatusCodesMapping.Add(CustomFailureReasons.NotAcceptable, StatusCodes.Status406NotAcceptable);
            options.StatusCodesMapping.Add(CustomFailureReasons.UnprocessableEntity, StatusCodes.Status422UnprocessableEntity);
            options.StatusCodesMapping.Add(CustomFailureReasons.NotImplemented, StatusCodes.Status501NotImplemented);

            options.UseHttpStatusCodes = true;
        },
        validationErrorDefaultMessage: "Errors occurred");

        return services;
    }

    // Use this if you need to dinamically change the message, i.e., based on user culture.
    //public static IServiceCollection AddOperationResultValidationError(this IServiceCollection services)
    //{
    //    services.AddOperationResult(options =>
    //    {
    //        options.StatusCodesMapping.Add(CustomFailureReasons.NotModified, StatusCodes.Status304NotModified);
    //        options.StatusCodesMapping.Add(CustomFailureReasons.NotAcceptable, StatusCodes.Status406NotAcceptable);
    //        options.StatusCodesMapping.Add(CustomFailureReasons.UnprocessableEntity, StatusCodes.Status422UnprocessableEntity);
    //        options.StatusCodesMapping.Add(CustomFailureReasons.NotImplemented, StatusCodes.Status501NotImplemented);
    //    },

    //    validationErrorMessageProvider: (state) => Messages.ValidationErrorMessage);

    //    return services;
    //}
}