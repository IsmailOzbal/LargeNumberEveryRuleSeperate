using NumberToText.Common;
using NumberToText.Interface;
using System;

namespace NumberToText.BO
{
    public class ApplyMillionsDigitRule : IConvertNumberManager<string, string>
    {
        private IConvertNumberManager<string, string> _hundredDigitRule;
        public ApplyMillionsDigitRule(IConvertNumberManager<string, string> hundredDigitRule)
        {
            _hundredDigitRule = hundredDigitRule;
        }

        public string Manage(string num1)
        {
            int millions = (Convert.ToInt32(num1) / 1000000);
            var millionsGroup = millions % 1000;
            //Zero control
            return Convert.ToInt32(millionsGroup) != 0 ? _hundredDigitRule.Manage(millionsGroup.ToString()) + ThreeDigitText.millionText : "";

        }
    }
}
