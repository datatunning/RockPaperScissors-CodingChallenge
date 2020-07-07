// <copyright file="GameControllerShould.cs" company="Bruno DUVAL.">
// Copyright (c) Bruno DUVAL.</copyright>

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using FluentAssertions.AspNetCore.Mvc;
using Games.RockPaperScissors.Controllers;
using Games.RockPaperScissors.Models;
using Games.RockPaperScissors.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace RockPaperScissors.UnitTests.Controllers
{
    [ExcludeFromCodeCoverage]
    public class GameControllerShould
    {
        public GameControllerShould()
        {
            _logger = Substitute.For<ILogger<GameController>>();
            _gameService = Substitute.For< IGameService > ();
        }

        private readonly ILogger<GameController> _logger;
        private readonly IGameService _gameService;

        [Theory]
        [InlineData(PlayerType.Human)]
        [InlineData(PlayerType.Robot)]
        public void ReturnAViewResultWhenCallingStandardGame(PlayerType playerType)
        {
            // Arrange
            var gameController = new GameController(_logger, _gameService);

            // Act
            var actionResult = gameController.StandardGame(playerType);

            // Assert
            actionResult.Should().BeViewResult();
            var view = Assert.IsType<ViewResult>(actionResult);
            var model = Assert.IsAssignableFrom<GameModel>(view.ViewData.Model);

            model.PlayerOne.Category.Should().Be(playerType);
        }

        [Theory]
        [InlineData(PlayerType.Human, HandType.Rock)]
        [InlineData(PlayerType.Human, HandType.Paper)]
        [InlineData(PlayerType.Human, HandType.Scissors)]
        [InlineData(PlayerType.Robot, HandType.Rock)]
        [InlineData(PlayerType.Robot, HandType.Paper)]
        [InlineData(PlayerType.Robot, HandType.Scissors)]
        public void ReturnStandardGameViewWithUpdatedScoreWhenPlaying(PlayerType playerType, HandType handType)
        {
            // Arrange
            var gameController = new GameController(_logger, _gameService);

            // Act
            gameController.StandardGame(playerType);
            var actionResult = gameController.PlayStandardGame(handType);

            // Assert
            var view = Assert.IsType<ViewResult>(actionResult);
            var model = Assert.IsAssignableFrom<GameModel>(view.ViewData.Model);
            var playerOne = model.PlayerOne;
            var playerTwo = model.PlayerTwo;

            if (playerOne.HandPlayed == playerTwo.HandPlayed)
            {
                model.PlayerOne.Score.Should().BeEquivalentTo(model.PlayerTwo.Score);
            }
            else
            {
                model.PlayerOne.Score.Wins.Should().BeGreaterOrEqualTo(model.PlayerTwo.Score.Loss);
                model.PlayerOne.Score.Loss.Should().BeGreaterOrEqualTo(model.PlayerTwo.Score.Wins);
            }
        }

        [Fact]
        public void ReturnSheldonRulesViewWhenCallingSheldonGame()
        {
            // Arrange
            var gameController = new GameController(_logger, _gameService);

            // Act
            var actionResult = gameController.SheldonGame();

            // Assert
            actionResult.Should().BeRedirectToActionResult();
            var view = Assert.IsType<RedirectToActionResult>(actionResult);

            view.ActionName.Should().Be(nameof(HomeController.Rules));
            view.ControllerName.Should().Be("Home");
            view.RouteValues.Count.Should().Be(1);
            view.RouteValues.First().Value.Should().Be(GameType.Sheldon);
        }
    }
}