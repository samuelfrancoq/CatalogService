using Asp.Versioning;
using CatalogService.Application.DTOs;
using CatalogService.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICatalogService _service;

    public CategoriesController(ICatalogService service)
    {
        _service = service;
    }

    [HttpGet("{id}", Name = "GetCategory")] 
    public async Task<IActionResult> Get(int id)
    {
        var category = await _service.GetCategoryAsync(id);
        if (category == null) return NotFound();

        category.Links.Add(new LinkDto(Url.Link("GetCategory", new { id })!, "self", "GET"));
        category.Links.Add(new LinkDto(Url.Link("UpdateCategory", new { id })!, "update_category", "PUT"));
        category.Links.Add(new LinkDto(Url.Link("DeleteCategory", new { id })!, "delete_category", "DELETE"));
        category.Links.Add(new LinkDto(Url.Content($"~/api/v1/products?categoryId={id}"), "products", "GET"));

        return Ok(category);
    }

    [HttpPost]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> Create([FromBody] CategoryDto dto)
    {
        // Validates and adds a new category
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _service.AddCategoryAsync(dto);
        return Ok();
    }
}
