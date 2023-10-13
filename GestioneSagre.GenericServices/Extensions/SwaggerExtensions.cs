using GestioneSagre.GenericServices.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace GestioneSagre.GenericServices.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerGenConfig(this IServiceCollection services, string title,
        string version, string description = "", bool extendSchema = false, string xmlCommentsPath = "")
    {
        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(options =>
            {
                options.OperationFilter<CultureAwareOperationFilter>();
                options.SwaggerDoc($"{version}", new OpenApiInfo
                {
                    Title = $"{title}",
                    Version = $"{version}",
                    Description = $"{description}",
                });

                if (extendSchema)
                    options.UseAllOfToExtendReferenceSchemas();

                if (xmlCommentsPath is not (null or ""))
                    options.IncludeXmlComments(xmlCommentsPath);
            });

        return services;
    }

    public static IServiceCollection AddSwaggerDateTimeGenConfig(this IServiceCollection services, string title,
        string version, string description = "", bool extendSchema = false, string xmlCommentsPath = "")
    {
        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(options =>
            {
                options.OperationFilter<CultureAwareOperationFilter>();
                options.SwaggerDoc($"{version}", new OpenApiInfo
                {
                    Title = $"{title}",
                    Version = $"{version}",
                    Description = $"{description}",
                });

                options.MapType<DateOnly>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "date"
                });

                options.MapType<TimeOnly>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "time",
                    Example = new OpenApiString(TimeOnly.FromDateTime(DateTime.Now).ToString("HH:mm:ss"))
                });

                if (extendSchema)
                    options.UseAllOfToExtendReferenceSchemas();

                if (xmlCommentsPath is not (null or ""))
                    options.IncludeXmlComments(xmlCommentsPath);
            });

        return services;
    }

    public static WebApplication UseSwaggerUINoRoutePrefix(this WebApplication app, string title)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", $"{title}");
        });

        return app;
    }
}