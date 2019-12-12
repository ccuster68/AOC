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
            var testData = Path.Combine(testBase, "testd7.txt");

            var origList = new List<int>();
            using (TextReader tr = new StreamReader(testData))
            {
                var value = tr.ReadLine();
                origList = value.Split(',').Select(int.Parse).ToList();
            }


            // loop
            // create all combinations of inputs
            int[] numbers = new[]
            {
                0, 1, 2, 3, 4
            };
            var permutations = new List<string>();
            Permute(numbers, permutations);


            var copyArr = new int[origList.Count];
            origList.CopyTo(copyArr);

            // takes care of only opcode 3
            origList[origList[1]] = 5;

            ProcessAmp(copyArr, 1, 1);

        }
        
        public static void Permute<T>(T[] items, List<string> output)
        {
            Permute(items, 0, new T[items.Length], new bool[items.Length], output);
        }
        private static void Permute<T>(T[] items, int item, T[] permutation, bool[] used, List<string> output)
        {
            for (int i = 0; i < items.Length; ++i)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutation[item] = items[i];

                    if (item < (items.Length - 1))
                    {
                        Permute(items, item + 1, permutation, used, output);
                    }
                    else
                    {
                        output.Add(string.Join(",", permutation));
                    }

                    used[i] = false;
                }
            }
        }
        private static int ProcessAmp(int[] arr, int input1, int input2)
        {
            var instructionIncrease = 2;
            var isInput1 = true;
            for (var k = 0; k < arr.Length; k += instructionIncrease)
            {
                var op = arr[k] % 100;

                var idx1ByPos = (arr[k] / 100) % 10 == 0;
                var idx2ByPos = (arr[k] / 1000) % 10 == 0;

                if (op == 99)
                    break;
                var param1 = arr[k + 1];
                var param2 = 0;
                var param3 = 0;
                var val1 = 0;
                var val2 = 0;
                if (op != 4 && op != 3)
                {
                    param3 = arr[k + 3];
                    param2 = arr[k + 2];
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
                    case 3:
                        arr[param1] = isInput1 ? input1 : input2;
                        isInput1 = false;
                        instructionIncrease = 2;
                        break;
                    case 4:
                        // take next param and output
                        if (idx1ByPos)
                            return arr[param1];
                        else
                            return param1;
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
                        if (val1 == 0)
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
            return 0;
        }
    }
}
