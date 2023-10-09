using CodeHollow.FeedReader;
using Microsoft.Extensions.Options;
using RssReaderBot.Src.Entities;

namespace RssReaderBot.Src.Processing;

public class AwardWalletFeedProcessor
{
    private Settings _settings;
    private ILogger<AwardWalletFeedProcessor> _logger;

    public AwardWalletFeedProcessor(ILogger<AwardWalletFeedProcessor> logger, IOptionsMonitor<Settings> options)
    {
        _settings = options.CurrentValue;
        _logger = logger;
    }

    public async Task ProcessFeedAsync() {
        Feed awardWalletFeed = await RssReader.RssReader.GetFeedFromUrlAsync(_settings.AwardWallet.FeedUrl);

        _logger.LogInformation($"Feed Retrieved from Award Wallet: {awardWalletFeed.Title}");
    }
}
