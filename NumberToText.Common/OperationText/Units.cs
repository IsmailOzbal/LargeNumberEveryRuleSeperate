using System;

namespace NumberToText.Common
{
    public static class Units
    {
        public static string GetUnitsText(string number)
        {
            int _number = Convert.ToInt32(number);
            string returnValue = "";
            switch (_number)
            {

                case 1:
                    returnValue = "one";
                    break;
                case 2:
                    returnValue = "two";
                    break;
                case 3:
                    returnValue = "three";
                    break;
                case 4:
                    returnValue = "four";
                    break;
                case 5:
                    returnValue = "five";
                    break;
                case 6:
                    returnValue = "six";
                    break;
                case 7:
                    returnValue = "seven";
                    break;
                case 8:
                    returnValue = "eight";
                    break;
                case 9:
                    returnValue = "nine";
                    break;
            }
            return returnValue;
        }
    }
}
