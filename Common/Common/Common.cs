using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

using System.Diagnostics;

namespace Common
{
    public class Common
    {
        public enum BrowserType
        {
            Chrome,
            FireFox,
            Edge
        }
        public enum MessageColor
        {
            RED,
            WHITE,
            YELLOW
        }

        private WebDriver webDriver;

        private WebDriverWait webDriverWait;

        private IWebDriver mDriver;


        public WebDriver GetWebDriver()
        {
            return webDriver;
        }

        public IWebDriver GetMobileDriver()
        {
            return mDriver;
        }

        public WebDriverWait GetWebDriverWait()
        {
            return webDriverWait;
        }

        public void LaunchBrowser(BrowserType browserType)
        {
            try
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        webDriver = new ChromeDriver();
                        break;
                    case BrowserType.FireFox:
                        webDriver = new FirefoxDriver();
                        break;
                    case BrowserType.Edge:
                        webDriver = new EdgeDriver();
                        break;
                    default:
                        webDriver = new ChromeDriver();
                        break;
                }


                webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                webDriver.Manage().Window.Maximize();
            }
            catch (Exception e)
            {
                Report(e.Message, MessageColor.RED);
            }
        }

        public void NivigateTo(String URL)
        {
            try
            {
                webDriver.Navigate().GoToUrl(URL);
            }
            catch (Exception e)
            {
                Report(e.Message, MessageColor.RED);
            }
        }

        public void CloseBrowser()
        {
            try
            {
                webDriver.Close();
            }
            catch (Exception e)
            {
                Report(e.Message, MessageColor.RED);
            }
        }

        public void ExitEnvironment()
        {

            try
            {
                webDriver.Quit();

            }
            catch (Exception e)
            {
                Report(e.Message, Common.MessageColor.RED);
            }

        }

        public void SwitchToWindow(String WindowTitle)
        {
            try
            {
                IList<String> widows = new List<String>(webDriver.WindowHandles);

                foreach (String window in widows)
                {

                    webDriver.SwitchTo().Window(window);

                    if (webDriver.Title.Trim().Contains(WindowTitle))
                    {
                        Report("Switch to " + WindowTitle + " succeed");
                        break;
                    }

                }

            }
            catch (Exception e)
            {
                Report(e.Message, Common.MessageColor.RED);
            }
        }

        public void await(int seconds)
        {
            Report("Waitinf for " + seconds + " seconds");
            Thread.Sleep(seconds * 1000);
        }

        public Boolean IsElementPresent(By locatorKey)
        {
            try
            {
                webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locatorKey));
                return true;
            }
            catch (Exception e)
            {                
                return false;
            }
        }

        public Boolean isElementVisible(String cssLocator)
        {
            return webDriver.FindElement(By.CssSelector(cssLocator)).Displayed;
        }

        public void LaunchEmulator(String DeviceName, String DeviceID)
        {
            try
            {

                String emulatorLocation = getAppLocation("emulator");

                var startInfo = new ProcessStartInfo();

                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.WorkingDirectory = emulatorLocation.Substring(0, emulatorLocation.LastIndexOf("\\"));
                processStartInfo.FileName = emulatorLocation;
                processStartInfo.Arguments = " -avd " + DeviceName;
                //processStartInfo.CreateNoWindow = true;
                Process myProcess = Process.Start(processStartInfo);

                Report("Emulator android running");
            }
            catch (Exception e)
            {

                Report(e.Message, MessageColor.RED);
            }

        }

        public void StopEmulator(String DeviceID)
        {

            try
            {
                String emulatorLocation = getAppLocation("emulator");

                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.WorkingDirectory = "C:" + Path.DirectorySeparatorChar + "Users" + Path.DirectorySeparatorChar + "ygpan" + Path.DirectorySeparatorChar + "AppData" + Path.DirectorySeparatorChar + "Local" + Path.DirectorySeparatorChar + "Android" + Path.DirectorySeparatorChar + "Sdk" + Path.DirectorySeparatorChar + "platform-tools";
                processStartInfo.FileName = "adb.exe";
                processStartInfo.Arguments = "-s " + DeviceID + " emu kill";
                //processStartInfo.CreateNoWindow = true;
                Process myProcess = Process.Start(processStartInfo);

                Report("Emulator android killed");
            }
            catch (Exception e)
            {

                Report(e.Message, MessageColor.RED);
            }

        }

        public void LaunchApp(String PackageName, String ActivityName, String DeviceName, String DeviceID, String PlatformVersion)
        {
            try
            {
                mDriver = null;

                String ApplicationPath = "";

                String version;

                Uri url = new Uri("http://127.0.0.1:4723/wd/hub");

                AppiumOptions options = new AppiumOptions();
                options.AddAdditionalCapability(MobileCapabilityType.DeviceName, DeviceName);
                options.AddAdditionalCapability(MobileCapabilityType.Udid, DeviceID);
                options.AddAdditionalCapability(MobileCapabilityType.PlatformName, MobilePlatform.Android);
                options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, PlatformVersion);
                //options.AddAdditionalCapability("ensureWebviewsHavePages", true);
                //options.AddAdditionalCapability("usePrebuiltWDA", true);

                options.AddAdditionalCapability(AndroidMobileCapabilityType.AvdLaunchTimeout, 180000);
                options.AddAdditionalCapability(AndroidMobileCapabilityType.AndroidDeviceReadyTimeout, 180);

                options.AddAdditionalCapability(MobileCapabilityType.NoReset, true);//clears the app data, such as its cache

                //options.AddAdditionalCapability(AndroidMobileCapabilityType.SYSTEM_PORT, String.valueOf(Port));
                options.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, 10800); //keep appium session alive for 3 hours (in seconds)
                options.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, PackageName);
                options.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, ActivityName);

                mDriver = new RemoteWebDriver(url, options);

                mDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            }
            catch (Exception ex)
            {
                Report(ex.Message, MessageColor.RED);
            }
        }

        public void closeApp()
        {
            try
            {
                if (mDriver!=null)
                {
                    mDriver.Quit();
                }
            }
            catch (Exception ex)
            {
                Report(ex.Message, MessageColor.RED);
            }
        }

        public static void Report(String message)
        {
            Console.WriteLine(message);
        }

        public static void Report(String message, MessageColor outputColor)
        {
            if (outputColor.Equals(MessageColor.RED))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }

            Assert.IsTrue(false, message);
        }

        private static String getAppLocation(String AppName)
        {
            String tmp = "";

            try
            {

                switch (AppName)
                {
                    case "appium":
                        //tmp = "/usr/local/bin/appium";
                        break;
                    case "emulator":
                        tmp = "C:" + Path.DirectorySeparatorChar + "Documents and Settings" + Path.DirectorySeparatorChar + "ygpan" + Path.DirectorySeparatorChar + "AppData" + Path.DirectorySeparatorChar + "Local" + Path.DirectorySeparatorChar + "Android" + Path.DirectorySeparatorChar + "Sdk" + Path.DirectorySeparatorChar + "emulator" + Path.DirectorySeparatorChar + "emulator.exe";
                        break;
                    case "adb":
                        //tmp = System.getProperty("user.home") + "/Library/Android/sdk/platform-tools/adb";
                        break;
                }

            }
            catch (Exception e)
            {
                Report(e.Message, MessageColor.RED);
            }

            return tmp;
        }
    }
}