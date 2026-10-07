using Microsoft.Extensions.AI;
using ProductAiDemo.Models;

namespace ProductAiDemo.Services;

public class ProductAiService : IProductAiService
{
    private readonly IChatClient _chatClient;

    public ProductAiService(IChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    public async Task<string> GenerateDescriptionAsync(
        ProductDescriptionViewModel product,
        CancellationToken cancellationToken = default)
    {
        var prompt = $"""
            You are a professional e-commerce copywriter.

            Generate a short and attractive product description.

            Product Name:
            {product.ProductName}

            Category:
            {product.Category}

            Features:
            {product.Features}

            Requirements:
            - Keep it concise.
            - Use professional English.
            - Highlight the provided features.
            - Do not invent specifications.
            - Do not mention that AI generated the description.
            """;

        var response = await _chatClient.GetResponseAsync(
            prompt,
            cancellationToken: cancellationToken);

        return response.Text;
    }
}