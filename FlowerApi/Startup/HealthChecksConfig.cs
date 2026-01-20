using FlowerApi.HealthChecks;

namespace FlowerApi.Startup;

public static class HealthChecksConfig
{
    public static void AddAllHealthChecksConfig(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<HealthyHealthCheck>("Healthy", tags: ["healthy"])
            .AddCheck<DegradedHealthCheck>("Degraded", tags: ["degraded"])
            .AddCheck<UnhealthHealthCheck>("Unhealthy", tags: ["unhealthy"])
            .AddCheck<RandomHealthCheck>("Random", tags: ["random"]);
    }
}
