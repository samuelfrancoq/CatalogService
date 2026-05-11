using CatalogService.Application.DTOs;
using CatalogService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICatalogService _service;

    public CategoryController(ICatalogService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // Lists all categories from the service
        var result = await _service.ListCategoriesAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryDto dto)
    {
        // Validates and adds a new category
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _service.AddCategoryAsync(dto);
        return Ok();
    }
}
