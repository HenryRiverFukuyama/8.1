
using _18_01_2023;
using Newtonsoft.Json;
using System.Net;
using Weather;

internal class Program
{
    private static void Main(string[] args)
    {
        WebClient Client = new WebClient();

        List<City> Citys = new List<City>()
        {
            new City ("Aalborg", 57.0488, 9.9217),
            new City ("Aarhus", 56.1629, 10.2039),
            new City ("Vejle", 55.7113, 9.5364),
            new City ("Aabenraa", 55.0409, 9.4152),
            new City ("Høje Taastrup", 55.6593, 12.2425)
        };


        foreach (City city in Citys)
        {
            try
            {
                WeatherData Data = new WeatherData();
                string XmlString = Client.DownloadString($"https://api.openweathermap.org/data/2.5/forecast/daily?lat={city.Latitude}&lon={city.Longitude}&cnt=2&appid=32f981a8fd9edcdd55e07c54aafc263d");
                Data = JsonConvert.DeserializeObject<WeatherData>(XmlString);
                Console.WriteLine($"{city.Name} Today: {Data.list.temp1.day}");
                Console.WriteLine($"{city.Name} Tomorrow: {Data.list.temp2.day}");
                Console.WriteLine("");
            }
            catch (Exception M)
            {
                Console.WriteLine(M);
            }
        }
    }
}