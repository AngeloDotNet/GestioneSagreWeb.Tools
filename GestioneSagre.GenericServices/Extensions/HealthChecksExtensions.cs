using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GestioneSagre.GenericServices.Extensions;

public static class HealthChecksExtensions
{
    public static IEndpointRouteBuilder MapHealthChecks(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHealthChecks("/health", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            ResultStatusCodes =
            {
                [HealthStatus.Healthy] = StatusCodes.Status200OK,
                [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
                [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
            },
        });

        return endpoints;
    }

    public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services, string apiServiceUrl,
        string apiServiceName, string[] tags, string connStringSeq, string SeqApiKey)
    {
        services.AddHealthChecks()
            .AddProcessAllocatedMemoryHealthCheck(100, name: "Allocated Memory")
            .AddUrlGroup(new Uri(apiServiceUrl), apiServiceName, HealthStatus.Degraded, tags)
            .AddSeqPublisher(setup: options =>
            {
                options.Endpoint = connStringSeq;
                options.ApiKey = SeqApiKey;
                options.DefaultInputLevel = HealthChecks.Publisher.Seq.SeqInputLevel.Information;
            }, name: "Seq Publisher");

        return services;
    }
}