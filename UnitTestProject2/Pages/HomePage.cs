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
    class HomePage 
    {
      
        private Util util;

        #region

        By locatorWomenTab = By.XPath("//button[@name='submit_search']");
        By locatorSearchField = By.XPath("//input[@id='search_query_top']");
        By locatorProduct = By.XPath("//li[@class='ajax_block_product col-xs-12 col-sm-4 col-md-3 first-in-line first-item-of-tablet-line first-item-of-mobile-line']//a[@class='product-name'][contains(text(),'Faded Short Sleeve T-shirts')]");
        

        #endregion


        public HomePage()
        {
         
            util = new Util();
        }

        public void GoToSite(string site)
        {
            
            util.GoToUrl(site);
            
        }

        public void ValidateHome()
        {

            util.WaitElementIsEnabled(locatorSearchField);
            Assert.IsTrue(util.IsDisplayed(locatorWomenTab));


        }

        public void ClickOnProduct()
        {
            
            util.ScrollToElement(locatorProduct,-100);
            util.Click(locatorProduct);
        }
        
    }
}
