using NUnit.Framework;


namespace EmptySeleniumCSharp.tests.suites.sanity
{
    public class YouTubeTest
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
            common.NivigateTo("https://www.youtube.com/");

            common.await(5);

            youtube.MainPage.MainPage mainPage = new youtube.MainPage.MainPage(common);

            mainPage.Verify_Main_Page();

            mainPage.Set_Search_Text("hello");

            mainPage.Click_Search_Button();

            common.await(5);
        }

        [TearDown]
        public void TearDown()
        {
            common.ExitEnvironment();
        }
    }
}