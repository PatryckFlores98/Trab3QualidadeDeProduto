using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trab3QP
{
    class SignInPage
    {
        private Util util;
        public string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        #region

        By locatorCreateAnAccount = By.XPath("//h3[contains(text(),'Create an account')]");
        By locatorAlreadyRegistered = By.XPath("//h3[contains(text(),'Already registered?')]");
        By locatorEmailField = By.XPath("//input[@id='email_create']");
        By locatorCreateAnAccountButton = By.XPath("//form[@id='create-account_form']//span[1]");


        #endregion


        public SignInPage()
        {

            util = new Util();
        }


        public void ValidateSignInPage()
        {
            util.WaitElementIsEnabled(locatorCreateAnAccount);
            Assert.IsTrue(util.IsDisplayed(locatorAlreadyRegistered));
        }

        public void CloseSite()
        {
            util.Close();
        }

    }
}