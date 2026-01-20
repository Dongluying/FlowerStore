using FlowerApi.Data;
using FlowerApi.Models;

namespace FlowerApi.Endpoints;

public static class FlowerEndpoints
{
    public static void AddFlowerEndpoints(this WebApplication app)
    {
        app.MapGet("/flowers", GetAllFlowersAsync)
        .WithTags("Flowers")
        .WithName("GetAllFlowers")
        .WithSummary("Retrieve all flowers")
        .WithDescription("Gets a list of all available flowers in the catalog.")
        .Produces<List<FlowerModel>>(StatusCodes.Status200OK);

        app.MapGet("/flowers/{id}", GetFlowerByIdAsync)
        .WithTags("Flowers")
        .WithName("GetFlowerById")
        .WithSummary("Retrieve flower")
        .WithDescription("Gets a flower by Id.")
        .Produces<List<FlowerModel>>(StatusCodes.Status200OK);
    }

    private static async Task<IResult> GetAllFlowersAsync(
        FlowerData flowerData,
        string? Type,
        string? Search,
        int? delay)
    {
        var flowers = flowerData.Flowers;

        if (string.IsNullOrWhiteSpace(Type) == false)
        {
            flowers.RemoveAll(x => string.Compare(x.Type, Type, StringComparison.OrdinalIgnoreCase) != 0);
        }

        if(string.IsNullOrWhiteSpace(Search) == false)
        {
            flowers.RemoveAll(x => 
                x.Name.Contains(Search, StringComparison.OrdinalIgnoreCase) == false &&
                x.Description.Contains(Search, StringComparison.OrdinalIgnoreCase) == false);
        }

        if(delay.HasValue && delay.Value > 0)
        {
            if(delay.Value > 300000)
            {
                delay = 300000; // Cap delay to 5 mins
            }
            await Task.Delay(delay.Value);
        }
        return Results.Ok(flowers);
    }

    private static async Task<IResult> GetFlowerByIdAsync(int id, FlowerData flowerData, int? delay)
    {
        var flower = flowerData.Flowers.FirstOrDefault(f => f.Id == id);
        if (delay.HasValue && delay.Value > 0)
        {
            if (delay.Value > 300000)
            {
                delay = 300000; // Cap delay to 5 mins
            }
            await Task.Delay(delay.Value);
        }
        return flower is not null ? Results.Ok(flower) : Results.NotFound();
    }
}
