using NumberToText.Common;
using NumberToText.Common.OperationText;
using NumberToText.Interface;
using System;
using System.Collections.Generic;

namespace NumberToText.BO
{
    public class ConvertNumberToTextManager : IConvertNumberManager<string, string>
    {
        private IWorkFlow<string, List<IConvertNumberManager<string, string>>> _initializeThreeDigitRule;
        private IConvertNumberManager<string, bool> _zeroRule;
        private IConvertNumberManager<string, bool> _negativeRule;

        public ConvertNumberToTextManager(IWorkFlow<string, List<IConvertNumberManager<string, string>>> initializeThreeDigitRule, IConvertNumberManager<string, bool> zeroRue, IConvertNumberManager<string, bool> negativeRule)
        {
            _initializeThreeDigitRule = initializeThreeDigitRule;
            _zeroRule = zeroRue;
            _negativeRule = negativeRule;
        }

        public string Manage(string number)
        {
            string returnValue = "";
            //Zero Control and Negative Control
            bool zeroControl = _zeroRule.Manage(number);
            bool negative = _negativeRule.Manage(number);

            returnValue = negative == true ? NegativeText.negativeText : "";

            if (!zeroControl)
            {
                number = negative == true ? (Convert.ToInt32(number) * -1).ToString() : number;
                //Retrieve Three Digit Rule Group
                var getThreeDigitsGroup = _initializeThreeDigitRule.Manage(number);
               
                //Apply Three Digit Rule Group
                foreach (var groups in getThreeDigitsGroup)
                {
                    //RecombinationRule apply
                    string retVal = groups.Manage(number);
                    returnValue += String.IsNullOrEmpty(retVal)!=true? retVal + DigitSeperateText.seperateText : "";
                }

                return  returnValue.Remove(returnValue.Length-2);
            }
            else
            {
                return ZeroText.zeroText;
            }
        
        }
    }
}
