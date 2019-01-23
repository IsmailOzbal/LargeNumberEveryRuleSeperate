using NumberToText.BO;
using NumberToText.Interface;
using NUnit.Framework;
using System.Collections.Generic;


namespace NumberToText.Test
{
    [TestFixture]
    class ConvertNumberToTextManagerCheckNegativeTest
    {
        private IConvertNumberManager<string, string> digitManager;
        private IWorkFlow<string, List<IConvertNumberManager<string, string>>> initializeThreeDigitRule;
        private IConvertNumberManager<string, string> _hundredRule;
        private IConvertNumberManager<string, bool> _zeroRule;
        private IConvertNumberManager<string, bool> _negativeRule;
        [SetUp]
        public void Init()
        {
            _hundredRule = new ApplyHundredsDigitRule();
            initializeThreeDigitRule = new InitializeThreeDigitRule(_hundredRule);
            _zeroRule = new ZeroRule();
            _negativeRule = new NegativeRule();
            digitManager = new ConvertNumberToTextManager(initializeThreeDigitRule, _zeroRule, _negativeRule);
        }

        [TestCase("-009")]
        public void TestUnitsNegative(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "negative nine");
        }

        [TestCase("-034")]
        public void TestTensNegative(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "negative thirty four");
        }

        [TestCase("-134")]
        public void TestHundredDigitNegative(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "negative one hundred and thirty four");
        }

        [TestCase("-1234")]
        public void TestThousandDigitNegative(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "negative one thousand, two hundred and thirty four");
        }

        [TestCase("-70000057")]
        public void TestMillionDigitNegatives(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "negative seventy million, fifty seven");
        }
    }
}
