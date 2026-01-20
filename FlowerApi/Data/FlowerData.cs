namespace FlowerApi.Data;
using FlowerApi.Models;
using System.Text.Json;

public class FlowerData
{
    public List<FlowerModel> Flowers {  get; private set; }

    public FlowerData()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "FlowerData.json");
        string jsonData = File.ReadAllText(filePath);

        Flowers = JsonSerializer.Deserialize<List<FlowerModel>>(jsonData, options) ?? new();
    }

}
