namespace dotnet_azure_hello_world;

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
    
    public override string ToString() {
        return "[Date: " + Date +", Temp.: " + TemperatureC +", Summary: " + Summary + "]";
    }
}
