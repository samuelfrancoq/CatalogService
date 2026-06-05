using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.Application.DTOs;
using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;
using MassTransit; // Added for Message Broker support
using Shared.Contracts;

namespace CatalogService.Application.Services;

public class CatalogService : ICatalogService
{
    private readonly ICatalogRepository _repository;
    private readonly IPublishEndpoint _publishEndpoint; // Added for MassTransit

    // Updated constructor to inject MassTransit alongside your real repository
    public CatalogService(ICatalogRepository repository, IPublishEndpoint publishEndpoint)
    {
        _repository = repository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<CategoryDto?> GetCategoryAsync(int id)
    {
        var category = await _repository.GetCategoryAsync(id);
        if (category == null) return null;

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            ImageUrl = category.ImageUrl,
            ParentCategoryId = category.ParentCategoryId
        };
    }

    public async Task<IEnumerable<CategoryDto>> ListCategoriesAsync()
    {
        var categories = await _repository.ListCategoriesAsync();
        return categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            ImageUrl = c.ImageUrl,
            ParentCategoryId = c.ParentCategoryId
        });
    }

    public async Task AddCategoryAsync(CategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name,
            ImageUrl = dto.ImageUrl,
            ParentCategoryId = dto.ParentCategoryId
        };
        await _repository.AddCategoryAsync(category);
    }

    public async Task<ProductDto?> GetProductAsync(int id)
    {
        var p = await _repository.GetProductAsync(id);
        if (p == null) return null;

        return new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Amount = p.Amount,
            CategoryId = p.CategoryId
        };
    }

    public async Task AddProductAsync(ProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Amount = dto.Amount,
            CategoryId = dto.CategoryId
        };
        await _repository.AddProductAsync(product);
    }

    public async Task UpdateCategoryAsync(CategoryDto dto)
    {
        var category = new Category { Id = dto.Id, Name = dto.Name, ImageUrl = dto.ImageUrl, ParentCategoryId = dto.ParentCategoryId };
        await _repository.UpdateCategoryAsync(category);
    }

    public async Task DeleteCategoryAsync(int id) => await _repository.DeleteCategoryAsync(id);
    public async Task<IEnumerable<ProductDto>> ListProductsAsync(int? categoryId, int page, int pageSize)
    {
        var products = await _repository.ListProductsAsync(categoryId, page, pageSize);
        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Amount = p.Amount,
            CategoryId = p.CategoryId
        });
    }

    public async Task UpdateProductAsync(ProductDto dto)
    {
        var product = await _repository.GetProductAsync(dto.Id);
        if (product == null)
            throw new KeyNotFoundException($"Product with ID {dto.Id} was not found in the database.");

        product.Name = dto.Name;
        product.Price = dto.Price;
        product.Amount = dto.Amount;
        product.CategoryId = dto.CategoryId;
        if (dto.Description != null) product.Description = dto.Description;

        await _repository.UpdateProductAsync(product);

        await _publishEndpoint.Publish<ProductUpdatedEvent>(new ProductUpdatedEvent
        {
            ProductId = product.Id,
            NewName = product.Name,
            NewPrice = product.Price
        });
    }

    public async Task DeleteProductAsync(int id) => await _repository.DeleteProductAsync(id);
}