using NumberToText.BO;
using NumberToText.Interface;
using NUnit.Framework;
using System.Collections.Generic;


namespace NumberToText.Test
{
    [TestFixture]
    class ConvertNumberToTextManagerCheckZeroTest
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

        [TestCase("000")]
        public void TestHundredDigitZero(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "zero");
        }

        [TestCase("0000")]
        public void TestThousandDigitZero(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "zero");
        }

        [TestCase("0000000")]
        public void TestMillionDigitZero(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "zero");
        }

    }
}
