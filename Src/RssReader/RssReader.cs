using CodeHollow.FeedReader;

namespace RssReaderBot.Src.RssReader;

public static class RssReader
{
    public static async Task<Feed> GetFeedFromUrlAsync(string url)
    {
        Feed feed = await FeedReader.ReadAsync(url);

        return feed;
    }
}
