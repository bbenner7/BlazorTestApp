using BlazorTestApp.Components;
using Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using WeatherServices;

var builder = WebApplication.CreateBuilder(args);

// Add OpenTelemetry
builder.Logging.AddOpenTelemetry(options =>
{
    options.SetResourceBuilder(ResourceBuilder
            .CreateDefault()
            .AddService("BlazorTestApp"))
        .AddConsoleExporter();
});
builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource.AddService("BlazorTestApp"))
    .WithTracing(tracing => tracing
        .AddSource("BlazorTestApp")
        .AddAspNetCoreInstrumentation()
        .AddConsoleExporter())
    .WithMetrics(tracing => tracing
        .AddAspNetCoreInstrumentation()
        .AddConsoleExporter());

// Add services to the container.
builder.Services
    .AddSingleton<IInstrumentation, Instrumentation>()
    .AddWeatherServices(builder.Configuration)
    .AddRazorComponents()
    .AddInteractiveServerComponents();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
