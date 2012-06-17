var Tennis = function (playerOne, playerTwo) {
    var playerOneScore = 0;
    var playerTwoScore = 0;

    this.getScore = function () {
        if (hasWinner()) {
            return playerWithHighestScore() + " wins";
        }
        if (isDuce()) {
            return "Duce";
        }
        if (hasAdvantage()) {
            return "Advantage " + playerWithHighestScore();
        }
        return translateScore(playerOneScore) + "," + translateScore(playerTwoScore);
    }

    this.playerOneScores = function () {
        playerOneScore++;
    }

    this.playerTwoScores = function () {
        playerTwoScore++;
    }

    var hasWinner = function () {
        var playerOneWins = playerOneScore >= 4 && playerOneScore >= playerTwoScore + 2;
        var playerTwoWins = playerTwoScore >= 4 && playerTwoScore >= playerOneScore + 2;
        return playerOneWins || playerTwoWins;
    }

    var hasAdvantage = function () {
        var playerOneHasAdvantage = playerOneScore > playerTwoScore && playerOneScore > 4;
        var playerTwoHasAdvantage = playerTwoScore > playerOneScore && playerTwoScore > 4;
        return playerOneHasAdvantage || playerTwoHasAdvantage;
    }

    var playerWithHighestScore = function () {
        return playerOneScore > playerTwoScore ? playerOne : playerTwo;
    }

    var isDuce = function () {
        return playerOneScore == playerTwoScore && playerOneScore >= 3;
    };

    var translateScore = function (playerScore) {
        if (playerScore == 1) {
            return "Fifteen";
        }
        if (playerScore == 2) {
            return "Thirty"
        }
        if (playerScore == 3) {
            return "Forty"
        }
        return "Love";
    }
};

