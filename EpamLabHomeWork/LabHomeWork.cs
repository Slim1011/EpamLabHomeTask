using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace EpamLabHomeWork
{
    public class Tests
    {
        
        [Test]
        public void CheckThatUrlContainsSearchWord()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.google.com.ua/?hl=ru");
            IWebElement searchMenu = driver.FindElement(By.Name("q"));
            searchMenu.SendKeys("flowers images"); 
            searchMenu.Submit();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.IsTrue(driver.Url.Contains("images"));
            Screenshot shot = ((ITakesScreenshot)driver).GetScreenshot();
            shot.SaveAsFile(@"C:\Users\Asus\Desktop\shots\Image.png", ScreenshotImageFormat.Png);
            driver.Quit();

        }
    }
}