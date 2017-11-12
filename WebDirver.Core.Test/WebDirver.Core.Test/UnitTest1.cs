using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace WebDirver.Core.Test
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver _driver;

        [TestInitialize]
        public void TestInitialize()
        {
            var driverLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string driverLocation = Directory.GetCurrentDirectory();
            _driver = new ChromeDriver(driverLocation);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            const string imLuckyButtonName = "btnI";
            const string aboutButtonId = "archive-link";
            _driver.Navigate().GoToUrl(@"https://google.com/");

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(imLuckyButtonName)));

            _driver.FindElement(By.Name(imLuckyButtonName)).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(aboutButtonId)));

            var aboutButton = _driver.FindElement(By.Id(aboutButtonId));

            Assert.IsTrue(aboutButton.Displayed);
        }
    }
}
