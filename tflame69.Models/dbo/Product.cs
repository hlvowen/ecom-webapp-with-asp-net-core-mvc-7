using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace tflame69.Models.dbo;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    [Required]
    public string ISBN { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    [Display(Name = "Price List")]
    [Range(1, 1000)]
    public double PriceList { get; set; }
    [Display(Name = "Price for 1-50")]
    [Range(1, 1000)]
    public double Price { get; set; }
    
    [Display(Name = "Price for 50+")]
    [Range(1, 1000)]
    public double PriceForMoreThan50 { get; set; }
    
    [Display(Name = "Price for 100+")]
    [Range(1, 1000)]
    public double PriceForMoreThan100 { get; set; }
    
    public int CategoryId { get; set; }
    [ValidateNever]
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
    [ValidateNever]
    public string ImageUrl { get; set; }
    
}