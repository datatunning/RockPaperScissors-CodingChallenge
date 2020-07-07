// <copyright file="BasicTests.cs" company="Bruno DUVAL.">
// Copyright (c) Bruno DUVAL.</copyright>

using System.Threading.Tasks;
using Games.RockPaperScissors;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace RockPaperScissors.IntegrationTests.Controllers
{
    public class HomeControllerShould : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public HomeControllerShould(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Games")]
        [InlineData("/Home/Rules")]
        [InlineData("/Home/Rules?gameType=Sheldon")]
        public async Task ReturnSuccessAndCorrectContentTypeWhenNavigatingToPage(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",response.Content.Headers.ContentType.ToString());
        }


    }
}