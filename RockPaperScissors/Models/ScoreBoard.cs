// <copyright file="ScoreBoard.cs" company="McLaren Applied Ltd.">
// Copyright (c) McLaren Applied Ltd.</copyright>

namespace Games.RockPaperScissors.Models
{
    /// <summary>
    ///     The ScoreBoard model.
    /// </summary>
    public class ScoreModel
    {
        /// <summary>Initializes a new instance of the <see cref="ScoreModel" /> class.</summary>
        public ScoreModel()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ScoreModel" /> class.</summary>
        /// <param name="wins">The wins.</param>
        /// <param name="loss">The loss.</param>
        /// <param name="draws">The draws.</param>
        public ScoreModel(int wins, int loss, int draws)
        {
            Wins = wins;
            Loss = loss;
            Draws = draws;
        }

        /// <summary>Gets or sets the wins.</summary>
        /// <value>The wins.</value>
        public int Wins { get; set; }

        /// <summary>Gets or sets the loss.</summary>
        /// <value>The loss.</value>
        public int Loss { get; set; }

        /// <summary>Gets or sets the draws.</summary>
        /// <value>The draws.</value>
        public int Draws { get; set; }
    }
}