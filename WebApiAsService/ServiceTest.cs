namespace WebApiAsService;

public class ServiceTest : BackgroundService
{
    public ServiceTest(ILoggerFactory loggerFactory)
    {
        Logger = loggerFactory.CreateLogger<ServiceTest>();
    }

    public ILogger Logger { get; }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Logger.LogInformation("ServiceTest is starting.");

        stoppingToken.Register(() => Logger.LogInformation("ServiceTest is stopping."));

        while (!stoppingToken.IsCancellationRequested)
        {
            Logger.LogInformation("ServiceTest is doing background work.");

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }

        Logger.LogInformation("ServiceTest has stopped.");
    }
}
