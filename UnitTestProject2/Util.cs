using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using System.IO;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework;
using TechTalk.SpecFlow;
using System.Collections;

using static System.Net.Mime.MediaTypeNames;

namespace Trab3QP
{
    public class Util
    {
        public static Util util;

        public Util()
        {

        }

        public String GetText(By locator)
        {
            String text = SetUp.GetInstance().Driver.FindElement(locator).Text;

            return text;
        }

        public static Util GetInstance()
        {
            if (util == null)
            {
                util = new Util();
            }

            return util;
        }

        public void GoToUrl(string url)
        {
            SetUp.GetInstance().Driver.Navigate().GoToUrl(url);
        }

        public void Close()
        {
            SetUp.GetInstance().Driver.Close();
        }


        public void Click(By locator)
        {
            try
            {
                SetUp.GetInstance().Driver.FindElement(locator).Click();
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to click on the element: " + locator + "\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
            }
        }

      

        public void SendKeys(By locator, string arg)
        {
            try
            {
                
                SetUp.GetInstance().Driver.FindElement(locator).SendKeys(arg);

            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to send keys to the element: " + locator + "\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
            }
        }

       

        public bool WaitElementIsVisible(By locator, int timeout = 30)
        {
            int count = 0;

            do
            {
                try
                {
                    IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                    if (element.Displayed)
                        return true;
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    Thread.Sleep(250);
                    count++;
                }
            } while (count < timeout * 4);

            return false;


        }

    
        public bool WaitElementIsEnabled(By locator, int timeout = 30)
        {
            int count = 0;

            do
            {
                try
                {
                    IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                    if (element.Displayed && element.Enabled)
                        return true;
                }
                catch (Exception)
                {

                }
                finally
                {
                    Thread.Sleep(250);
                    count++;
                }
            } while (count < timeout * 4);

            return false;


        }

       

        public bool ElementContainsText(By locator, string text, bool ignoreCase = false)
        {
            try
            {
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                bool result = false;
                if (ignoreCase)
                {
                    result = element.Text.ToUpper().Contains(text.ToUpper());
                }
                else
                {
                    result = element.Text.Contains(text);
                }
                this.Highlight(element, result);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

      
        public bool ElementEqualsText(By locator, string text)
        {
            try
            {
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                bool result = element.Text.Equals(text);
                this.Highlight(element, result);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

      

        public bool IsEnabled(By locator)
        {
            try
            {
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                bool result = element.Enabled;
                this.Highlight(element, result);
                return result;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public bool IsDisplayed(By locator)
        {
            try
            {
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                bool result = element.Displayed;
                return result;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public void Highlight(By locator, bool arg)
        {
            try
            {
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                string _color = arg ? "outline: 4px solid #00FF00;" : "outline: 4px solid #ff0000;";
                this.ScrollToElement(locator, -500);
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)SetUp.GetInstance().Driver;
                javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);",
                element, _color);
            }

            catch (Exception)
            {
            }

        }

        public void Highlight(IWebElement element, bool arg)
        {
            try
            {
                string _color = arg ? "outline: 4px solid #00FF00;" : "outline: 4px solid #ff0000;";
                this.ScrollToElement(element, -500);
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)SetUp.GetInstance().Driver;
                javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);",
                element, _color);
            }

            catch (Exception)
            {
            }

        }

        public void ScrollToElement(By locator, int space)
        {
            try
            {
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                Point point = new Point();

                if (element != null)
                {
                    point = element.Location;
                    IJavaScriptExecutor js = (IJavaScriptExecutor)SetUp.GetInstance().Driver;

                    js.ExecuteScript("javascript:window.scrollTo(0," + (point.Y + space) + ");");


                }
            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to scroll to the element using JS: " + locator + "\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
            }
        }

  

        public void ScrollToElement(IWebElement element, int space)
        {
            try
            {
                Point point = new Point();

                if (element != null)
                {
                    point = element.Location;
                    IJavaScriptExecutor js = (IJavaScriptExecutor)SetUp.GetInstance().Driver;

                    js.ExecuteScript("arguments[0].scrollIntoView(true);", element);

                }
            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to scroll to the element object using JS. \n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
            }
        }

    
    }
}

