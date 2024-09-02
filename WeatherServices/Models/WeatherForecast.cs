using UnitsNet;

namespace WeatherServices.Models;

public record WeatherForecast(DateOnly Date, Temperature Temperature, WeatherSummary Summary);
