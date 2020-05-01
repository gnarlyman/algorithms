using System;

namespace Chapter1
{
    public static class Program
    {
        public static void Main()
        {
            var f1 = FloatOperations.FromFloat(0.0000000123f);
            Console.WriteLine(f1);

            Console.WriteLine(f1.ToDecimal());
        }
    } 
}