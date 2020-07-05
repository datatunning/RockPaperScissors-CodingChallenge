// <copyright file="HomeControllerShould.cs" company="McLaren Applied Ltd.">
// Copyright (c) McLaren Applied Ltd.</copyright>

using System.Diagnostics.CodeAnalysis;
using FluentAssertions.AspNetCore.Mvc;
using Games.RockPaperScissors.Controllers;
using Games.RockPaperScissors.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace RockPaperScissors.UnitTests.Controllers
{
    [ExcludeFromCodeCoverage]
    public class HomeControllerShould
    {
        public HomeControllerShould()
        {
            _logger = Substitute.For<ILogger<HomeController>>();
        }

        private readonly ILogger<HomeController> _logger;

        [Theory]
        [InlineData(GameType.Standard)]
        [InlineData(GameType.Sheldon)]
        public void ReturnGamesViewWhenCallingGames(GameType gameType)
        {
            // Arrange
            var homeController = new HomeController(_logger);

            // Act
            var actionResult = homeController.Games(gameType);

            // Assert
            actionResult.Should().BeViewResult();
            var view = Assert.IsType<ViewResult>(actionResult);
            var model = Assert.IsAssignableFrom<GameType>(view.ViewData.Model);
            Assert.Equal(gameType, model);
        }

        [Theory]
        [InlineData(GameType.Standard)]
        [InlineData(GameType.Sheldon)]
        public void ReturnRulesViewWhenCallingRules(GameType gameType)
        {
            // Arrange
            var homeController = new HomeController(_logger);

            // Act
            var actionResult = homeController.Rules(gameType);

            // Assert
            actionResult.Should().BeViewResult();
            var view = Assert.IsType<ViewResult>(actionResult);
            var model = Assert.IsAssignableFrom<GameType>(view.ViewData.Model);
            Assert.Equal(gameType, model);
        }

        [Fact]
        public void ReturnIndexViewWhenCallingIndex()
        {
            // Arrange
            var homeController = new HomeController(_logger);

            // Act
            var indexView = homeController.Index();

            // Assert
            indexView.Should().BeViewResult();
        }
    }
}