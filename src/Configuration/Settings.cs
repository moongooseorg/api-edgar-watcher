using OpenBaoHelper;

namespace ApiEdgarWatcher.Configuration;

[OpenBaoSection("EdgarWatcher")]
public class EdgarWatcherSettings
{
    public int RunEveryXSeconds { get; set; }
    public int MaxServiceCallsInARow { get; set; }
    public int ServiceCallThrottleResetSeconds { get; set; }
    public string ServiceName { get; set; } = "";
    public string UserAgent { get; set; } = "";
    public string[] Tickers { get; set; } = [];
}

[OpenBaoSection("Notification")]
public class NotificationSettings
{
    public string HealthCheckWebhook { get; set; } = "";
    public string DiscordWebhook { get; set; } = "";
}
