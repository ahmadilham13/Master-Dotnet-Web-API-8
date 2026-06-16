namespace Api.Configs;

public class AppSettings
{
    public string ServiceName { get; set; }
    public string Secret { get; set; }
    public int JwtTokenTTL { get; set; }
    public int RefreshTokenTTL { get; set; }
    public string MainUrl { get; set; }
    public string BackendUrl { get; set; }
    public string LocalUrl { get; set; }
    public bool UseSwagger { get; set; }
    public bool EnableDBLogging { get; set; }
}