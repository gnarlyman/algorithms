using System;
using System.Linq;
using System.Text;

namespace Chapter1
{
    public static class FloatOperations
    {
        /*
         * Write a series of functions for calculating addition, subtraction, multiplication,
         *     and division using IEEE-style floating-point numbers.
         * Represent the floats as 32-bit strings (or arrays) of 1s and 0s.
         * 
         * Each function should take two floating-point numbers and return another.
         * Don’t forget the special case when the exponent is zero.
         * You will probably find division to be the most difficult case.
         */

        public readonly struct Float32
        {
            private readonly bool[] _bits;

            public Float32(bool[] bits)
            {
                _bits = bits;
                if (Math.Abs(_bits.Length - 32) > 0)
                {
                    throw new Exception($"invalid binary length: {_bits.Length}");
                }
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                foreach (var b in _bits)
                {
                    sb.Append(b ? "1" : "0");
                }

                return sb.ToString();
            }


            public float ToDecimal()
            {
                var sign = _bits.Take(1).First() ? -1 : 1;
                var exponent = _bits.Skip(1).Take(8).ToArray();
                var mantissa = _bits.Skip(9).ToArray();
                
                
                var lcd = 0;
                var numerator = 0f;
                for (var i = mantissa.Length; i --> 0;)
                {
                    if (!mantissa[i]) continue;
                
                    // get least common denominator
                    if (lcd == 0)
                    {
                        lcd = (int) Math.Pow(2, i+1);
                        numerator += 1;
                        Console.WriteLine($"LCD: {lcd}");
                    }
                    else
                    {
                        numerator += lcd / (float) Math.Pow(2, i+1);
                    }
                }
                
                // add denominator to numerator 
                numerator += lcd;
                
                // apply exponent to numerator
                var multiplier = 1;
                var exp = 0;
                for (var i = exponent.Length; i --> 0;)
                {
                    var t = exponent[i] ? 1 : 0;
                    exp += t * multiplier;
                    multiplier *= 2;
                }
                
                // account for 255 based storage
                exp -= 127;
                
                Console.WriteLine($"Exponent: {exp}");
                
                numerator *= (float)Math.Pow(2, exp);
                
                Console.WriteLine($"Numerator: {numerator}");
                
                return  numerator / lcd * sign;
            }
        }

        private static string WholeToBinary(int n)
        {
            var quotient = n;
            var output = "";
            while (quotient > 0)
            {
                quotient = Math.DivRem(quotient, 2, out var remainder);
                output = $"{remainder:X}{output}";
            }

            return output;
        }

        public static bool[] ConvertFloatToArray(float f)
        {
            var ba = BitConverter.GetBytes(f);
            var arrBits = new bool[32];
            var c = 3;
            foreach (var b in ba)
            {
                var d = 7;
                for (var i = 0; i < 8; i++)
                {
                    var r = ((b >> d) & 1) == 1;
                    var newIndex = c * 8 + i;
                    // Console.WriteLine($"Byte:{b} Index:{newIndex} D:{d} C:{c} Bool:{r}");
                    arrBits[newIndex] = r;

                    d--;
                }

                c--;
            }

            return arrBits;
        }

        public static Float32 FromFloat(float f)
        {
            var arrBits = ConvertFloatToArray(f);
            return new Float32(arrBits);
        }
        
    }
}