using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Max length 50
        public string? Description { get; set; } // Can contain HTML
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; } // Positive int
                                        // Required: item belongs to one category
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
