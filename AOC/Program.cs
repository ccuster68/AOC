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
            var testBase = @"h:\git\aoc\testfiles";
            var testData = Path.Combine(testBase, "d2p1O.txt");
            var sum = 0;

            var items = new List<int>();
            using (TextReader tr = new StreamReader(testData))
            {
                var value = tr.ReadLine();
                var arr = value.Split(',').Select(int.Parse).ToArray();

                var noun = 0;
                var verb = 0;
                
                for (int i = 0; i < 99; i++)
                {
                    for (int j = 0; j < 99; j++)
                    {
                        var arrTemp = new int[arr.Length];
                        Array.Copy(arr, arrTemp,arr.Length);

                        arrTemp[1] = i;
                        arrTemp[2] = j;
                        for (var k = 0; k < arrTemp.Length; k += 4)
                        {
                            var op = arrTemp[k];
                            if (op == 99)
                                break;
                            var idx1 = arrTemp[k + 1];
                            var idx2 = arrTemp[k + 2];
                            var idx3 = arrTemp[k + 3];

                            switch (op)
                            {
                                case 1:
                                    arrTemp[idx3] = arrTemp[idx1] + arrTemp[idx2];
                                    break;
                                case 2:
                                    arrTemp[idx3] = arrTemp[idx1] * arrTemp[idx2];
                                    break;
                            }

                        }

                        if (arrTemp[0] > 19690720)
                            break;
                        if (arrTemp[0] == 19690720)
                        {
                            noun = i;
                            verb = j;
                            break;
                        }

                        if (arrTemp[0] == 19690720)
                            break;
                    }
                }

                Console.WriteLine($"noun: {noun}, verb: {verb}");
                Console.WriteLine($"{100 * noun + verb}");
            }

            

        }
    }
}
