using System;
using System.Data;
using System.Diagnostics;

namespace NumberPossiblities
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();
            watch.Start();

            var superNumbers = new int[9];
            int digitCount = 9;
            superNumbers = new int[digitCount];
            var possibilityCount = (int)Math.Pow(digitCount, digitCount);
            for (int i = 0; i < possibilityCount - 1; i++)
            {
                incrementArray(superNumbers, superNumbers.Length - 1);
            }
            Console.Write("Max Digit:");
            foreach (int digit in superNumbers)
                Console.Write(digit);

            Console.WriteLine("\nTotal Time:"+watch.Elapsed);
            Console.ReadLine();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="possibilities"></param>
        /// <param name="digitIndex"></param>
        public static void incrementArray(int[] possibilities, int digitIndex)
        {
            var tmp = 0;
            var digitCount = possibilities.Length;
            tmp = possibilities[digitIndex] + 1;
            if (tmp % digitCount == 0)
            {
                possibilities[digitIndex] = 0;
                incrementArray(possibilities, digitIndex - 1);
            }
            else
                possibilities[digitIndex] = tmp;
        }
    }
}