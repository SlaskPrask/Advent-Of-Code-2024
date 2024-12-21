using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoCR.Utils;

namespace AoCR._2024
{
    public static class _1
    {
        public static string Solve1(string[] input)
        {
            List<long> left = new List<long>();
            List<long> right = new List<long>();

            foreach (string line in input)
            {
                string[] parts = line.Split(" ");
                left.Add(long.Parse(parts[0]));
                right.Add(long.Parse(parts[3]));
            }
            left.Sort();
            right.Sort();

            long res = 0;
            for (int i = 0; i < left.Count; i++)
            {
                res += Math.Abs(left[i] - right[i]);
            }

            return res.ToString();
        }

        public static string Solve2(string[] input)
        {
            Dictionary<long, int> left = new();
            Dictionary<long, int> right = new();
            
            foreach (string line in input)
            {
                string[] parts = line.Split(" ");
                int x = int.Parse(parts[0]);
                int y = int.Parse(parts[3]);

                if (!left.ContainsKey(x))
                {
                    left.Add(x, 0);
                }

                if (!right.ContainsKey(y))
                {
                    right.Add(y, 0);
                }

                left[x]++;
                right[y]++;
            }

            long res = 0;
            foreach (var kvp in left)
            {
                if (right.ContainsKey(kvp.Key))
                {
                    res += kvp.Key * kvp.Value * right[kvp.Key];
                }
            }

            return res.ToString();
        }

        public static string[] Day1()
        {
            string[] input = Input.GetRealInput();

            string res1 = Solve1(input);
            string res2 = Solve2(input);

            return new string[] { res1, res2 };
        }
    }
}
