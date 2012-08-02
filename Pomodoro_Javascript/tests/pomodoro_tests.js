(function() {
    var MINUTE = 1000 * 60;

    module("pomodoro", {
        setup: function() {
            this.pomodoro = new Pomodoro();
            this.clock = sinon.useFakeTimers();
        },

        teardown: function() {
            this.clock.restore();
        }
    });

    test('should last 25 minutes by default', function() {
        equal(this.pomodoro.duration, 25);
    });

    test('should be posible to set the duration', function() {
        var pomodoro = new Pomodoro(30);

        equal(pomodoro.duration, 30);
    });

    test('should be stopped when is newly created', function() {
        ok(this.pomodoro.isStopped());
    });

    test('should decrease time when has started', function() {
        this.pomodoro.start();
        this.clock.tick(MINUTE);

        equal(this.pomodoro.remaining_time, 24);
    });

    test('should finish when time is up', function() {
        this.pomodoro.start();

        this.clock.tick(MINUTE * 25)

        ok(this.pomodoro.isFinished());
    });

    test('should not finish when time is not up', function() {
        this.pomodoro.start();

        this.clock.tick(MINUTE * 24)

        ok(!this.pomodoro.isFinished());
    });

    test('should not decrease time when has finished', function() {
        this.pomodoro.start();

        this.clock.tick(MINUTE * 26);

        equal(this.pomodoro.remaining_time, 0);
    });

    test('should not decrease time when has stopped', function() {
        this.pomodoro.start();
        this.clock.tick(MINUTE);

        this.pomodoro.stop();
        this.clock.tick(MINUTE);

        equal(this.pomodoro.remaining_time, 24);
    });

    test('should not stop when has not started', function() {
        raises(function() {
            this.pomodoro.stop();
        }, Error);
    });

    test('should not have interruptions when is newly created', function() {
        equal(this.pomodoro.interruptions, 0);
    });

    test('should count interruptions', function() {
        this.pomodoro.start();
        this.pomodoro.stop();

        equal(this.pomodoro.interruptions, 1);
    });

    test('should continue decreasing time when has resumed', function() {
        this.pomodoro.start();
        this.clock.tick(MINUTE);
        this.pomodoro.stop();

        this.pomodoro.resume();
        this.clock.tick(MINUTE);

        equal(this.pomodoro.remaining_time, 23);
    });

    test('should not resumen when has not stopped', function() {
        this.pomodoro.start();

        raises(function() {
            this.pomodoro.resume();
        },Error);
    });

    test('should start again the count down when has restarted', function() {
        this.pomodoro.start();
        this.clock.tick(MINUTE - 1);

        this.pomodoro.restart();

        this.clock.tick(1);
        equal(this.pomodoro.remaining_time, 25);
        this.clock.tick(MINUTE);
        equal(this.pomodoro.remaining_time, 24);
    });

    test('should not have interruptions when has restarted', function() {
        this.pomodoro.start();

        this.pomodoro.restart();

        equal(this.pomodoro.interruptions, 0);
    });

}());