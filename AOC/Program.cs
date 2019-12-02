using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            var testData = Path.Combine(testBase, "d2p1O.txt");
            var sum = 0;

            var items = new List<int>();
            using (TextReader tr = new StreamReader(testData))
            {
                var value = tr.ReadLine();
                var arr = value.Split(',').Select(int.Parse).ToArray();
                arr[1] = 12;
                arr[2] = 2;
                for (var i = 0; i < arr.Length; i += 4)
                {
                    var op = arr[i];
                    if (op == 99)
                        break;
                    var idx1 = arr[i + 1];
                    var idx2 = arr[i + 2];
                    var idx3 = arr[i + 3];

                    switch (op)
                    {
                        case 1:
                            arr[idx3] = arr[idx1] + arr[idx2];
                            break;
                        case 2:
                            arr[idx3] = arr[idx1] * arr[idx2];
                            break;
                    }

                }

                for (int i = 0; i < arr.Length; i++)
                {
                    var toWrite= i == arr.Length - 1? $"{arr[i]}": $"{arr[i]},";
                    Console.Write(toWrite);
                }

                Console.WriteLine();
            }

            

        }
    }
}
