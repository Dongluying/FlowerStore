using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FlowerApi.HealthChecks;

public class UnhealthHealthCheck : IHealthCheck
{
    Task<HealthCheckResult> IHealthCheck.CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken)
    {
        return Task.FromResult(HealthCheckResult.Unhealthy("The service is unhealthy."));
    }
}
