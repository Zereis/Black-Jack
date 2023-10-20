using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesLib
{
    public class Utility
    {
        public int StringToInt(string stringsToInteger)
        {
            int integer = int.Parse(stringsToInteger);

            return integer;
        }

        public decimal StringToDecimal(string stringToDecimal)
        {
            decimal dec = decimal.Parse(stringToDecimal);

            return dec;
        }

        public bool CheckStringToInt(string checkStringInteger, int lowLimit, int highLimit)
        {
            int test = int.Parse(checkStringInteger);
 

            // If the test is between lowLimit and highLimit return true else false
            if (test >= lowLimit && test <= highLimit)
            {
                return true;
            }
            else
                return false;
        }
    }

}
