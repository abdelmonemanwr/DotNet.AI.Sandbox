using System.ComponentModel.DataAnnotations;

namespace ProductAiDemo.Models;

public class ProductDescriptionViewModel
{
    [Required]
    [Display(Name = "Product Name")]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    public string Category { get; set; } = string.Empty;

    [Required]
    public string Features { get; set; } = string.Empty;

    public string? GeneratedDescription { get; set; }

    public string? ErrorMessage { get; set; }
}