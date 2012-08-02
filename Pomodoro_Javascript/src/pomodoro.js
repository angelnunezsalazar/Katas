var Pomodoro = function(duration) {
        this.duration = duration || 25;
        this.remaining_time = this.duration;
        this.interruptions = 0;
    };

Pomodoro.prototype = {
    isStopped: function() {
        return true;
    },

    isFinished: function() {
        return this.remaining_time == 0;
    },

    work:function() {
        this.running=true;
        var self = this;
        this.timer = setInterval(function() {
            self.remaining_time -= 1;
            if (self.isFinished()) {
                clearInterval(self.timer);
            };
        }, 1000 * 60);
    },

    start: function() {
        this.work();
    },

    stop: function() {
        if(!this.running)
            throw new Error("Cant stop a Pomodoro if it is not running")
        this.running=false;
        clearInterval(this.timer);
        this.interruptions++;
    },

    resume:function() {
        if (this.running) {
            throw new Error("Cant resume a Pomodoro if it is not stopped")
        };
        this.work();
    },

    restart:function() {
        clearInterval(this.timer);
        this.remaining_time=this.duration;
        this.interruptions=0;
        this.work();
    }

};