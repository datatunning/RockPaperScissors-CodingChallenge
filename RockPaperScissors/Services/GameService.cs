// <copyright file="GameService.cs" company="Bruno DUVAL.">
// Copyright (c) Bruno DUVAL.</copyright>

using Games.RockPaperScissors.Models;

namespace Games.RockPaperScissors.Services
{
    public interface IGameService
    {
        /// <summary>Processes the hands choices.</summary>
        /// <param name="playerOne">The player one's Hand choice.</param>
        /// <param name="playerTwo">The player two's Hand choice.</param>
        void ProcessHandsChoices(IPlayerModel playerOne, IPlayerModel playerTwo);
    }

    public class GameService : IGameService
    {
        /// <inheritdoc />
        public void ProcessHandsChoices(IPlayerModel playerOne, IPlayerModel playerTwo)
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
    }
}