using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.Services;

namespace WeatherApp.Models.ViewModels
{
    internal partial class WeatherInfoPageViewModel : ObservableObject
    {


        private readonly WeatherApiService _weatherApiService;

        public WeatherInfoPageViewModel()
        {
            _weatherApiService = new WeatherApiService();
        }


        [ObservableProperty]
        private string city_name;

        [ObservableProperty]
        private string weather_icon;

        [ObservableProperty]
        private string temp;

        [ObservableProperty]
        private string weatherDescription;

        [ObservableProperty]
        private string location;

        [ObservableProperty]
        private string humidity;

        [ObservableProperty]
        private string cloudcoverlevel;

        [ObservableProperty]
        private string isDay;

        [RelayCommand]
        private async Task FetchWeatherInfo()
        {
            var weatherApiResponse = await _weatherApiService.GetWeatherInformation(City_name);
            if (weatherApiResponse != null)
            {
                Weather_icon = weatherApiResponse.Current.WeatherIcons[0];
                Temp = $"{weatherApiResponse.Current.Temperature}°C";
                Location = $"{weatherApiResponse.Location.Name}, {weatherApiResponse.Location.Region}, {weatherApiResponse.Location.Country}";
                WeatherDescription = weatherApiResponse.Current.WeatherDescriptions[0];
                //Humidity = weatherApiResponse.Current.Humidity;
                Cloudcoverlevel = $"{weatherApiResponse.Current.CloudCoverLevel}%";
                IsDay = weatherApiResponse.Current.IsDay.ToUpper();
            }
        }
    }
}
