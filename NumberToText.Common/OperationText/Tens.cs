using System;


namespace NumberToText.Common
{
    public static class Tens
    {
        public static string GetTensText(string number)
        {
            string returnValue = null;
            int _number = Convert.ToInt32(number);
            switch (_number)
            {
                case 10:
                    returnValue = "ten";
                    break;
                case 11:
                    returnValue = "eleven";
                    break;
                case 12:
                    returnValue = "twelve";
                    break;
                case 13:
                    returnValue = "thirteen";
                    break;
                case 14:
                    returnValue = "fourteen";
                    break;
                case 15:
                    returnValue = "fifteen";
                    break;
                case 16:
                    returnValue = "sixteen";
                    break;
                case 17:
                    returnValue = "seventeen";
                    break;
                case 18:
                    returnValue = "eighteen";
                    break;
                case 19:
                    returnValue = "nineteen";
                    break;
                case 20:
                    returnValue = "twenty";
                    break;
                case 30:
                    returnValue = "thirty";
                    break;
                case 40:
                    returnValue = "forty";
                    break;
                case 50:
                    returnValue = "fifty";
                    break;
                case 60:
                    returnValue = "sixty";
                    break;
                case 70:
                    returnValue = "seventy";
                    break;
                case 80:
                    returnValue = "eighty";
                    break;
                case 90:
                    returnValue = "ninety";
                    break;
                default:
                    if (_number > 0)
                    {
                        returnValue = GetTensText(number.Substring(0, 1) + "0") + " " +
                                      Units.GetUnitsText(number.Substring(1));
                    }

                    break;
            }

            return returnValue;
        }
    }
}
