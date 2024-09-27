using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherServices.Data
{
    [Table("forecasts")]
    public class WeatherForecastEntity
    {
        #region Public Properties

        public DateOnly Date { get; set; }
        public int Id { get; set; }

        [Column("temperature_c")]
        public double TemperatureC { get; set; }

        #endregion Public Properties
    }
}