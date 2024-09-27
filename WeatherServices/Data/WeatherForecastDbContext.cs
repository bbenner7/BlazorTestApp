using Microsoft.EntityFrameworkCore;

namespace WeatherServices.Data;

public class WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options) : DbContext(options)
{
    #region Public Properties

    public DbSet<WeatherForecastEntity> WeatherForecasts { get; set; }

    #endregion Public Properties
}