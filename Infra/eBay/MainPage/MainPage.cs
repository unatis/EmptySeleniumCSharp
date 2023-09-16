using Common;
using OpenQA.Selenium;

namespace eBay.MainPage
{
    public class MainPage
    {
        public void Verify_Main_Page()
        {
            if (!IsElementPresent(By.Id("mainContent")))
            {
                Common.Common.Report("Main_Page not found", Common.Common.MessageColor.RED);
            }
        }

        public void Click_Search_Button()
        {
            try
            {
                GetCommon().GetWebDriver().FindElement(By.Id("search-icon-legacy")).Click();
            }
            catch (Exception e)
            {
                Common.Common.Report(e.Message, Common.Common.MessageColor.RED);
            }
        }
    }
}