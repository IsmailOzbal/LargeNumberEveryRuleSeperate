using NumberToText.BO;
using NumberToText.Interface;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;


namespace NumberToText.Test
{
    [TestFixture]
    class ConvertNumberToTextManagerCheckRecombinationTest
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
            digitManager = new ConvertNumberToTextManager(initializeThreeDigitRule, _zeroRule,_negativeRule);
        }

        [TestCase("56945781")]
        public void TestRecombinationRuleDigitCount(string value)
        {
            var digitTest = digitManager.Manage(value);
            string[] array = digitTest.Split(',');
            Assert.AreEqual(3,array.Count());
        }

        [TestCase("56945781")]
        public void TestMillionRecombinationRuleValue(string value)
        {
            var digitTest = digitManager.Manage(value);
            string[] array = digitTest.Split(',');

            Assert.AreEqual("fifty six million", array[0].Trim());
            Assert.AreEqual("nine hundred and forty five thousand", array[1].Trim());
            Assert.AreEqual("seven hundred and eighty one", array[2].Trim());
        }

        [TestCase("5781")]
        public void TestThousandRecombinationRuleValue(string value)
        {
            var digitTest = digitManager.Manage(value);
            string[] array = digitTest.Split(',');

            Assert.AreEqual("five thousand", array[0].Trim());
            Assert.AreEqual("seven hundred and eighty one", array[1].Trim());
        }



    }
}
