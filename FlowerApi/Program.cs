using FlowerApi.Endpoints;
using FlowerApi.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.ApplyCorsConfig();

app.MapAllHealthChecks();

app.AddRootEndpoints();
app.AddErrorEndpoints();
app.AddFlowerEndpoints();

app.Run(); 