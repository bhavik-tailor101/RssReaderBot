using RssReaderBot.Src.Processing;

namespace RssReaderBot;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly AwardWalletFeedProcessor _awardProcessor;

    public Worker(ILogger<Worker> logger, AwardWalletFeedProcessor awardWalletFeedProcessor)
    {
        _logger = logger;
        _awardProcessor = awardWalletFeedProcessor;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            await _awardProcessor.ProcessFeedAsync();

            await Task.Delay(10000, stoppingToken);
        }
    }
}
