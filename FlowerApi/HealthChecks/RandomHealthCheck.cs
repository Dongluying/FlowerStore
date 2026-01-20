using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FlowerApi.HealthChecks;

public class RandomHealthCheck : IHealthCheck
{
    Task<HealthCheckResult> IHealthCheck.CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken)
    {
        int value = Random.Shared.Next(1, 4);
        return value switch
        {
            1 => Task.FromResult(HealthCheckResult.Healthy("The service is healthy.")),
            2 => Task.FromResult(HealthCheckResult.Degraded("The service is degraded.")),
            3 => Task.FromResult(HealthCheckResult.Unhealthy("The service is unhealthy.")),
            _ => Task.FromResult(HealthCheckResult.Healthy("The service is healthy.")),
        };
    }
}
