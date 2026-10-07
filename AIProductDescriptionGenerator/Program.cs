using Microsoft.Extensions.AI;
using OllamaSharp;
using ProductAiDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// AI configuration
var ollamaEndpoint =
    builder.Configuration["AI:OllamaEndpoint"]
    ?? throw new InvalidOperationException(
        "AI:OllamaEndpoint is missing.");

var model =
    builder.Configuration["AI:Model"]
    ?? throw new InvalidOperationException(
        "AI:Model is missing.");

// Register Ollama as the IChatClient implementation
builder.Services.AddChatClient(
    new OllamaApiClient(
        new Uri(ollamaEndpoint),
        model));

// Application service
builder.Services.AddScoped<IProductAiService, ProductAiService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();