using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Xml.Linq;

namespace youtube.MainPage
{
    public class MainPage
    {
        [FindsBy(How = How.Id, Using = "content")]
        private IWebElement mainPage;

        [FindsBy(How = How.Id, Using = "search-icon-legacy")]
        private IWebElement searchButton;

        [FindsBy(How = How.Name, Using = "search_query")]
        private IWebElement searchTexBox;


        private Common.Common common = null;


        public MainPage(Common.Common commonObj)
        {
            common = commonObj;
            //PageFactory.InitElements(common.GetWebDriver(), this);
        }

        public void Verify_Main_Page()
        {
            if (!common.IsElementPresent(By.Id("content")))
            {
                Common.Common.Report("Main_Page not found", Common.Common.MessageColor.RED);
            }
        }

        public void Click_Search_Button()
        {
            try
            {                
                common.GetWebDriver().FindElement(By.Id("search-icon-legacy")).Click();
            }
            catch (Exception e)
            {
                Common.Common.Report(e.Message, Common.Common.MessageColor.RED);
            }
        }

        public void Set_Search_Text(String SearchText)
        {
            try
            {
                IWebElement element = common.GetWebDriver().FindElement(By.Name("search_query"));
                element.Clear();
                element.SendKeys(SearchText);
            }
            catch (Exception e)
            {
                Common.Common.Report(e.Message, Common.Common.MessageColor.RED);
            }
        }
    }
}