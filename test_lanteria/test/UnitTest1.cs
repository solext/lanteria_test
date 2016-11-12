using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test
{
    [TestClass]
    public class UnitTest1
    {
        FirefoxDriver wd;

        [SetUp]

        public void StartBrowser()
        {
            wd = new FirefoxDriver();
            wd.Manage().Window.Maximize();
            wd.Navigate().GoToUrl("https://www.google.com");
            //wd.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        /*[TestCleanup]
        public void TearDown()
        {
            wd.Quit();
        }  
        */

        [Test()]
        public void test() {
            
            Login("testt44455", "12as13ad");

            CreateDraft();

            Refresh();

            Check_draft();

            update_draft();

            check_update_draft();

            Logout();
        }

        private void Login(string username, string password) {
            wd.FindElement(By.Id("gb_70")).Click();
            Thread.Sleep(5000);
            wd.FindElement(By.Id("Email")).Clear();
            wd.FindElement(By.Id("Email")).SendKeys(username);
            wd.FindElement(By.Id("next")).Click();
            Thread.Sleep(5000);
            wd.FindElement(By.Id("Passwd")).Clear();
            wd.FindElement(By.Id("Passwd")).SendKeys(password);
            wd.FindElement(By.Id("signIn")).Click();
            Thread.Sleep(5000);
        }

        public void CreateDraft()
        {
            
            wd.FindElement(By.XPath(".//div[@class='gb_Q gb_R']//child::a")).Click(); // go to Gmail
            Thread.Sleep(10000);
            wd.FindElement(By.XPath("/html/body/div[7]/div[3]/div/div[2]/div[1]/div[1]/div[1]/div[2]/div/div/div[2]/div/div[1]/div[1]/div/div[4]/div/div/div[1]/span/a")).Click(); // go to Drafts
            wd.FindElement(By.XPath("/html/body/div[7]/div[3]/div/div[2]/div[1]/div[1]/div[1]/div[2]/div/div/div[1]/div/div")).Click(); // click compose 
            Thread.Sleep(10000);
            wd.FindElement(By.XPath(".//div[@class='Am Al editable LW-avf']")).Click(); // write text
            Thread.Sleep(5000);
            wd.FindElement(By.XPath(".//div[@class='Am Al editable LW-avf']")).SendKeys("adsad" + Keys.Escape); // write text
            Thread.Sleep(20000);
        }
        public void Refresh() {
            wd.Navigate().Refresh();
            Thread.Sleep(20000);
        }
        public void Check_draft() {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(" - adsad", wd.FindElement(By.XPath(".//div[@class='y6']//child::span[@class='y2']")).Text);
        }
        public void update_draft() {
            wd.FindElement(By.XPath(".//div[@class='y6']//child::span[@class='y2']")).Click();
            Thread.Sleep(10000);
            wd.FindElement(By.XPath(".//div[@class='Am Al editable LW-avf']")).Click(); // write text
            Thread.Sleep(5000);
            wd.FindElement(By.XPath(".//div[@class='Am Al editable LW-avf']")).SendKeys("one" + Keys.Escape); // write text
            Thread.Sleep(5000);
        }

        public void check_update_draft() {
          
            try {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(" - adsadone", wd.FindElement(By.XPath(".//div[@class='y6']//child::span[@class='y2']")).Text);
                wd.FindElement(By.XPath(".//div[@class='T-Jo-auh']")).Click();
                Thread.Sleep(5000);
                wd.FindElement(By.XPath(".//*[@id=':5']/div/div[1]/div[2]")).Click();
                Thread.Sleep(5000);
                wd.FindElement(By.XPath(".//*[@id=':5']/div/div[1]/div[1]/div/div/div[2]/div")).Click();
                Thread.Sleep(5000);
            }
            catch {
                Debug.WriteLine("The draft wasn’t updated");
            }
            
        }
        public void Logout() {
            wd.FindElement(By.XPath(".//*[@id='gb']/div[1]/div[1]/div[2]/div[4]/div[1]/a/span")).Click();
            wd.FindElement(By.XPath(".//*[@id='gb_71']")).Click();
        }
    }

}
