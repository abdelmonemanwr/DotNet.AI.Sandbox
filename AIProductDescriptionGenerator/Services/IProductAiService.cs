using ProductAiDemo.Models;

namespace ProductAiDemo.Services;

public interface IProductAiService
{
    Task<string> GenerateDescriptionAsync(ProductDescriptionViewModel product, CancellationToken cancellationToken = default);
}