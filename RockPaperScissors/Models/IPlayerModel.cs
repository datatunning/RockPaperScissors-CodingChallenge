// <copyright file="IPlayerModel.cs" company="Bruno DUVAL.">
// Copyright (c) Bruno DUVAL.</copyright>

namespace Games.RockPaperScissors.Models
{
    /// <summary>
    ///     Interface for the Player model
    /// </summary>
    public interface IPlayerModel
    {
        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        string Name { get; }

        /// <summary>Gets the category.</summary>
        /// <value>The category.</value>
        PlayerType Category { get; }

        /// <summary>Gets the score.</summary>
        /// <value>The score.</value>
        ScoreModel Score { get; }

        /// <summary>Gets or sets the hand played.</summary>
        /// <value>The hand played.</value>
        HandType HandPlayed { get; set; }
    }
}