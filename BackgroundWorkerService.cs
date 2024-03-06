
public class BackgroundWorkerService : IHostedService
{
    readonly ILogger<BackgroundWorkerService> _logger;

    public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger)
    {
            _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Service started.");

        while (!cancellationToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            Task.Delay(1000, cancellationToken).Wait();
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Service stopped.");
        return Task.CompletedTask;
    }
}