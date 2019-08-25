using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium;
using FluentAssertions;

namespace IntegrationTest
{
    [TestFixture(Selenium.Selenium.BrowserTypeEnum.Chrome)]
    public class UITests
    {
        private Selenium.Selenium.BrowserTypeEnum _browserType;
        private static string WebSiteRoot { get; set; }

        static UITests()
        {
            WebSiteRoot = ConfigurationManager.AppSettings["WebSiteRoot"];
        }

        public UITests(Selenium.Selenium.BrowserTypeEnum browserType)
        {
            _browserType = browserType;
        }

        [Test]
        public void CanOpenUIWithoutBackend()
        {
            using (var selenium = new Selenium.Selenium(WebSiteRoot + "client.html", _browserType))
            {
                var driver = selenium.Driver;
                driver.Navigate().GoToUrl(selenium.BaseUrl);
                var inputNumber = driver.FindElement(By.Id("aidNumber"));
                var sendButton = driver.FindElement(By.Id("aidCallService"));
                inputNumber.Clear();
                inputNumber.SendKeys("1234");
                sendButton.Click();

                var errorMessage = driver.FindElement(By.Id("aidError"));
                errorMessage.Should().NotBeNull("There should be an error message about missing service");
                errorMessage.Text.Should().Be("No API Error", "No API Error message expected");
            }
        }

        [Test]
        public void CanDoHappyPath1()
        {
            using (var service = new ServiceHandler())
            {
                using (var selenium = new Selenium.Selenium(WebSiteRoot + "client.html", _browserType))
                {
                    var driver = selenium.Driver;
                    driver.Navigate().GoToUrl(selenium.BaseUrl);
                    var inputNumber = driver.FindElement(By.Id("aidNumber"));
                    var sendButton = driver.FindElement(By.Id("aidCallService"));
                    inputNumber.Clear();
                    inputNumber.SendKeys("1600");
                    sendButton.Click();

                    var errorMessage = driver.FindElement(By.Id("aidError"));
                    errorMessage.Should().BeNull("There should be NO error message");
                }
            }
        }
    }
}
