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

            // find the largest plot of where SAN and YOU match.


            var currentLevel = 1;
            var sum = 1;
            var orbitLevels = new Dictionary<string, int>();
            var plot = plots.First(p=>p.StartsWith("COM")).Split(')');
            orbitLevels.Add("COM", 0);
            orbitLevels.Add(plot[1], currentLevel);

            var subPlots = plots.Where(p => p.Split(')')[0] == plot[1]).Select(p=>p.Split(')')[1]).ToArray();

            while (subPlots.Count()>0)
            {
                currentLevel++;
                foreach (var item in subPlots)
                {
                    orbitLevels.Add(item, currentLevel);
                }
                //sum += currentLevel * subPlots.Count();
                subPlots = plots.Where(p => subPlots.Contains(p.Split(')')[0])).Select(p => p.Split(')')[1]).ToArray();
            }

            var listYou = new List<string>();
            plot = plots.First(p => p.EndsWith("YOU")).Split(')');
            
            do
            {
                listYou.Add(plot[1]);
                plot = plots.First(p => p.EndsWith(plot[0])).Split(')');
            } while (plot[0] != "COM");
            listYou.Add(plot[1]);
            listYou.Add("COM");

            var listSan = new List<string>();
            plot = plots.First(p => p.EndsWith("SAN")).Split(')');

            do
            {
                listSan.Add(plot[1]);
                plot = plots.First(p => p.EndsWith(plot[0])).Split(')');
            } while (plot[0] != "COM");
            listSan.Add(plot[1]);
            listSan.Add("COM");

            var intersect = "";
            // find first plot where they intersect going backwards
            foreach(var item in listYou)
            {
                if (listSan.Contains(item))
                {
                    intersect = item;
                    break;
                }
            }

            // now calculate
            orbitLevels.TryGetValue("YOU", out var youLevel);
            orbitLevels.TryGetValue("SAN", out var sanLevel);
            orbitLevels.TryGetValue(intersect, out var intersectLevel);



            Console.WriteLine(youLevel - 2 * intersectLevel + sanLevel - 2);
        }
    }
}
