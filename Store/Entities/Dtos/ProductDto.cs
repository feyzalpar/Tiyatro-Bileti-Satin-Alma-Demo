using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record ProductDto 
    {
        public int ProductId { get; init; }
        [Required(ErrorMessage = "Lütfen Ürün Bilgisi Girin.")]

        public string? ProductName { get; init; } = string.Empty;
        [Required(ErrorMessage = "Fiyat Bilgisi Hatalı.")]

        public decimal Price { get; init; }

        public String? Summary { get; init; } = String.Empty;

        public String? ImageUrl { get; set; }

        public int? CategoryId { get; init; } 

    }
}
