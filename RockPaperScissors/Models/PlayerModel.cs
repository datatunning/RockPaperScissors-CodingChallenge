// <copyright file="PlayerModel.cs" company="Bruno DUVAL.">
// Copyright (c) Bruno DUVAL.</copyright>

using Games.RockPaperScissors.Helpers;

namespace Games.RockPaperScissors.Models
{
    /// <summary>
    ///     The Player model
    /// </summary>
    public class PlayerModel : IPlayerModel
    {
        /// <summary>Initializes a new instance of the <see cref="PlayerModel" /> class.</summary>
        /// <param name="id">The identifier that will be converted to text to generate the Robot's name.</param>
        public PlayerModel(int id)
        {
            Category = PlayerType.Robot;
            Name = $"Robot-{NumberConverter.ConvertNumberToString(id)}";
        }

        /// <summary>Initializes a new instance of the <see cref="PlayerModel" /> class.</summary>
        /// <param name="name">The name.</param>
        public PlayerModel(string name)
        {
            Category = PlayerType.Human;
            Name = name;
        }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>Gets the category.</summary>
        /// <value>The category.</value>
        public PlayerType Category { get; }

        /// <summary>Gets the score.</summary>
        /// <value>The score.</value>
        public ScoreModel Score { get; } = new ScoreModel();

        /// <summary>Gets or sets the hand played.</summary>
        /// <value>The hand played.</value>
        public HandType HandPlayed { get; set; } = HandType.Rock;
    }
}