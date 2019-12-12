using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            var testBase = @"h:\git\aoc\testfiles";
            var testData = Path.Combine(testBase, "d5p1.txt");
            var sum = 0;

            var items = new List<int>();
            using (TextReader tr = new StreamReader(testData))
            {
                var value = tr.ReadLine();
                var arr = value.Split(',').Select(int.Parse).ToArray();
                // takes care of only opcode 3
                arr[arr[1]] = 1;


                //var arrTemp = new int[arr.Length];
                //Array.Copy(arr, arrTemp,arr.Length);

                var instructionIncrease = 2;
                for (var k = 2; k < arr.Length; k += instructionIncrease)
                {
                    var op = arr[k] % 100;
                    var idx1ByPos = true;
                    var idx2ByPos = true;
                    if (arr[k].ToString().Length > 2)
                        idx1ByPos = (arr[k] / 100) % 10 == 0;
                    idx2ByPos = (arr[k] / 1000) % 10 == 0;

                    if (op == 99)
                        break;
                    var idx1 = arr[k + 1];
                    var idx2 = arr[k + 2];
                    var idx3 = arr[k + 3];
                    var val1 = 0;
                    var val2 = 0;

                    switch (op)
                    {
                        case 1:
                            val1 = idx1ByPos ? arr[idx1] : idx1;
                            val2 = idx2ByPos ? arr[idx2] : idx2;
                            arr[idx3] = val1 + val2;
                            instructionIncrease = 4;
                            break;
                        case 2:
                            val1 = idx1ByPos ? arr[idx1] : idx1;
                            val2 = idx2ByPos ? arr[idx2] : idx2;
                            arr[idx3] = val1 * val2;
                            instructionIncrease = 4;
                            break;
                        case 4:
                            // take next param and output
                            if (idx1ByPos)
                                Console.WriteLine(arr[idx1]);
                            else
                                Console.WriteLine(idx1);

                            instructionIncrease = 2;
                            break;
                        case 8:
                            break;

                    }
                }
            }
        }
    }
}
