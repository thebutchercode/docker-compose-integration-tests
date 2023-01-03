using System.Text.Json;
using System.Text.Json.Serialization;
using WebApp.Domain;
using WebApp.IntegrationTests.Configuration;
using Xunit;

namespace WebApp.IntegrationTests.Tests
{
    public class IntegrationTest
    {
        [Fact]
        public void DummyPositiveTest()
        {
            Assert.True(true);
        }
        
        [Fact]
        public async Task ShouldRetrieveValuesThatWereInsertedBefore()
        {
            using (var client = new HttpClient())
            {
                var weatherForecastEndpoint = $"{ClientConfiguration.WebApiBaseUrl}/weatherForecast";

                var response = await client.GetAsync(weatherForecastEndpoint);

                Assert.True(response.IsSuccessStatusCode);

                var responseBody = await response.Content.ReadAsStreamAsync(CancellationToken.None);

                var weatherForecast = JsonSerializer.Deserialize<List<WeatherForecast>>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters =
                    {
                        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                    }
                });
                
                Assert.NotNull(weatherForecast);
                Assert.NotEmpty(weatherForecast);
            }
        }
    }
}