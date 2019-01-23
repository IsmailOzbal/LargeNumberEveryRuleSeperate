using NumberToText.Common;
using NumberToText.Interface;
using System;

namespace NumberToText.BO
{
    public class ApplyHundredsDigitRule : IConvertNumberManager<string, string>
    {
        public string Manage(string number)
        {
            number = (Convert.ToInt32(number) % 1000).ToString();

            string hundredDigits = (Convert.ToInt32(number) / 100).ToString();
            string tenDigits = (Convert.ToInt32(number) % 100).ToString();
            string unitDigits = (Convert.ToInt32(number) % 10).ToString();

            if (Convert.ToInt32(hundredDigits) == 0 && Convert.ToInt32(tenDigits) > 10)
            {
                return FindHundredText(Convert.ToInt32(number)) + Tens.GetTensText(tenDigits);
            }
            else if (Convert.ToInt32(hundredDigits) > 0)
            {
                return FindHundredText(Convert.ToInt32(number)) + " and " + Tens.GetTensText(tenDigits);
            }
            else
            {
                return FindHundredText(Convert.ToInt32(number)) + Units.GetUnitsText(unitDigits);
            }

        }

        private string FindHundredText(int number)
        {
            int value = number / 100;
            if (value > 0)
            {
                return Units.GetUnitsText(value.ToString()) + ThreeDigitText.hundredText;
            }
            else
            {
                return "";
            }
        }
    }
}
