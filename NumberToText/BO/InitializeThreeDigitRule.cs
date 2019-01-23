using NumberToText.Common.Enums;
using NumberToText.Interface;
using System.Collections.Generic;

namespace NumberToText.BO
{
    public class InitializeThreeDigitRule : IWorkFlow<string, List<IConvertNumberManager<string, string>>>
    {
        private readonly List<IConvertNumberManager<string, string>> _workList;
        private IConvertNumberManager<string, string> _hundredDigitRule;

        public InitializeThreeDigitRule(IConvertNumberManager<string, string> hundredDigitRule)
        {
            _hundredDigitRule = hundredDigitRule;
            _workList = new List<IConvertNumberManager<string, string>>();
        }

        public List<IConvertNumberManager<string, string>> Manage(string number)
        {

            //Three Digit Rules will be passed into the workflow, million, thousand and hundred respectively.
            if (number.Length > (int)ThreeDigitRuleEnum.ThreeDigitRule.MillionCondition)
            {
                _workList.Add(new ApplyMillionsDigitRule(_hundredDigitRule));
            }
            if (number.Length > (int)ThreeDigitRuleEnum.ThreeDigitRule.ThousandCondition)
            {
                _workList.Add(new ApplyThousandsDigitRule(_hundredDigitRule));
            }

            _workList.Add(new ApplyHundredsDigitRule());


            return _workList;
        }

    }
}



