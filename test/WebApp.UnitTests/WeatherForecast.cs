using WebApp.Domain;
using Xunit;

namespace WebApp.UnitTests;

public class WeatherForecastTests
{
    [Theory]
    [InlineData(10, 49)]
    [InlineData(20, 67)]
    public void ProperCalculationFahrenheitValues(int celsius, int fahrenheit)
    {
        var weatherForecast = new WeatherForecast
        {
            TemperatureC = celsius
        };
        
        Assert.Equal(fahrenheit, weatherForecast.TemperatureF);
    }
}