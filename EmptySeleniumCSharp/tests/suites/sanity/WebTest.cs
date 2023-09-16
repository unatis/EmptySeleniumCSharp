using Common;
using NUnit.Framework;


namespace EmptySeleniumCSharp.tests.suites.sanity
{
    [Parallelizable(ParallelScope.Self)]
    public class WebTest
    {
        private Common.Common common = new Common.Common();

        [SetUp]
        public void Setup()
        {
            common.LaunchBrowser(Common.Common.BrowserType.FireFox);
        }

        [Test]
        public void Test1()
        {
            common.NivigateTo("http://qadocs.com/");

            common.await(5);
                        
            qadocsCom.MainPage.MainPage mainPage = new qadocsCom.MainPage.MainPage(common);

            mainPage.Verify_Main_Page();

            mainPage.Click_LetsBegin_Button();

            common.await(5);
        }

        [Test]
        public void Test2()
        {
            common.NivigateTo("https://www.youtube.com/");

            common.await(5);

            youtube.MainPage.MainPage mainPage = new youtube.MainPage.MainPage(common);

            mainPage.Verify_Main_Page();

            mainPage.Set_Search_Text("hello");

            mainPage.Click_Search_Button();

            common.await(5);
        }


        [Test]
        public void eBay()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            common.ExitEnvironment();
        }
    }
}