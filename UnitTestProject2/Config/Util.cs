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

namespace NUnitProject3
{
    class Util
    {
        private static Util util;

        private Util()
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

        public void ClearField(By locator)
        {
            try
            {
                SetUp.GetInstance().Driver.FindElement(locator).Clear();

            }
            catch (Exception ex)
            {
            }
        }

        public void SendKeys(By locator, string arg, bool clear = false)
        {
            try
            {
                if (clear)
                {
                    util.ClearField(locator);
                }
                SetUp.GetInstance().Driver.FindElement(locator).SendKeys(arg);

            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to send keys to the element: " + locator + "\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
            }
        }

        public void SwitchFrame(By locator)
        {
            try
            {
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                SetUp.GetInstance().Driver.SwitchTo().Frame(element);
            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to switch to frame: " + locator + "\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
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

        public void SwitchWindow()
        {
            try
            {
                var newTab = SetUp.GetInstance().Driver.WindowHandles.Last();
                SetUp.GetInstance().Driver.SwitchTo().Window(newTab);

            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível realizar a troca de página, log de erro: " + e);
            }
        }

        public bool WaitElementIsNotVisible(By locator, int timeout = 30)
        {
            int count = 0;

            do
            {
                try
                {
                    IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                    if (element.Displayed)
                        continue;
                }
                catch (Exception)
                {
                    return true;
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

        public bool ElementsListContainsText(By locator, string text)
        {
            try
            {
                List<IWebElement> elementsList = new List<IWebElement>();
                elementsList.AddRange(SetUp.GetInstance().Driver.FindElements(locator));
                bool result = false;
                foreach (IWebElement element in elementsList)
                {
                    if (element.Text.Contains(text))
                    {
                        result = true;
                        util.Highlight(element, true);
                        break;
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return false;
            }
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

        public bool ElementTextMatchRegex(By locator, string pattern)
        {
            try
            {
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);


                Match m = Regex.Match(element.Text, pattern);
                if (m.Success)
                {
                    Highlight(element, true);
                    return true;
                }
                else
                {
                    Highlight(element, false);
                    return false;
                }
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

        public bool AttributeContainsText(By locator, string att, string text)
        {
            try
            {
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                bool result = element.GetAttribute(att).Contains(text);
                this.Highlight(element, result);
                return result;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public string GetAttibute(By locator, string att)
        {
            try
            {
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                this.Highlight(element, true);
                return element.GetAttribute(att);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<IWebElement> GetElementsList(By locator)
        {
            try
            {
                List<IWebElement> elementsList = new List<IWebElement>();
                elementsList.AddRange(SetUp.GetInstance().Driver.FindElements(locator));

                return elementsList;
            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to get the elements List: " + locator + "\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
                return null;
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

        public bool IsDisabled(By locator)
        {
            try
            {
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                bool result = !element.Enabled;
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
                this.Highlight(element, result);
                return result;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool IsNotDisplayed(By locator)
        {
            try
            {
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                bool result = !element.Displayed;
                this.Highlight(element, result);
                return result;
            }
            catch (Exception)
            {
                return true;
            }

        }

        public void RefreshPage()
        {
            try
            {
                SetUp.GetInstance().Driver.Navigate().Refresh();
            }
            catch (Exception)
            {

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

        public void FocusJS(By locator)
        {
            try
            {
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                IJavaScriptExecutor executor = (IJavaScriptExecutor)SetUp.GetInstance().Driver;
                executor.ExecuteScript("arguments[0].focus();", element);
            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to focus on the element: " + locator + "\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
            }
        }

        public void ClickJS(By locator)
        {
            try
            {
                WaitElementIsVisible(locator, 10);
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                this.Highlight(element, true);
                IJavaScriptExecutor executor = (IJavaScriptExecutor)SetUp.GetInstance().Driver;
                executor.ExecuteScript("arguments[0].click();", element);
            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to click using JS on the element: " + locator + "\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
            }
        }

        public void DoubleClickJS(By locator)
        {
            try
            {
                WaitElementIsVisible(locator, 10);
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                this.Highlight(element, true);
                IJavaScriptExecutor executor = (IJavaScriptExecutor)SetUp.GetInstance().Driver;
                executor.ExecuteScript("arguments[0].doubleclick();", element);
            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to double click using JS on the element: " + locator + "\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
            }
        }

        public void ClickOnListJS(By locator, string arg)
        {
            try
            {
                IList<IWebElement> elements = SetUp.GetInstance().Driver.FindElements(locator);

                foreach (IWebElement element in elements)
                {
                    if (element.Text.Contains(arg))
                    {
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)SetUp.GetInstance().Driver;
                        executor.ExecuteScript("arguments[0].click();", element);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to click on the list of elements using JS: " + locator + "\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
            }
        }

        public void SendKeysJS(By locator, string arg)
        {
            try
            {
                WaitElementIsVisible(locator, 10);
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                this.Highlight(element, true);
                IJavaScriptExecutor executor = (IJavaScriptExecutor)SetUp.GetInstance().Driver;
                executor.ExecuteScript("arguments[0].value = '" + arg + "';", element);
            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to send keys to the element using JS: " + locator + "\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
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

        public void ScrollTo(int x, int y)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)SetUp.GetInstance().Driver;

                js.ExecuteScript(String.Format("window.scrollBy({0}, {1});", x, y));
            }
            catch (Exception)
            {

            }
        }

        public void MouseHover(By locator)
        {
            try
            {
                Thread.Sleep(250);
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                string mouseOverScript = "if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('mouseover', true, false); arguments[0].dispatchEvent(evObj);} else if(document.createEventObject) { arguments[0].fireEvent('onmouseover');}";
                IJavaScriptExecutor js = SetUp.GetInstance().Driver as IJavaScriptExecutor;
                js.ExecuteScript(mouseOverScript, element);

            }
            catch (Exception e)
            {

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

        public void SetSelect(By locator, int index)
        {
            try
            {
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                SelectElement selectElement = new SelectElement(element);
                if (element.Displayed && element.Enabled)
                {

                    this.Highlight(element, true);
                    selectElement.SelectByIndex(index);
                }

            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to select element by index: " + locator + "\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
            }

        }

        public void SetSelect(By locator, string arg)
        {
            try
            {
                IWebElement element = SetUp.GetInstance().Driver.FindElement(locator);
                SelectElement selectElement = new SelectElement(element);
                if (element.Displayed && element.Enabled)
                {
                    this.Highlight(element, true);
                    selectElement.SelectByText(arg);
                }

            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to select element by text: " + locator + "\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
            }

        }

        //public Image GetEntireScreenshot()
        //{
        //    // Get the total size of the page
        //    ((IJavaScriptExecutor)SetUp.GetInstance().Driver).ExecuteScript(String.Format("document.body.style.zoom = '50 %'"));
        //    ((IJavaScriptExecutor)SetUp.GetInstance().Driver).ExecuteScript(String.Format("window.scrollBy(0,-1200)"));
        //    var totalWidth = (int)(long)((IJavaScriptExecutor)SetUp.GetInstance().Driver).ExecuteScript("return document.body.offsetWidth"); //documentElement.scrollWidth");
        //    var totalHeight = (int)(long)((IJavaScriptExecutor)SetUp.GetInstance().Driver).ExecuteScript("return  document.body.parentNode.scrollHeight");
        //    // Get the size of the viewport
        //    var viewportWidth = (int)(long)((IJavaScriptExecutor)SetUp.GetInstance().Driver).ExecuteScript("return document.body.clientWidth"); //documentElement.scrollWidth");
        //    var viewportHeight = (int)(long)((IJavaScriptExecutor)SetUp.GetInstance().Driver).ExecuteScript("return window.innerHeight"); //documentElement.scrollWidth");

        //    // We only care about taking multiple images together if it doesn't already fit
        //    if (totalWidth <= viewportWidth && totalHeight <= viewportHeight)
        //    {
        //        var screenshot = SetUp.GetInstance().Driver.TakeScreenshot();
        //        return ScreenshotToImage(screenshot);
        //    }
        //    // Split the screen in multiple Rectangles
        //    var rectangles = new List<Rectangle>();
        //    // Loop until the totalHeight is reached
        //    for (var y = 0; y < totalHeight; y += viewportHeight)
        //    {
        //        var newHeight = viewportHeight;
        //        // Fix if the height of the element is too big
        //        if (y + viewportHeight > totalHeight)
        //        {
        //            newHeight = totalHeight - y;
        //        }
        //        // Loop until the totalWidth is reached
        //        for (var x = 0; x < totalWidth; x += viewportWidth)
        //        {
        //            var newWidth = viewportWidth;
        //            // Fix if the Width of the Element is too big
        //            if (x + viewportWidth > totalWidth)
        //            {
        //                newWidth = totalWidth - x;
        //            }
        //            // Create and add the Rectangle
        //            var currRect = new Rectangle(x, y, newWidth, newHeight);
        //            rectangles.Add(currRect);
        //        }
        //    }
        //    // Build the Image
        //    var stitchedImage = new Bitmap(totalWidth, totalHeight);
        //    // Get all Screenshots and stitch them together
        //    var previous = Rectangle.Empty;
        //    foreach (var rectangle in rectangles)
        //    {
        //        // Calculate the scrolling (if needed)
        //        if (previous != Rectangle.Empty)
        //        {
        //            var xDiff = rectangle.Right - previous.Right;
        //            var yDiff = rectangle.Bottom - previous.Bottom;
        //            // Scroll
        //            ((IJavaScriptExecutor)SetUp.GetInstance().Driver).ExecuteScript(String.Format("window.scrollBy({0}, {1})", xDiff, yDiff));
        //        }
        //        // Take Screenshot
        //        var screenshot = SetUp.GetInstance().Driver.TakeScreenshot();
        //        // Build an Image out of the Screenshot
        //        var screenshotImage = ScreenshotToImage(screenshot);
        //        // Calculate the source Rectangle
        //        var sourceRectangle = new Rectangle(viewportWidth - rectangle.Width, viewportHeight - rectangle.Height, rectangle.Width, rectangle.Height);
        //        // Copy the Image
        //        using (var graphics = Graphics.FromImage(stitchedImage))
        //        {
        //            graphics.DrawImage(screenshotImage, rectangle, sourceRectangle, GraphicsUnit.Pixel);
        //        }
        //        // Set the Previous Rectangle
        //        previous = rectangle;
        //    }
        //    return stitchedImage;
        //}

        //private static Image ScreenshotToImage(Screenshot screenshot)
        //{
        //    Image screenshotImage;
        //    using (var memStream = new MemoryStream(screenshot.AsByteArray))
        //    {
        //        screenshotImage = Image.FromStream(memStream);
        //    }

        //    return screenshotImage;
        //}

        //public string TakeScreenshot(string strLog)
        //{
        //    try
        //    {

        //        string dt = DateTime.Now.ToString("yyyyMMdd_HHmm_");
        //        string status = string.Empty;
        //        if (ScenarioContext.Current.TestError != null)
        //        {
        //            status = "_failed";
        //        }
        //        else
        //        {
        //            status = "_passed";
        //        }

        //        strLog = strLog.Replace("\"", "").Replace(":", " ").Replace(".", " ").Replace(">", "-").Replace(",", " ");
        //        string filePath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName.ToString(), "tests", "files", "reports", "images", dt + strLog + status + ".PNG");
        //        Image img = GetEntireScreenshot();
        //        img.Save(filePath);

        //        return filePath;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }

        //}

        public void AcceptAlert()
        {
            try
            {
                SetUp.GetInstance().Driver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to accept alert Pop-Up.\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
            }
        }

        public void SendKeysInput(IWebElement element, string arg)
        {
            try
            {
                if ((element.GetAttribute("value") == null || element.GetAttribute("value") == "") && element.Displayed && element.Enabled)
                {
                    this.Highlight(element, true);
                    element.SendKeys(arg);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to send keys to element object.\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
            }

        }

        public void SendKeysInputTextOnly(IWebElement element, string arg)
        {
            try
            {

                var a = !Regex.IsMatch(element.GetAttribute("value"), "^[a-zA-Z ]+$");
                if (a && element.Displayed && element.Enabled)
                {
                    this.Highlight(element, true);
                    element.Clear();
                    element.SendKeys(arg);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("It was not possible to clear and send keys to element object.\n-----==========-----\nMessage: " + ex.Message + "\n-----==========-----");
            }
        }

        public bool CheckFile(string name) // the name of the zip file which is obtained, is passed in this method
        {
            string currentFile = string.Empty;
            currentFile = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName.ToString(), "tests", "files", "Downloads", name);

            if (File.Exists(currentFile)) //helps to check if the zip file is present
            {
                return true; //if the zip file exists return boolean true
            }
            else
            {
                return false; // if the zip file does not exist return boolean false
            }
        }

        public bool CheckFileDownloaded(string filename)
        {
            bool exist = false;
            string path = string.Empty;

            path = Path.Combine(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName.ToString(), "tests", "files", "Downloads");
            string[] filePaths = Directory.GetFiles(path);
            bool downloading = true;
            int count_tries = 0;
            while (downloading && count_tries < 30)
            {
                foreach (string p in filePaths)
                {
                    if (p.Contains(filename))
                    {

                        FileInfo thisFile = new FileInfo(p);
                        //Check the file that are downloaded in the last 3 minutes
                        if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                        thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                        thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                        thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                        {
                            downloading = false;
                            exist = true;
                        }
                        try
                        {
                            File.Delete(p);
                        }
                        catch { }

                        break;
                    }
                }
                Thread.Sleep(1000);
                count_tries++;
            }
            return exist;
        }
    }
}

