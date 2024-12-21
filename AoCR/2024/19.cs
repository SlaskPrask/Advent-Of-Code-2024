using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCR.Old
{
    public static class _19
    {
        class Node
        {
            public string value;
            public Node parent;
            public List<Node> children;
            public int count;
        }

        public static long Solve(string towel, List<string> towels)
        {

            List<long> designPatterns = new List<long>(new long[towel.Length + 1]);
            designPatterns[0] = 1;

            for (int i = 1;  i <= towel.Length; i++)
            {
                foreach (var pattern in towels)
                {
                    int size = pattern.Length;
                    if (i >= size && towel.Substring(i - size, size) == pattern)
                    {
                        designPatterns[i] += designPatterns[i - size];
                    }
                }
            }

            return designPatterns[towel.Length];
        }
        public static string Day19()
        {
            string[] input = File.ReadAllLines("../../../Input.txt");

            List<string> towels = new List<string>();
            string[] data = input[0].Split(", ");

            foreach (string s in data)
            {

                towels.Add(s);
            }

            long res1 = 0;
            long res2 = 0;
            for (int i = 2; i < input.Length; i++)
            {
                long r = Solve(input[i], towels);
                res1 += r > 0 ? 1 : 0;
                res2 += r;
            }

            return "1: " + res1.ToString() + "\n2: " + res2.ToString();
        }
    }
}
