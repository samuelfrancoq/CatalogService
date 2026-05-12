using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.Domain.Entities;

namespace CatalogService.Domain.Interfaces;

public interface ICatalogRepository
{
    // Category operations
    Task<Category?> GetCategoryAsync(int id);
    Task<IEnumerable<Category>> ListCategoriesAsync();
    Task AddCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(int id);

    // Product operations
    Task<Product?> GetProductAsync(int id);
    Task<IEnumerable<Product>> ListProductsAsync(int? categoryId, int page, int pageSize);
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
}
