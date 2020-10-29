using System;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class FetchDataViewModel : IFetchDataViewModel
    {
        private IWeatherForecast[] _weatherForecasts;

        public IWeatherForecast[] WeatherForecasts
        {
            get => _weatherForecasts;
            set => _weatherForecasts = value;
        }
        public IWeatherForecastService ForecastService { get; }

        public FetchDataViewModel(IWeatherForecastService forecastService)
        {
            ForecastService = forecastService;
        }

        public async Task RetrieveForecastsAsync()
        {
            _weatherForecasts = await ForecastService.GetForecastAsync(DateTime.Now);
        }
    }
}