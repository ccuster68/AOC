using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC
{
    class Program
    {
        public static void calculate(int[] puzzleArr)
        {
            var sum = 0;
            foreach (var i in puzzleArr)
            {
                sum += (i / 3) - 2;
            }

            Console.WriteLine(sum);
        }


        static void Main(string[] args)
        {
            var testBase = @"h:\git\aoc\testfiles";
            var testData = Path.Combine(testBase, "puzzle01.txt");
            var numInArr = 100;
            

            using (TextReader tr = new StreamReader(testData))
            {
                var puzzleArr = new int[numInArr];
                for (int i = 0; i < puzzleArr.Length; i++)
                {
                    puzzleArr[i] = int.Parse(tr.ReadLine());
                }

                calculate(puzzleArr);
            }

        }
    }
}
