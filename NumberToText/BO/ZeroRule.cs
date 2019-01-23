using NumberToText.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToText.BO
{
    public class ZeroRule : IConvertNumberManager<string, bool>
    {
        public bool Manage(string number)
        {
            int num = Convert.ToInt32(number);
            return num == 0 ? true : false;
        }
    }
}
