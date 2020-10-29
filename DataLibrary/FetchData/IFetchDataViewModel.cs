using System.Threading.Tasks;

namespace DataLibrary
{
    public interface IFetchDataViewModel
    {
        IWeatherForecast[] WeatherForecasts { get; set; }
        Task RetrieveForecastsAsync();
    }
}
