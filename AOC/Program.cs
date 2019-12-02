using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

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
            var testData = "Test01.txt";
            var testBase = @"h:\git\aoc\testfiles";
            
            var answer = 0;

            using (TextReader tr = new StreamReader(Path.Combine(testBase, testData)))
            {
                var value = tr.ReadToEnd();
                var arr = value.Split('\n').Select(int.Parse).ToArray();
                
                
                Console.WriteLine($"{answer}");
            }

            

        }
    }
}
