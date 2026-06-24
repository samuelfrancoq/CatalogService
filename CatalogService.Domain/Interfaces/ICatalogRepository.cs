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
    public Task<Category?> GetCategoryAsync(int id);
    public Task<IEnumerable<Category>> ListCategoriesAsync();
    public Task AddCategoryAsync(Category category);
    public Task UpdateCategoryAsync(Category category);
    public Task DeleteCategoryAsync(int id);

    // Product operations
    public Task<Product?> GetProductAsync(int id);
    public Task<IEnumerable<Product>> ListProductsAsync(int? categoryId, int page, int pageSize);
    public Task AddProductAsync(Product product);
    public Task UpdateProductAsync(Product product);
    public Task DeleteProductAsync(int id);
}
