using NumberToText.Common;
using NumberToText.Interface;
using System;

namespace NumberToText.BO
{
    public class ApplyThousandsDigitRule : IConvertNumberManager<string, string>
    {
        private IConvertNumberManager<string, string> _hundredDigitRule;

        public ApplyThousandsDigitRule(IConvertNumberManager<string, string> hundredDigitRule)
        {
            _hundredDigitRule = hundredDigitRule;
        }

        public string Manage(string num1)
        {
            int thousands = (Convert.ToInt32(num1) / 1000);
            var thousandGroup = thousands % 1000;
            //Zero control
            return Convert.ToInt32(thousandGroup) != 0 ? _hundredDigitRule.Manage(thousandGroup.ToString()) + ThreeDigitText.thousandText : "";

        }
    }
}
