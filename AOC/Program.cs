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

            var items = new List<int>();
            using (TextReader tr = new StreamReader(testData))
            {
                var value = tr.ReadLine();
                var arr = value.Split(',').Select(int.Parse).ToArray();
                // takes care of only opcode 3
                arr[arr[1]] = 5;


                //var arrTemp = new int[arr.Length];
                //Array.Copy(arr, arrTemp,arr.Length);

                var instructionIncrease = 2;
                for (var k = 2; k < arr.Length; k += instructionIncrease)
                {
                    var op = arr[k] % 100;

                    var idx1ByPos = (arr[k] / 100) % 10 == 0;
                    var idx2ByPos = (arr[k] / 1000) % 10 == 0;

                    if (op == 99)
                        break;
                    var param1 = arr[k + 1];
                    var param2 = arr[k + 2];
                    var param3 = 0;
                    var val1 = 0;
                    var val2 = 0;
                    if (op != 4)
                    {
                        param3 = arr[k + 3];
                        val1 = idx1ByPos ? arr[param1] : param1;
                        val2 = idx2ByPos ? arr[param2] : param2;
                    }

                    switch (op)
                    {
                        case 1:
                            arr[param3] = val1 + val2;
                            instructionIncrease = 4;
                            break;
                        case 2:
                            arr[param3] = val1 * val2;
                            instructionIncrease = 4;
                            break;
                        case 4:
                            // take next param and output
                            if (idx1ByPos)
                                Console.WriteLine(arr[param1]);
                            else
                                Console.WriteLine(param1);

                            instructionIncrease = 2;
                            break;
                        case 5:
                            instructionIncrease = 3;
                            if (val1 != 0)
                            {
                                instructionIncrease = 0;
                                k = val2;
                            }
                            break;
                        case 6:
                            instructionIncrease = 3;
                            if (val1==0)
                            {
                                instructionIncrease = 0;
                                k = val2;
                            }
                            break;
                        case 7:
                            arr[param3] = val1 < val2 ? 1 : 0;
                            instructionIncrease = 4;
                            break;
                        case 8:
                            arr[param3] = val1 == val2 ? 1 : 0;
                            instructionIncrease = 4;
                            break;

                    }
                }
            }
        }
    }
}
