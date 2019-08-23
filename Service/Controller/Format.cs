using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public static class Format
    {
        public static string Money(string input, int rounding = 2)
        {
            try
            {
                var nfi = new System.Globalization.NumberFormatInfo
                {
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = " ",
                    NumberDecimalDigits = rounding
                };

                if (decimal.TryParse(input, out var number))
                {
                    var rounded = Math.Round(number, rounding);
                    return number.ToString("N", nfi);
                }
                else
                {
                    throw new ArgumentException($"Cannot parse '{input}'", nameof(input));
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, nameof(input));
            }
        }
    }
}
