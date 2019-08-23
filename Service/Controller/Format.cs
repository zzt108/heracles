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
                if (decimal.TryParse(input, out var number))
                {
                    var rounded = Math.Round(number, rounding);
                    return number.ToString("# ##0.00");
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
