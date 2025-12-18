namespace WetterApp.Models
{
	public class WeatherData
	{
		public string CityName { get; set; } = string.Empty;
		public double Temperature { get; set; }
		public string Description { get; set; } = string.Empty;
		public int Humidity { get; set; }
		public double WindSpeed { get; set; }
		public string IconUrl { get; set; } = string.Empty;
	}
}