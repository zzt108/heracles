using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public static class Format
    {
        public static string Money(string inputNumber, int rounding = 2)
        {
            var nfi = new System.Globalization.NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberGroupSeparator = " ",
                NumberDecimalDigits = rounding
            };

            if (decimal.TryParse(inputNumber, out var number))
            {
                var rounded = Math.Round(number, rounding);
                return number.ToString("N", nfi);
            }
            else
            {
                throw new ArgumentException($"Cannot parse '{inputNumber}'", nameof(inputNumber));
            }
        }
    }
}
