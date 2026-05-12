using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        // Required, max length 50
        public string Name { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
