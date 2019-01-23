using NumberToText.BO;
using NumberToText.Interface;
using NUnit.Framework;


namespace NumberToText.Test
{
    [TestFixture]
    class ApplyHundredsDigitRuleTest
    {
        private IConvertNumberManager<string, string> digitManager;

        [SetUp]
        public void Init()
        {
            digitManager = new ApplyHundredsDigitRule();
        }

        [TestCase("425")]
        public void HundredsDigitRuleTest(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "four hundred and twenty five");           
        }

        [TestCase("021")]
        public void HundredsDigitRuleStartWithZeroTenTest(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "twenty one");
        }

        [TestCase("005")]
        public void HundredsDigitRuleStartWithZeroUnitTest(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "five");
        }

    }
}
