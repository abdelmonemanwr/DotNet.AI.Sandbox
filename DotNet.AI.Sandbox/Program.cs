using Microsoft.Extensions.AI;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder();

        var innerClient = new OllamaChatClient(endpoint: new Uri("http://localhost:11434"), modelId: "qwen2.5:0.5b");

        builder.Services.AddChatClient(innerClient);
        
        var app = builder.Build();

        var chatClient = app.Services.GetRequiredService<IChatClient>();

        var chatCompletion = await chatClient.GetResponseAsync("TELL ME FUNNY JOKE");
        Console.WriteLine(chatCompletion.Message.Text);
    }
}