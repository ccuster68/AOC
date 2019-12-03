using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC
{
    class Program
    {
        public static bool[,] FillArray(string[] wire, (int x, int y) maxXY, int offsetX, int offsetY, Dictionary<string, int> dicDist)
        {

            var w = new bool[maxXY.x, maxXY.y];
            var currentX = offsetX;
            var currentY = offsetY;
            var ttlDist = 0;

            foreach (var s in wire)
            {
                var direction = s.Substring(0, 1);
                var distance = int.Parse(s.Substring(1, s.Length - 1));

                switch (direction)
                {
                    case "R":
                        for (int x = currentX + 1; x < currentX + 1 + distance; x++)
                        {
                            w[x, currentY] = true;
                            ttlDist++;
                            if (!dicDist.ContainsKey($"{x}-{currentY}"))
                                dicDist.Add($"{x}-{currentY}", ttlDist);
                        }
                        currentX += distance;

                        break;
                    case "L":
                        for (int x = currentX - 1; x > currentX - 1 - distance; x--)
                        {
                            w[x, currentY] = true;
                            ttlDist++;
                            if (!dicDist.ContainsKey($"{x}-{currentY}"))
                                dicDist.Add($"{x}-{currentY}", ttlDist);
                        }
                        currentX -= distance;
                        break;
                    case "U":
                        for (int y = currentY + 1; y < currentY + 1 + distance; y++)
                        {
                            w[currentX, y] = true;
                            ttlDist++;
                            if (!dicDist.ContainsKey($"{currentX}-{y}"))
                                dicDist.Add($"{currentX}-{y}", ttlDist);
                        }
                        currentY += distance;
                        break;
                    case "D":
                        for (int y = currentY - 1; y > currentY - 1 - distance; y--)
                        {
                            w[currentX, y] = true;
                            ttlDist++;
                            if (!dicDist.ContainsKey($"{currentX}-{y}"))
                                dicDist.Add($"{currentX}-{y}", ttlDist);
                        }
                        currentY -= distance;
                        break;
                }


            }

            return w;
        }

        static (int x, int y) getMaxDistance(string[] w)
        {
            var bigX = 0;
            var bigY = 0;
            var currentX = 0;
            var currentY = 0;

            foreach (var s in w)
            {
                var direction = s.Substring(0, 1);
                var distance = int.Parse(s.Substring(1, s.Length - 1));

                switch (direction)
                {
                    case "R":
                        currentX += distance;
                        break;
                    case "L":
                        currentX -= distance;
                        break;
                    case "U":
                        currentY += distance;
                        break;
                    case "D":
                        currentY -= distance;
                        break;
                }

                bigX = Math.Max(bigX, Math.Abs(currentX));
                bigY = Math.Max(bigY, Math.Abs(currentY));
            }

            return (bigX + 1, bigY + 1);
        }



        static void Main(string[] args)
        {
            var testData = "D3P1O.txt";
            var testBase = @"h:\git\aoc\testfiles";

            var answer = 0;

            using (TextReader tr = new StreamReader(Path.Combine(testBase, testData)))
            {
                var value = tr.ReadLine();
                var wire1 = value.Split(',').ToArray();
                value = tr.ReadLine();
                var wire2 = value.Split(',').ToArray();

                var w1XY = getMaxDistance(wire1);
                var w2XY = getMaxDistance(wire2);


                var offsetX = Math.Max(w1XY.x, w2XY.x) * 2;
                var offsetY = Math.Max(w1XY.y, w2XY.y) * 2;

                w1XY.x += offsetX;
                w1XY.y += offsetY;
                w2XY.x += offsetX;
                w2XY.y += offsetY;

                var w1DicDist = new Dictionary<string, int>();
                var w2DicDist = new Dictionary<string, int>();
                var w1 = FillArray(wire1, w1XY, offsetX, offsetY, w1DicDist);
                var w2 = FillArray(wire2, w2XY, offsetX, offsetY, w2DicDist);


                var minDist = int.MaxValue;
                for (var X = 0; X < Math.Min(w1XY.x, w2XY.x); X++)
                {
                    for (var Y = 0; Y < Math.Min(w1XY.y, w2XY.y); Y++)
                    {

                        if (w1[X, Y] && w2[X, Y])
                        {
                            var w1Dist = int.MaxValue;
                            var w2Dist = int.MaxValue;
                            w1DicDist.TryGetValue($"{X}-{Y}", out w1Dist);
                            w2DicDist.TryGetValue($"{X}-{Y}", out w2Dist);
                            minDist = Math.Min(w1Dist + w2Dist, minDist);
                        }
                    }
                }


                Console.WriteLine($"{minDist}");
            }



        }
    }
}
