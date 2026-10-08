using Microsoft.Extensions.AI;

namespace DotNet.AI.Sandbox;

internal class AiChatAssistant
{
    private readonly IChatClient _chatClient;

    public AiChatAssistant(IChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    /// <summary>
    /// Starts an interactive chat loop with the LLM model until the user types 'exit'.
    /// </summary>
    public async Task StartInteractiveSessionAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("🤖 AI Interactive Assistant (Type 'exit' to quit) ");
        Console.WriteLine("==================================================\n");

        while (!cancellationToken.IsCancellationRequested)
        {
            Console.Write("You: ");
            var userInput = Console.ReadLine();

            // Exit condition check
            if (string.IsNullOrWhiteSpace(userInput) || userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("AI: Goodbye!");
                break;
            }

            Console.Write("AI: ");

            try
            {
                // Send request to the underlying chat client
                var response = await _chatClient.GetResponseAsync(userInput, cancellationToken: cancellationToken);

                Console.WriteLine(response.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error]: {ex.Message}");
            }

            Console.WriteLine();
        }
    }
}
