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


namespace NUnitProject3

{
    public class SetUp
    {
        private static IWebDriver driver;
        private static SetUp setUp;
        private string url;
        private string onboardingUsername;
        private String timestamp;
        private static String trackName;
        private static String serviceFixedName;
        private static String serviceQuotedName;
        private string purchaseTotalPrice;
        private string purchaseName;
        private string sellerName;
        private string customerName;
        private string customerEmail;
        private string customerPhone;
        private string customerAddress;

        private string personalPaypalEmail;
        private string personalPaypalPassword;
        private string businessPaypalEmail;
        private string businessPaypalPassword;


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

        public string OnboardingUsername
        {
            get
            {
                return onboardingUsername;
            }

            set
            {
                onboardingUsername = value;
            }
        }

        public string TrackName
        {
            get
            {
                return trackName;
            }

            set
            {
                trackName = value;
            }
        }

        public string ServiceFixedName
        {
            get
            {
                return serviceFixedName;
            }

            set
            {
                serviceFixedName = value;
            }
        }

        public string ServiceQuotedName
        {
            get
            {
                return serviceQuotedName;
            }

            set
            {
                serviceQuotedName = value;
            }
        }

        public string Timestamp
        {
            get
            {
                return timestamp;
            }

            set
            {
                timestamp = value;
            }
        }

        public string PurchaseTotalPrice
        {
            get
            {
                return purchaseTotalPrice;
            }

            set
            {
                purchaseTotalPrice = value;
            }
        }

        public string PurchaseName
        {
            get
            {
                return purchaseName;
            }

            set
            {
                purchaseName = value;
            }
        }

        public string SellerName
        {
            get
            {
                return sellerName;
            }

            set
            {
                sellerName = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
            }
        }

        public string CustomerEmail
        {
            get
            {
                return customerEmail;
            }

            set
            {
                customerEmail = value;
            }
        }

        public string CustomerPhone
        {
            get
            {
                return customerPhone;
            }

            set
            {
                customerPhone = value;
            }
        }

        public string CustomerAddress
        {
            get
            {
                return customerAddress;
            }

            set
            {
                customerAddress = value;
            }
        }

        public string PersonalPaypalEmail
        {
            get
            {
                return personalPaypalEmail;
            }

            set
            {
                personalPaypalEmail = value;
            }
        }

        public string PersonalPaypalPassword
        {
            get
            {
                return personalPaypalPassword;
            }

            set
            {
                personalPaypalPassword = value;
            }
        }

        public string BusinessPaypalEmail
        {
            get
            {
                return businessPaypalEmail;
            }

            set
            {
                businessPaypalEmail = value;
            }
        }

        public string BusinessPaypalPassword
        {
            get
            {
                return businessPaypalPassword;
            }

            set
            {
                businessPaypalPassword = value;
            }
        }

        private SetUp()
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

        public void SetUpDriver(string browser = "Chrome", string deviceName = null)
        {

            try
            {
                switch (browser)
                {
                    case "Chrome":
                        var optionsChrome = new ChromeOptions();
                        string downloadLocation = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName, "tests", "files", "Downloads");
                        optionsChrome.AddUserProfilePreference("download.default_directory", downloadLocation);
                        optionsChrome.AddUserProfilePreference("intl.accept_languages", "nl");
                        optionsChrome.AddUserProfilePreference("disable-popup-blocking", "true");
                        optionsChrome.AddArguments("--lang=en");

                        driver = new ChromeDriver(optionsChrome);
                        break;

                    case "Firefox":
                        driver = new FirefoxDriver();
                        break;

                    case "Chrome Mobile":
                        var optionsChromeMobile = new ChromeOptions();
                        optionsChromeMobile.EnableMobileEmulation(deviceName);
                        driver = new ChromeDriver(optionsChromeMobile);
                        break;

                    case "Safari Mac":

                        driver = new SafariDriver();
                        break;

                }
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                driver.Manage().Window.Maximize();
            }
            catch (Exception e)
            {

            }

        }

        public void QuitDriver()
        {

            try
            {
                setUp = null;
                Driver.Quit();
            }
            catch (Exception)
            {

            }

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
