using CatalogService.Application.DTOs;

namespace CatalogService.Application.Interfaces;

public interface ICatalogService
{
    // Category Service Contracts
    Task<CategoryDto?> GetCategoryAsync(int id);
    Task<IEnumerable<CategoryDto>> ListCategoriesAsync();
    Task AddCategoryAsync(CategoryDto categoryDto);
    Task UpdateCategoryAsync(CategoryDto categoryDto);
    Task DeleteCategoryAsync(int id);

    // Product Service Contracts
    Task<ProductDto?> GetProductAsync(int id);
    Task<IEnumerable<ProductDto>> ListProductsAsync(int? categoryId, int page, int pageSize);
    Task AddProductAsync(ProductDto productDto);
    Task UpdateProductAsync(ProductDto productDto);
    Task DeleteProductAsync(int id);
}
