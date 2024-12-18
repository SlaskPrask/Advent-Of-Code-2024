﻿using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AoCR.Old
{
    public class _8
    {
        public static long Day8()
        {
            string[] input = File.ReadAllLines("../../../Input.txt");
            long res = 0;

            Dictionary<char, List<Tuple<long, long>>> data = new();
            HashSet<Tuple<long, long>> occupied = new HashSet<Tuple<long, long>>();
            HashSet<Tuple<long, long>> uniqueFreq = new();

            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    char c = input[y][x];
                    if (c != '.')
                    {
                        occupied.Add(new Tuple<long, long>(x, y));
                        if (!data.ContainsKey(c))
                        {
                            data.Add(c, new List<Tuple<long, long>>());
                        }
                        data[c].Add(new Tuple<long, long>(x, y));
                    }
                }
            }

            void checkPos(long x, long y, long dX, long dY)
            {
                while (x > -1 && x < input[0].Length && y > -1 && y < input.Length)
                {
                    var antinode = new Tuple<long, long>(x, y);
                    if (!uniqueFreq.Contains(antinode))
                    {
                        uniqueFreq.Add(antinode);
                        res++;
                    }
                    x += dX;
                    y += dY;
                }
            }

            foreach (var pair in data)
            {
                var list = pair.Value;
                if (list.Count < 2)
                {
                    continue;
                }
                for (int i = 0; i < list.Count; i++)
                {
                    var first = list[i];
                    char c = input[first.Item2][(int)first.Item1];
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        var second = list[j];

                        long xDist = second.Item1 - first.Item1;
                        long yDist = second.Item2 - first.Item2;

                        checkPos(second.Item1, second.Item2, xDist, yDist);
                        checkPos(first.Item1, first.Item2, -xDist, -yDist);


                    }
                }
            }

            return res;
        }
    }
}