using System;
using FluentAssertions;
using Nancy;
using Nancy.Testing;
using MainService;
using MainService.NancyFX;
using NUnit.Framework;

namespace IntegrationTest
{
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

    }
}
