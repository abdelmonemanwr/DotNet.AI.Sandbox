using Microsoft.AspNetCore.Mvc;
using ProductAiDemo.Models;
using ProductAiDemo.Services;

namespace ProductAiDemo.Controllers;

public class ProductController : Controller
{
    private readonly IProductAiService _productAiService;

    public ProductController(IProductAiService productAiService)
    {
        _productAiService = productAiService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new ProductDescriptionViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Generate(
        ProductDescriptionViewModel model,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", model);
        }

        try
        {
            model.GeneratedDescription =
                await _productAiService.GenerateDescriptionAsync(
                    model,
                    cancellationToken);
        }
        catch (Exception)
        {
            model.ErrorMessage =
                "Unable to connect to the AI service. Make sure Ollama is running.";
        }

        return View("Index", model);
    }
}