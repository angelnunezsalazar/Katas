test("returns number if not multiple of 3 or 5", function () {
    equal(FizzBuzz.calculate(1), 1);
    equal(FizzBuzz.calculate(2), 2);
    equal(FizzBuzz.calculate(4), 4);
    equal(FizzBuzz.calculate(17), 17);
});

test("returns fizz for multiples of 3", function () {
    equal(FizzBuzz.calculate(3), "fizz");
    equal(FizzBuzz.calculate(9), "fizz");
    equal(FizzBuzz.calculate(12), "fizz");
});

test("return buzz for multiples of 5", function () {
    equal(FizzBuzz.calculate(5), "buzz");
    equal(FizzBuzz.calculate(10),"buzz");
});

test("returns fizzbuzz if divisible by 3 and 5", function () {
    equal(FizzBuzz.calculate(15),"fizzbuzz");
    equal(FizzBuzz.calculate(30),"fizzbuzz");
});

test("throws error if number is out of range", function () {
    raises(function () {
        FizzBuzz.calculate(0);
    },InvalidNumberError);

    raises(function () {
        FizzBuzz.calculate(101);
    },InvalidNumberError);
});
