using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Selenium.Interfaces;
using Selenium;
using System.Configuration;

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
        public void CanOpenUI()
        {
            using (var selenium = new Selenium.Selenium(WebSiteRoot + "client.html", _browserType))
            {
                selenium.Driver.Navigate().GoToUrl(selenium.BaseUrl);
            }
        }
    }
}
