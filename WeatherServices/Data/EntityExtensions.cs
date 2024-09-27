using UnitsNet;
using WeatherServices.Models;

namespace WeatherServices.Data;

public static class EntityExtensions
{
    public static WeatherForecast ToWeatherForecast(this WeatherForecastEntity entity)
    {
        return new WeatherForecast(entity.Date, Temperature.FromDegreesCelsius(entity.TemperatureC));
    }
}