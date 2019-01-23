using NumberToText.BO;
using NumberToText.Interface;
using NUnit.Framework;


namespace NumberToText.Test
{
    [TestFixture]
    class ApplyThousandsDigitRuleTest
    {
        private IConvertNumberManager<string, string> digitManager;

        [SetUp]
        public void Init()
        {
            digitManager = new ApplyThousandsDigitRule(new ApplyHundredsDigitRule());
        }

        [TestCase("1000")]
        public void ThousandsDigitRuleTest(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "one thousand");
        }


        [TestCase("9000")]
        public void ThousandsDigitRuleSecondTest(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "nine thousand");
        }

    }
}
