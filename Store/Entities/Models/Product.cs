using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Product
{
    public int ProductId { get; set; }
 
    public string? ProductName { get; set; } = string.Empty;
   

    public decimal Price { get; set; }

    public String? Summary { get; set; } = String.Empty;

    public String? ImageUrl {  get; set; }

    public int? CategoryId { get; set; }     //Foreign Key 2.anahtar

    public Category? Category { get; set; }   //navigation property
}
