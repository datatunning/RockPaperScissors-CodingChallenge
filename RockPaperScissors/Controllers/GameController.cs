// <copyright file="GameController.cs" company="Bruno DUVAL.">
// Copyright (c) Bruno DUVAL.</copyright>

using Games.RockPaperScissors.Helpers;
using Games.RockPaperScissors.Models;
using Games.RockPaperScissors.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Games.RockPaperScissors.Controllers
{
    /// <summary>
    ///     Controller for Game management
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public sealed class GameController : Controller
    {
        private static GameModel _gameMode; // NOTE: This will normally be in a session/cookie/database
        private readonly ILogger<GameController> _logger;
        private readonly IGameService _gameService;

        /// <summary>Initializes a new instance of the <see cref="GameController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        /// <param name="gameService"></param>
        public GameController(ILogger<GameController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        /// <summary>Standards the game.</summary>
        /// <param name="mainPlayer">The main player type.</param>
        /// <returns>a <see cref="IActionResult" /></returns>
        public IActionResult StandardGame(PlayerType mainPlayer = PlayerType.Robot)
        {
            _logger.LogInformation($"Starting StandardGame");

            _gameMode = mainPlayer == PlayerType.Human
                ? new GameModel("You")
                : new GameModel();

            return View("StandardGame", _gameMode);
        }

        /// <summary>Plays the standard game.</summary>
        /// <param name="handChoice">The <see cref="HandType" /> choice when a person plays against the computer. else empty</param>
        /// <returns>a <see cref="IActionResult" /></returns>
        public IActionResult PlayStandardGame(HandType? handChoice)
        {
            _logger.LogInformation($"Playing StandardGame");

            if (handChoice == null)
                _gameMode.PlayerOne.HandPlayed = EnumHelpers.RandomizeSelection<HandType>();
            else
                _gameMode.PlayerOne.HandPlayed = (HandType) handChoice;
            _gameMode.PlayerTwo.HandPlayed = EnumHelpers.RandomizeSelection<HandType>();

            _gameService.ProcessHandsChoices(_gameMode.PlayerOne, _gameMode.PlayerTwo);

            return View("StandardGame", _gameMode);
        }

        /// <summary>Redirect to the Rules view of Sheldon's Game.</summary>
        /// <returns>a <see cref="IActionResult" /></returns>
        public IActionResult SheldonGame() => RedirectToAction("Rules", "Home", new {gameType = GameType.Sheldon});
    }
}