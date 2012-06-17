module("Tennis Game", {
    setup:function () {
        this.tennis = new Tennis("Miguel","Juan");
    },
    createScore:function (playerOne, playerTwo) {
        for (var i = 0; i < playerOne; i++) {
            this.tennis.playerOneScores();
        }
        for (var i = 0; i < playerTwo; i++) {
            this.tennis.playerTwoScores();
        }
    }

});

test("new game return love all", function () {
    equal(this.tennis.getScore(), "Love,Love");
});

test("player one scores first ball", function () {
    this.createScore(1,0);
    equal(this.tennis.getScore(), "Fifteen,Love");
});

test("player two score first ball", function () {
    this.createScore(0,1);
    equal(this.tennis.getScore(), "Love,Fifteen");
});

test("fifteen all", function () {
    this.createScore(1,1);
    equal(this.tennis.getScore(), "Fifteen,Fifteen");
});

test("player one scores first two balls", function () {
    this.createScore(2,0);
    equal(this.tennis.getScore(), "Thirty,Love");
});

test("player one scores first three balls", function () {
    this.createScore(3,0);
    equal(this.tennis.getScore(), "Forty,Love");
});

test("duce all first time", function () {
    this.createScore(3,3);
    equal(this.tennis.getScore(), "Duce");
});

test("player one wins", function () {
    this.createScore(4,0);
    equal(this.tennis.getScore(), "Miguel wins");
});

test("player two wins", function () {
    this.createScore(0,4);
    equal(this.tennis.getScore(), "Juan wins");
});

test("player one has advantage", function () {
    this.createScore(5,4);
    equal(this.tennis.getScore(),"Advantage Miguel");
});

test("player two has advantage", function () {
    this.createScore(4,5);
    equal(this.tennis.getScore(),"Advantage Juan");
});

test("player one wins after advantage", function () {
    this.createScore(6,4);
    equal(this.tennis.getScore(), "Miguel wins");
});

test("duce all twice", function () {
    this.createScore(5,5);
    equal(this.tennis.getScore(), "Duce");
});