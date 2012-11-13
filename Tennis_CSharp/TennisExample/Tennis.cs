using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisExample
{
    public class Tennis
    {
        private int scorePlayer1 = 0;
        private int scorePlayer2 = 0;

        private string player1 = "Juan";
        private string player2 = "Miguel";

        public string Score()
        {
            if (IsDeuce())
            {
                return "Deuce";
            }

            if (HasWinner())
            {
                return PlayerWithHighestScore() + " wins";
            }

            if (HasAdvantage())
            {
                return "Advantage " + PlayerWithHighestScore();
            }

            return scorePlayer1 + "," + scorePlayer2;
        }

        private bool IsDeuce()
        {
            return this.scorePlayer1 == this.scorePlayer2 && this.scorePlayer1 > 40;
        }

        private bool HasWinner()
        {
            var playerOneWins = scorePlayer1 > 40 && scorePlayer1 >= scorePlayer2 + 30;
            var playerTwoWins = scorePlayer2 > 40 && scorePlayer2 >= scorePlayer1 + 30;
            return playerOneWins || playerTwoWins;
        }

        private bool HasAdvantage()
        {
            var playerOneAdvantage = scorePlayer1 > 40 && scorePlayer1 > scorePlayer2;
            var playerTwoAdvantage = scorePlayer2 > 40 && scorePlayer2 > scorePlayer1;
            return playerOneAdvantage || playerTwoAdvantage;
        }

        private string PlayerWithHighestScore()
        {
            return scorePlayer1 > scorePlayer2 ? player1 : player2;
        }

        public void ScorePlayer1()
        {
            scorePlayer1 = IncrementScore(scorePlayer1);
        }

        public void ScorePlayer2()
        {
            scorePlayer2 = IncrementScore(scorePlayer2);
        }


        public int IncrementScore(int currentScore)
        {
            currentScore += 15;
            if (currentScore == 45)
            {
                currentScore = 40;
            }
            return currentScore;
        }
    }
}
