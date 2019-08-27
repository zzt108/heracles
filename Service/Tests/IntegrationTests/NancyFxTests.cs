using System;
using FluentAssertions;
using Nancy;
using Nancy.Testing;
using MainService;
using MainService.NancyFX;
using NUnit.Framework;

namespace IntegrationTest
{
    /// <summary>
    /// Thse are direct tests on REST service functionality, 
    /// emulating calls from a browser without hosting the service
    /// Much faster and change resistant than automated UI tests
    /// </summary>
    [TestFixture]
    public class NancyFxTests
    {

        [TestCase]
        public void CanAccessNancy()
        {
            // Given
            var browser = new Browser(with => with.Module<MainModule>());

            // When
            var result = browser.Get("/", with =>
            {
                with.HttpRequest();
            });

            // Then
            Assert.AreEqual(HttpStatusCode.OK, result.Result.StatusCode);
        }

        [TestCase]
        public void CanAccessFormatMoney()
        {
            // Given
            var browser = new Browser(with => with.Module<FormatModule>());

            // When
            var result = browser.Get("/format/money/1600", with =>
            {
                with.HttpRequest();
            });

            // Then
            result.Result.StatusCode.Should().Be(HttpStatusCode.OK, "HttpStatusCode.OK expxted");
        }

        [TestCase]
        public void CanDoHappyPath1()
        {
            // Given
            var browser = new Browser(with => with.Module<FormatModule>());

            // When
            var result = browser.Get("/format/money/1600", with =>
            {
                with.HttpRequest();
            });

            // Then
            result.Result.StatusCode.Should().Be(HttpStatusCode.OK, "HttpStatusCode.OK expxted");
            result.Result.Body.AsString().Should().Be("1 600.00");
        }

        [TestCase]
        public void CanDoHappyPath2()
        {
            // Given
            var browser = new Browser(with => with.Module<FormatModule>());

            // When
            var result = browser.Get("/format/money/2310000.159897", with =>
            {
                with.HttpRequest();
            });

            // Then
            result.Result.StatusCode.Should().Be(HttpStatusCode.OK, "HttpStatusCode.OK expxted");
            result.Result.Body.AsString().Should().Be("2 310 000.16");
        }


        [TestCase]
        public void CanHandleInvalidInput()
        {
            // Given
            var browser = new Browser(with => with.Module<FormatModule>());

            // When
            var result = browser.Get("/format/money/abcd", with =>
            {
                with.HttpRequest();
            });

            // Then
            result.Result.StatusCode.Should().Be(HttpStatusCode.InternalServerError, "HttpStatusCode.InternalServerError expxted");
            result.Result.Body.AsString().Should().Be("[Cannot parse 'abcd'\r\nParameter name: inputNumber]");
        }


    }
}
