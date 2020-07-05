// <copyright file="GameMode.cs" company="McLaren Applied Ltd.">
// Copyright (c) McLaren Applied Ltd.</copyright>

namespace Games.RockPaperScissors.Models
{
    /// <summary>
    ///     The Game model that store the Players info along with the game scores.
    /// </summary>
    public class GameModel
    {
        /// <summary>Initializes a new instance of the <see cref="GameModel" /> class.</summary>
        public GameModel()
        {
            PlayerOne = new PlayerModel(1);
            PlayerTwo = new PlayerModel(2);
        }

        /// <summary>Initializes a new instance of the <see cref="GameModel" /> class.</summary>
        /// <param name="name">The name.</param>
        public GameModel(string name)
        {
            PlayerOne = new PlayerModel(name);
            PlayerTwo = new PlayerModel(1);
        }

        /// <summary>Gets the player one.</summary>
        /// <value>The player one.</value>
        public PlayerModel PlayerOne { get; }

        /// <summary>Gets the player two.</summary>
        /// <value>The player two.</value>
        public PlayerModel PlayerTwo { get; }

        /// <summary>Gets a value indicating whether this instance is human vs robot.</summary>
        /// <value>
        ///     <c>true</c> if this instance is human vs robot; otherwise, <c>false</c>.
        /// </value>
        public bool IsHumanVsRobot => PlayerOne.Category == PlayerType.Human || PlayerTwo.Category == PlayerType.Human;
    }
}