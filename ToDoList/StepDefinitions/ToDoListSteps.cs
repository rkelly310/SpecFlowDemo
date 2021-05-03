using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace ToDoApp.StepDefinitions
{
    [Binding]
    public sealed class ToDoListSteps
    {
        readonly string test_url = "https://lambdatest.github.io/sample-todo-app/";
        readonly string itemName = "Adding item to the list";
        IWebDriver driver;

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef


        [Given(@"that I am on the LambdaTest Sample app")]
        public void GivenThatIAmOnTheLambdaTestSampleApp()
        {
            driver = new FirefoxDriver(@"C:\Users\Rkell\source\repos\ToDoList\ToDoList\Features")
            {
                Url = test_url
            };
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"select the first item")]
        public void ThenSelectTheFirstItem()
        {
            // Click on First Check box
            IWebElement firstCheckBox = driver.FindElement(By.Name("li1"));
            firstCheckBox.Click();
        }

        [Then(@"select the second item")]
        public void ThenSelectTheSecondItem()
        {
            // Click on Second Check box
            IWebElement secondCheckBox = driver.FindElement(By.Name("li2"));
            secondCheckBox.Click();
        }

        [Then(@"find the text box to enter the new value")]
        public void ThenFindTheTextBoxToEnterTheNewValue()
        {
            // Enter Item name
            IWebElement textfield = driver.FindElement(By.Id("sampletodotext"));
            textfield.SendKeys(itemName);
        }

        [Then(@"click the Submit button")]
        public void ThenClickTheSubmitButton()
        {
            // Click on Add button
            IWebElement addButton = driver.FindElement(By.Id("addbutton"));
            addButton.Click();
        }

        [Then(@"verify whether the item is added to the list")]
        public void ThenVerifyWhetherTheItemIsAddedToTheList()
        {
            // Verified Added Item name
            IWebElement itemtext = driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[6]/span"));
            String getText = itemtext.Text;

            // Check if the newly added item is present or not using
            // Condition constraint (Boolean)
            Assert.That((itemName.Contains(getText)), Is.True);

            /* Perform wait to check the output */
            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("Firefox - Test 1 Passed");
        }

        [Then(@"close the browser instance")]
        public void ThenCloseTheBrowserInstance()
        {
            driver.Quit();
        }
    }
}