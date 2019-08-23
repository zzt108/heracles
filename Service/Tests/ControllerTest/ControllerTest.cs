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
    }
}
