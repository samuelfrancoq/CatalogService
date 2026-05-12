using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CatalogService.Api.IntegrationTests
{
    public class CategoryIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CategoryIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetCategory_ReturnsHateoasLinks()
        {
            int categoryId = 1;

            var response = await _client.GetAsync($"/api/v1/categories/{categoryId}");

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            content.Should().Contain("\"links\":");
            content.Should().Contain("\"rel\":\"self\"");
            content.Should().Contain("\"rel\":\"products\"");
        }
    }
}
