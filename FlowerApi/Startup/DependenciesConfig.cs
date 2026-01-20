using FlowerApi.Data;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace FlowerApi.Startup;

public static class DependenciesConfig
{
    public static void AddDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApiServices();
        builder.Services.AddCorsServices();
        builder.Services.AddAllHealthChecksConfig();
        builder.Services.AddTransient<FlowerData>();
    }

    public static void MapAllHealthChecks(this WebApplication app)
    {
        // Check health endpoint, will pick the lowest status from all registered checks
        // so in this case if one check fails, the overall status will be 'Unhealthy'.
        app.MapHealthChecks("/health");
        // check specific health check by name
        app.MapHealthChecks("/health/healthy", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("healthy")
        });
        app.MapHealthChecks("/health/degraded", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("degraded")
        });
        app.MapHealthChecks("/health/unhealthy", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("unhealthy")
        });
        app.MapHealthChecks("/health/random", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("random")
        });

        // Add health check endpoints UI if needed
        app.MapHealthChecks("/health/ui", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        app.MapHealthChecks("/health/ui/healthy", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("healthy"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.MapHealthChecks("/health/ui/degraded", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("degraded"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.MapHealthChecks("/health/ui/unhealthy", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("unhealthy"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.MapHealthChecks("/health/ui/random", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("random"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
    }
}
