using System;
using System.IO;

namespace AOC
{
    class Program
    {
        public static int Calculate(int mass)
        {
            var sum = 0;
            do
            {
                mass = (mass / 3) - 2;
                sum += mass;

            } while (mass > 6);

            return sum;
        }


        static void Main(string[] args)
        {
            var testBase = @"h:\git\aoc\testfiles";
            var testData = Path.Combine(testBase, "puzzle02.txt");
            var numInArr = 100;
            var sum = 0;

            using (TextReader tr = new StreamReader(testData))
            {
                var puzzleArr = new int[numInArr];
                for (int i = 0; i < puzzleArr.Length; i++)
                {
                    puzzleArr[i] = int.Parse(tr.ReadLine());
                }

                foreach (var i in puzzleArr)
                {
                    sum += Calculate(i);
                }
                
            }

            Console.WriteLine(sum);

        }
    }
}
