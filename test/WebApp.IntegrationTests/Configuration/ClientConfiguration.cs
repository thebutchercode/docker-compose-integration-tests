namespace WebApp.IntegrationTests.Configuration;

public static class ClientConfiguration
{
    public static string WebApiBaseUrl => Environment.GetEnvironmentVariable("WEB_API_BASE_URL") ?? 
                                          "http://webapi";
}
