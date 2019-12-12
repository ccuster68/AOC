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
            var testData = Path.Combine(testBase, "D6.txt");
            var plots = new List<string>();
            using (TextReader tr = new StreamReader(testData))
            {
                var value = tr.ReadLine();
                while(value!=null)
                {
                    plots.Add(value);
                    value = tr.ReadLine();
                }
            }

            var currentLevel = 1;
            var sum = 1;
            var orbitLevels = new Dictionary<string, int>();
            var plot = plots.First(p=>p.StartsWith("COM")).Split(')');
            orbitLevels.Add(plot[1], currentLevel);

            var subPlots = plots.Where(p => p.Split(')')[0] == plot[1]).Select(p=>p.Split(')')[1]).ToArray();

            while (subPlots.Count()>0)
            {
                currentLevel++;
                sum += currentLevel * subPlots.Count();
                subPlots = plots.Where(p => subPlots.Contains(p.Split(')')[0])).Select(p => p.Split(')')[1]).ToArray();
            }
            



            
            Console.WriteLine(sum);
        }
    }
}
