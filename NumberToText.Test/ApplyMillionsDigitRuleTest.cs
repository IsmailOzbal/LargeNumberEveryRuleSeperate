using NumberToText.BO;
using NumberToText.Interface;
using NUnit.Framework;


namespace NumberToText.Test
{
    [TestFixture]
    class ApplyMillionsDigitRuleTest
    {
        private IConvertNumberManager<string, string> digitManager;

        [SetUp]
        public void Init()
        {
            digitManager = new ApplyMillionsDigitRule(new ApplyHundredsDigitRule());
        }


        [TestCase("1000000")]
        public void MillionsDigitRuleTest(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "one million");
        }


        [TestCase("8000000")]
        public void MillionsDigitRuleSecondTest(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "eight million");
        }

    }
}
