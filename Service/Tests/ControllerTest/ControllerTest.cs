using System;
using FluentAssertions;
using NUnit.Framework;
using Controller;

namespace TestModel
{
    [TestFixture]
    public class ControllerTest
    {
        [TestCase]
        public void CanFormatInteger()
        {
            var actual = "1600";
            var expected = "1 600.00";
            Format.Money(actual).Should().Be(expected);
            
        }
        [TestCase]
        public void CanRound()
        {
            var actual = "2310000.159897";
            var expected = "2 310 000.16";
            Format.Money(actual).Should().Be(expected);
            
        }

        [TestCase]
        public void CanFormatBillions()
        {
            var actual = "5432310000.15123";
            var expected = "5 432 310 000.15";
            Format.Money(actual).Should().Be(expected);
            
        }

        [TestCase]
        public void CanHandleInvalidInput()
        {
            var actual = "abcd";
            var expectedMessage = "Cannot parse 'abcd'\r\nParameter name: inputNumber";

            Action act = () => { Format.Money(actual); };
            act.Should().Throw<ArgumentException>().WithMessage(expectedMessage);
            
        }


    }
}
