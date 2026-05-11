using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FluentAssertions;
using CatalogService.Application.Services;
using CatalogService.Domain.Interfaces;
using CatalogService.Domain.Entities;
using Xunit;

namespace CatalogService.Application.UnitTests;

public class CatalogServiceTests
{
    private readonly Mock<ICatalogRepository> _repoMock;
    private readonly CatalogService.Application.Services.CatalogService _service;

    public CatalogServiceTests()
    {
        _repoMock = new Mock<ICatalogRepository>();
        _service = new CatalogService.Application.Services.CatalogService(_repoMock.Object);
    }

    [Fact]
    public async Task GetCategoryAsync_ShouldReturnMappedDto_WhenCategoryExists()
    {
        var categoryId = 1;
        var categoryEntity = new Category { Id = categoryId, Name = "Electronics" };
        _repoMock.Setup(r => r.GetCategoryAsync(categoryId))
                 .ReturnsAsync(categoryEntity);

        var result = await _service.GetCategoryAsync(categoryId);

        result.Should().NotBeNull();
        result.Name.Should().Be("Electronics");
        result.Id.Should().Be(categoryId);
    }
}
