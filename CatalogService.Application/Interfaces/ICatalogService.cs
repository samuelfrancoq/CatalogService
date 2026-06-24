using CatalogService.Application.DTOs;

namespace CatalogService.Application.Interfaces;

public interface ICatalogService
{
    // Category Service Contracts
    public Task<CategoryDto?> GetCategoryAsync(int id);
    public Task<IEnumerable<CategoryDto>> ListCategoriesAsync();
    public Task AddCategoryAsync(CategoryDto categoryDto);
    public Task UpdateCategoryAsync(CategoryDto categoryDto);
    public Task DeleteCategoryAsync(int id);

    // Product Service Contracts
    public Task<ProductDto?> GetProductAsync(int id);
    public Task<IEnumerable<ProductDto>> ListProductsAsync(int? categoryId, int page, int pageSize);
    public Task AddProductAsync(ProductDto productDto);
    public Task UpdateProductAsync(ProductDto productDto);
    public Task DeleteProductAsync(int id);
}
