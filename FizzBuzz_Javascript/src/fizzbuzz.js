var FizzBuzz = (function () {
    var isDivisibleByFive=function (number) {
        return number % 5 == 0;
    }

    var isDivisibleByThree=function (number) {
        return number % 3 == 0;
    }

    var ThrowErrorIfNumberIsOutOfRange=function (number) {
        if (number < 1 || number > 100) {
            throw new InvalidNumberError();
        }
    }

    return {
        calculate:function (number) {
            ThrowErrorIfNumberIsOutOfRange(number);

            if (isDivisibleByThree(number) && isDivisibleByFive(number)) {
                return "fizzbuzz";
            }
            if (isDivisibleByThree(number)) {
                return "fizz";
            }
            if (isDivisibleByFive(number))
                return "buzz";
            return number;
        }
    };
}());

var InvalidNumberError = function () {

};

