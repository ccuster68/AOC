using System;

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
            var start = 138307;
            //start = 111122;
            var end = 654504;

            var answer = 0;

            for (int i = start; i < end; i++)
            {
                var s = i.ToString();
                var increase = true;
                for (int c = 1; c < 6; c++)
                {
                    if (s[c] < s[c - 1])
                    {
                        increase = false;
                        break;
                    }
                }

                if (!increase)
                    continue;

                for (int c = 1; c < 6; c++)
                {
                    var cont = false;
                    if (s[c] == s[c - 1])
                    {
                        while (c < 5 && s[c] == s[c + 1])
                        {
                            c++;
                            cont = true;
                        }


                        if (cont)
                            continue;


                        answer++;
                        break;

                    }
                }

            }

            Console.WriteLine($"{answer}");




        }
    }
}
