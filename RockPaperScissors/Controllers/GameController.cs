// <copyright file="GameController.cs" company="McLaren Applied Ltd.">
// Copyright (c) McLaren Applied Ltd.</copyright>

using Games.RockPaperScissors.Helpers;
using Games.RockPaperScissors.Models;
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

        /// <summary>Initializes a new instance of the <see cref="GameController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        /// <summary>Standards the game.</summary>
        /// <param name="mainPlayer">The main player type.</param>
        /// <returns>a <see cref="IActionResult" /></returns>
        public IActionResult StandardGame(PlayerType mainPlayer)
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

            ProcessHandsChoices(_gameMode.PlayerOne, _gameMode.PlayerTwo);

            return View("StandardGame", _gameMode);
        }

        /// <summary>Processes the hands choices.</summary>
        /// <param name="playerOne">The player one's Hand choice.</param>
        /// <param name="playerTwo">The player two's Hand choice.</param>
        private static void ProcessHandsChoices(PlayerModel playerOne, PlayerModel playerTwo)
        {
            if (playerOne.HandPlayed == playerTwo.HandPlayed) // two choices the same
            {
                playerOne.Score.Draws++;
                playerTwo.Score.Draws++;
            }
            else if ( // options for what will produce a win
                (playerOne.HandPlayed == HandType.Rock && playerTwo.HandPlayed == HandType.Scissors)
                ||
                (playerOne.HandPlayed == HandType.Paper && playerTwo.HandPlayed == HandType.Rock)
                ||
                (playerOne.HandPlayed == HandType.Scissors && playerTwo.HandPlayed == HandType.Paper)
            )
            {
                playerOne.Score.Wins++;
                playerTwo.Score.Loss++;
            }
            else // everything else must be a draw
            {
                playerOne.Score.Loss++;
                playerTwo.Score.Wins++;
            }
        }

        /// <summary>Redirect to the Rules view of Sheldon's Game.</summary>
        /// <returns>a <see cref="IActionResult" /></returns>
        public IActionResult SheldonGame() => RedirectToAction("Rules", "Home", new {gameType = GameType.Sheldon});
    }
}