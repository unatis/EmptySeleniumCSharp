using Common;
using NUnit.Framework;
using System.Configuration;

namespace EmptySeleniumCSharp.tests.suites.sanity
{
    public class MobileTest
    {
        private static String deviceName = "";
        private static String deviceID = "";
        private static String packageName = "";
        private static String activityName = "";
        private static String platformVersion = "";

        private Common.Common common = new Common.Common();

        [SetUp]
        public void Setup()
        {
            deviceName = ConfigurationManager.AppSettings["deviceName"];
            deviceID = ConfigurationManager.AppSettings["deviceID"];
            packageName = ConfigurationManager.AppSettings["packageName"];
            activityName = ConfigurationManager.AppSettings["activityName"];
            platformVersion = ConfigurationManager.AppSettings["platformVersion"];

            common.LaunchEmulator("Pixel3aAPI30", "emulator-5554");
            common.await(80);

        }

        [Test]
        public void Test1()
        {
            common.LaunchApp(packageName, activityName, deviceName, deviceID, platformVersion);

            common.await(25);

            mobileCalc.FrontView.FrontView frontView = new mobileCalc.FrontView.FrontView(common);

            frontView.clickNumber_2_Button();

            frontView.clickPlusButton();

            frontView.clickNumber_3_Button();

            frontView.clickEqualsButton();

            common.await(2);

            frontView.verifyResultText("5");
        }

        [TearDown]
        public void TearDown()
        {
            common.closeApp();
            common.StopEmulator("emulator-5554");
        }
    }
}