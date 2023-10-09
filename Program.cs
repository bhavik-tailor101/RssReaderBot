using RssReaderBot;
using RssReaderBot.Src.Entities;
using RssReaderBot.Src.Processing;

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

IConfigurationRoot configuration = builder.Build(); 

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.Configure<Settings>(configuration.GetSection("Application"));
        services.AddSingleton<AwardWalletFeedProcessor>();
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
