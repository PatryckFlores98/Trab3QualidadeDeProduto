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
    class ProductPage 
    {
        private Util util;

        #region

        By locatorCondition = By.XPath("//label[contains(text(),'Condition')]");
        By locatorBigPic = By.XPath("//img[@id='bigpic']");
        By locatorPrice = By.XPath("//span[@id='our_price_display']");
        By locatorAddToCartButton = By.XPath("//span[contains(text(),'Add to cart')]");
        By locatorProductName = By.XPath("//h1[contains(text(),'Faded Short Sleeve T-shirts')]");
        By locatorProceedToCheckoutButton = By.XPath("//span[contains(text(),'Proceed to checkout')]");


        #endregion


        public ProductPage()
        {
           
            util = new Util();
        }

        public void ClickAddToCart()
        {
            SetUp.GetInstance().PriceProduct = util.GetText(locatorPrice);
            SetUp.GetInstance().NameProduct = util.GetText(locatorProductName);
            util.Click(locatorAddToCartButton);
        }

        public void ClickProceedToCheckout()
        {
            util.WaitElementIsEnabled(locatorProceedToCheckoutButton);
            util.Click(locatorProceedToCheckoutButton);
        }

        public void ValidateProductPage()
        {
            util.WaitElementIsEnabled(locatorBigPic);
            Assert.IsTrue(util.IsDisplayed(locatorCondition));
        }

       
    }
}
