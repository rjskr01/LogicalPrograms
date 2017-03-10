using System;
using System.Diagnostics;

namespace SuperNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();
            watch.Start();
            var superNumbers = new int[9];
            for (int j = 2; j <= 9; j++)
            {
                superNumbers = new int[j];
                var possibilityCount = (int)Math.Pow(j, j);
                for (int i = 0; i < possibilityCount - 1; i++)
                {
                    incrementArray(superNumbers, superNumbers.Length - 1);
                    if (isSuperNumber(superNumbers))
                    {
                        foreach (int digit in superNumbers)
                            Console.Write(digit);
                        Console.WriteLine();
                    }
                }
            }

            Console.WriteLine("Elapsed Time (Seconds):"+watch.ElapsedMilliseconds/1000);
            Console.ReadLine();
        }
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
        public static bool isSuperNumber(int[] superNumbers)
        {
            var count = 0;
            var digitCount = superNumbers.Length;
            for (int index = 0; index < digitCount; index++)
            {
                count = 0;
                foreach (int digit in superNumbers)
                {
                    if (digit == index)
                        count++;
                }
                if (count != superNumbers[index])
                    return false;
            }
            return true;
        }
    }
}