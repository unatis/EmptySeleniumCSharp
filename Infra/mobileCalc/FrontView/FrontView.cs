using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace mobileCalc.FrontView
{
    public class FrontView
    {
        /* @AndroidFindBy(accessibility = "2")//com.google.android.calculator:id/digit_2   //android.widget.ImageButton[@content-desc="2"]
     WebElement number_2_button;

         @AndroidFindBy(accessibility = "3")//com.google.android.calculator:id/digit_3  //android.widget.ImageButton[@content-desc="3"]
     WebElement number_3_button;

         @AndroidFindBy(accessibility = "equals")//com.google.android.calculator:id/eq  //android.widget.ImageButton[@content-desc="equals"]
     WebElement equalsButton3;

         @AndroidFindBy(accessibility = "No formula")//com.google.android.calculator:id/formula //android.widget.EditText[@content-desc="No formula"]
     WebElement textResult;
     */

        [FindsBy(How = How.Id, Using = "main")]
        private IWebElement mainPage;


        private Common.Common common = null;

        public FrontView(Common.Common commonObj)
        {
            common = commonObj;

        }

        public void clickNumber_2_Button()
        {

            try
            {
                common.GetWebDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByAccessibilityId.AccessibilityId("2"))).Click();
                //number_2_button.click();

            }
            catch (Exception e)
            {
                Common.Common.Report(e.Message, Common.Common.MessageColor.RED);
            }
        }

        public void clickNumber_3_Button()
        {

            try
            {
                common.GetWebDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByAccessibilityId.AccessibilityId("3"))).Click();

            }
            catch (Exception e)
            {
                Common.Common.Report(e.Message, Common.Common.MessageColor.RED);
            }
        }

        public void clickEqualsButton()
        {
            try
            {
                common.GetWebDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByAccessibilityId.AccessibilityId("equals"))).Click();

            }
            catch (Exception e)
            {
                Common.Common.Report(e.Message, Common.Common.MessageColor.RED);
            }
        }

        public void clickPlusButton()
        {
            try
            {
                common.GetWebDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByAccessibilityId.AccessibilityId("plus"))).Click();

            }
            catch (Exception e)
            {
                Common.Common.Report(e.Message, Common.Common.MessageColor.RED);
            }
        }

        public void verifyResultText(String expectedResult)
        {
            try
            {
                String foundResult = common.GetWebDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ByIdOrName.Id("com.google.android.calculator:id/result_final"))).Text;

                if (foundResult.Equals(expectedResult))
                {
                    Common.Common.Report("Found result \"" + foundResult + "\" is equals to expected \"" + foundResult + "\"");
                }
                else
                {
                    Common.Common.Report("Found result \"" + foundResult + "\" is Not equals to expected \"" + foundResult + "\"", Common.Common.MessageColor.RED);
                }

            }
            catch (Exception e)
            {
                Common.Common.Report(e.Message, Common.Common.MessageColor.RED);
            }

        }
    }
}