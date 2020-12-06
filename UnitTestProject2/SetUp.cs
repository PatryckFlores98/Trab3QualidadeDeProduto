using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Remote;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;


namespace Trab3QP

{
    public class SetUp
    {
        private static IWebDriver driver = new ChromeDriver();
        private static SetUp setUp;
        private string url;
        private string priceProduct;
        private string nameProduct;
       


        public string NameProduct
        {
            get
            {
                return nameProduct;
            }

            set
            {
                nameProduct = value;
            }
        }

        public string PriceProduct
        {
            get
            {
                return priceProduct;
            }

            set
            {
                priceProduct = value;
            }
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }

            set
            {
                driver = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

     
        public SetUp()
        {


        }

        public static SetUp GetInstance()
        {
            if (setUp == null)
            {
                setUp = new SetUp();
            }
            return setUp;
        }

       
    

        public void GoToURL(string url)
        {
            try
            {
                Driver.Navigate().GoToUrl(url);
            }
            catch (Exception) { }
        }

    }

}
