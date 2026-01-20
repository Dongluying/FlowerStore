using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FlowerApi.HealthChecks;

public class HealthyHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        // This health check mimics a healthy check for real services.
        // The real service may check database connectivity, external service availability, etc.
        return Task.FromResult(HealthCheckResult.Healthy("The service is healthy."));
    }
}
