using EdgarWatcher.Configuration;
using EdgarWatcher.Features;
using EdgarWatcher.Features.SecApi;
using EdgarWatcher.Features.Webhook;
using OpenBaoConfiguration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

try
{
    builder.AddOpenBaoConfiguration();
}
catch (Exception exception)
{
    Console.Error.WriteLine($"Fatal: configuration could not be loaded from OpenBao. {exception}");
    return 1;
}

builder.Services.AddHttpClient<SecApiService>()
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
    });

builder.Services.AddHttpClient<DiscordSecMessenger>();

builder.Services.AddHostedService<WatcherService>();

WebApplication app = builder.Build();

app.MapGet("/healthcheck", () => Results.Json(new { status = "up" }));

app.Run();

return 0;
