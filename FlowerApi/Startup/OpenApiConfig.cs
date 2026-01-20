using Scalar.AspNetCore;

namespace FlowerApi.Startup;

public static class OpenApiConfig
{
    public static void AddOpenApiServices(this IServiceCollection services)
    {
        services.AddOpenApi();
    }

    public static void UseOpenApi(this WebApplication app)
    {
        //if (app.Environment.IsDevelopment())
        //{
        app.MapOpenApi();
        app.MapScalarApiReference(
        option =>
        {
            option.Title = "Flower API";
            option.Theme = ScalarTheme.Moon;
            option.Layout = ScalarLayout.Modern;
            option.HideClientButton = true;
        });        
        //}
    }
}
