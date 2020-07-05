// <copyright file="HomeController.cs" company="McLaren Applied Ltd.">
// Copyright (c) McLaren Applied Ltd.</copyright>

using System.Diagnostics;
using Games.RockPaperScissors.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Games.RockPaperScissors.Controllers
{
    /// <summary>
    ///     Controller for main Views
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public sealed class HomeController : Controller
    {
        /// <summary>The logger</summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>Initializes a new instance of the <see cref="HomeController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>Return the Index view.</summary>
        /// <returns>a <see cref="IActionResult" /></returns>
        public IActionResult Index() => View();

        /// <summary>Gameses the specified game type.</summary>
        /// <param name="gameType">Type of the game.</param>
        /// <returns>a <see cref="IActionResult" /></returns>
        public IActionResult Games(GameType gameType = GameType.Standard) => View(gameType);

        /// <summary>Ruleses the specified game type.</summary>
        /// <param name="gameType">Type of the game.</param>
        /// <returns>a <see cref="IActionResult" /></returns>
        public IActionResult Rules(GameType gameType = GameType.Standard) => View(gameType);

        /// <summary>Revokes the cookie consent.</summary>
        /// <returns>a <see cref="IActionResult" /></returns>
        public IActionResult RevokeCookieConsent()
        {
            _logger.LogInformation("Removing privacy cookie consent.");
            ControllerContext?.HttpContext?.Features?.Get<ITrackingConsentFeature>()?.WithdrawConsent();
            return View("Index");
        }

        /// <summary>Errors this instance.</summary>
        /// <returns>a <see cref="IActionResult" /></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorModel = new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier};
            _logger.LogError(errorModel.RequestId);
            return View();
        }
    }
}