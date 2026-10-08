using DotNet.AI.Sandbox;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Register ChatClient implementation
builder.Services.AddChatClient(
    new OllamaChatClient(
        endpoint: new Uri("http://localhost:11434"), 
        modelId: "qwen2.5:0.5b"
    )
);

// Register the general AI assistant
builder.Services.AddTransient<AiChatAssistant>();

var app = builder.Build();

// Resolve service and start the conversation
var assistant = app.Services.GetRequiredService<AiChatAssistant>();
await assistant.StartInteractiveSessionAsync();