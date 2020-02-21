using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalClockLibrary
{
    public class RomanNumeral
    {
        private uint _number;

        public RomanNumeral(uint number)
        {
            _number = number;
        }

        public string Roman
        {
            get
            {
                return GetRomanValue(_number);
            }
        }

        public static string GetRomanValue(uint number)
        {
            StringBuilder val = new StringBuilder();

            while (number / 1000 > 0)
            {
                val.Append("M");
                number -= 1000;
            }
            while (number / 900 > 0)
            {
                val.Append("CM");
                number -= 900;
            }
            while (number / 500 > 0)
            {
                val.Append("D");
                number -= 500;
            }
            while (number / 100 > 0)
            {
                val.Append("C");
                number -= 100;
            }
            while (number / 90 > 0)
            {
                val.Append("XC");
                number -= 90;
            }
            while (number / 50 > 0)
            {
                val.Append("L");
                number -= 50;
            }
            while (number / 40 > 0)
            {
                val.Append("XL");
                number -= 40;
            }
            while (number / 10 > 0)
            {
                val.Append("X");
                number -= 10;
            }
            while (number / 9 > 0)
            {
                val.Append("IX");
                number -= 9;
            }
            while (number / 5 > 0)
            {
                val.Append("V");
                number -= 5;
            }
            while(number / 4 > 0)
            {
                val.Append("IV");
                number -= 4;
            }
            while (number / 1 > 0)
            {
                val.Append("I");
                number -= 1;
            }

            return val.ToString();
        }

        private string GetRomanValueInternal(uint number)
        {
            return RomanNumeral.GetRomanValue(number);
        }
    }
}
