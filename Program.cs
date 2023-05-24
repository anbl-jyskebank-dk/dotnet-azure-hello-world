using dotnet_azure_hello_world;
using Microsoft.ApplicationInsights.Extensibility;

var builder = WebApplication.CreateBuilder(args);

// Application Insights:
builder.Services.AddSingleton<ITelemetryInitializer, CustomTelemetryInitializer>();
builder.Services.AddApplicationInsightsTelemetry();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDaprClient();
builder.Services.AddHealthChecks();

var app = builder.Build();
app.MapHealthChecks("/healthz");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
// needed for Dapr pub/sub routing
app.MapSubscribeHandler();

app.Run();
