using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace S.SettingService.Api.Health;

public class TestHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = new())
    {
        Console.WriteLine("Executing test health check...");
        return Task.FromResult(
            new HealthCheckResult(
                HealthStatus.Healthy,
                "OK"
            )
        );
    }
}