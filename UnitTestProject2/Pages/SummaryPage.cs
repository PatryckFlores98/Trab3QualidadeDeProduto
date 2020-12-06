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
    class SummaryPage 
    {
      
        private Util util;

        #region

        By locatorCardTitle = By.XPath("//h1[@id='cart_title']");
        By locatorShipping = By.XPath("//td[@id='total_shipping']");
        By locatorTotalPriceProduct = By.XPath("//td[@id='total_product']");
        By locatorProductNameSummary = By.XPath("//td[@class='cart_description']//a[contains(text(),'Faded Short Sleeve T-shirts')]");
        By locatorProceedToCheckoutButton = By.XPath("//a[@class='button btn btn-default standard-checkout button-medium']//span[contains(text(),'Proceed to checkout')]");
        By locatorTotalPrice = By.XPath("//span[@id='total_price']"); 
        #endregion


        public SummaryPage()
        {
         
            util = new Util();
        }

      

        public void ValidateCartSummary()
        {


            Assert.IsTrue(util.IsDisplayed(locatorCardTitle));
            Assert.IsTrue(util.ElementEqualsText(locatorProductNameSummary, SetUp.GetInstance().NameProduct));
            
        }

       
        
    }
}
