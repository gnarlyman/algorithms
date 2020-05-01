using System;
using System.Globalization;

namespace Chapter1
{
    public static class ConvertBase
    {
        private static long GetValueFromString(string numberString, int baseSystem)
        {
            long multiplier = 1;
            long val = 0;
            for (var i = numberString.Length; i--> 0;) 
            {
                var iLong = long.Parse(numberString[i].ToString(), NumberStyles.HexNumber);
                if (iLong >= baseSystem)
                {
                    throw new Exception($"invalid source base {baseSystem} for {numberString}");
                }
                // Console.WriteLine($"numberString index {i}: {iLong}");
                val += iLong * multiplier;
                multiplier *= baseSystem;
            }

            return val;
        }

        private static string GetStringFromValue(long val, int baseSystem)
        {
            var quotient = val;
            var output = "";
            while (quotient > 0)
            {
                quotient = Math.DivRem(quotient, baseSystem, out var remainder);
                output = $"{remainder:X}{output}";
            }

            return output;
        }
        
        public static string ConvertBaseString(string numberString, int base1, int base2)
        {
            var val = GetValueFromString(numberString, base1);
            var newVal = GetStringFromValue(val, base2);
            return newVal;
        }
    }
}