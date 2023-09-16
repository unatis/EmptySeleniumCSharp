using Common;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace qadocsCom.MainPage
{
    public class MainPage
    {
        [FindsBy(How = How.TagName, Using = "main")]
        private IWebElement mainPage;

        [FindsBy(How = How.Id, Using = "letsbeginwork")]
        private IWebElement letsBeginButton;


        private Common.Common common = null;

        public MainPage(Common.Common commonObj)
        {
            common = commonObj;
            //PageFactory.InitElements(common.GetWebDriver(), this);
        }

        public void Verify_Main_Page()
        {
            if(!common.IsElementPresent(By.TagName("main")))
            {
                Common.Common.Report("Main_Page not found", Common.Common.MessageColor.RED);
            }            
        }

        public void Click_LetsBegin_Button()
        {
            try
            {
                //letsBeginButton.Click();
                common.GetWebDriver().FindElement(By.Id("letsbeginwork")).Click();
            }
            catch (Exception e)
            {
                Common.Common.Report(e.Message, Common.Common.MessageColor.RED);
            }
        }
    }
}
