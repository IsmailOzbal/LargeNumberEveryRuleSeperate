using NumberToText.BO;
using NumberToText.Interface;
using NUnit.Framework;
using System.Collections.Generic;


namespace NumberToText.Test
{
    [TestFixture]
    class ConvertNumberToTextManagerTest
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

        [TestCase("001")]
        public void TestUnitsRule(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "one");
        }

        [TestCase("048")]
        public void TestTensRule(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "forty eight");
        }

        [TestCase("745")]
        public void TestHundredsRule(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "seven hundred and forty five");
        }

        [TestCase("1945")]
        public void TestThousandsRule(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "one thousand, nine hundred and forty five");
        }

        [TestCase("7855")]
        public void SecondTestThousandsRule(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "seven thousand, eight hundred and fifty five");
        }

        [TestCase("1005")]
        public void TestThousandsRuleUnits(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "one thousand, five");
        }

        [TestCase("1065")]
        public void TestThousandsRuleTens(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "one thousand, sixty five");
        }

        [TestCase("56945781")]
        public void TestMillionsRule(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "fifty six million, nine hundred and forty five thousand, seven hundred and eighty one");
        }

        [TestCase("5000008")]
        public void TestMillionsRuleUnits(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "five million, eight");
        }

        [TestCase("70000057")]
        public void TestMillionsRuleTens(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "seventy million, fifty seven");
        }

        [TestCase("80000657")]
        public void TestMillionsRuleHundreds(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "eighty million, six hundred and fifty seven");
        }

        [TestCase("80005657")]
        public void TestMillionsRuleThousands(string value)
        {
            var digitTest = digitManager.Manage(value);
            Assert.AreEqual(digitTest, "eighty million, five thousand, six hundred and fifty seven");
        }

    }
}
