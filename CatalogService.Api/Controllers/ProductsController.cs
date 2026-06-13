using Asp.Versioning;
using CatalogService.Application.DTOs;
using CatalogService.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICatalogService _service;

        public ProductsController(ICatalogService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create([FromBody] ProductDto dto)
        {
            // Ensure amount is positive
            if (dto.Amount < 0) return BadRequest("Amount must be a positive integer.");
            await _service.AddProductAsync(dto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? categoryId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            if (page < 1 || pageSize < 1) return BadRequest("Page and pageSize must be greater than 0");

            var products = await _service.ListProductsAsync(categoryId, page, pageSize);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetProductAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");
            await _service.UpdateProductAsync(dto);
            return NoContent();
        }
    }
}
