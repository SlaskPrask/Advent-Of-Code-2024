using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCR.Old
{
    public class _12
    {
        public static long Day12()
        {
            string[] input = File.ReadAllLines("../../../Input.txt");
            long res = 0;

            HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
            List<HashSet<Tuple<int, int>>> regions = new List<HashSet<Tuple<int, int>>>();
            List<Tuple<int, int>> dirs = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(-1, 0),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(0, -1)
            };

            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    var current = new Tuple<int, int>(x, y);

                    if (visited.Contains(current))
                    {
                        continue;
                    }
                    visited.Add(current);
                    int index = regions.Count;
                    HashSet<Tuple<int, int>> region = new();
                    Queue<Tuple<int, int>> tuples = new Queue<Tuple<int, int>>();

                    tuples.Enqueue(current);
                    char character = input[y][x];
                    while (tuples.Count > 0)
                    {
                        var tuple = tuples.Dequeue();
                        region.Add(tuple);
                        foreach (var item in dirs)
                        {
                            Tuple<int, int> neighbor = new Tuple<int, int>(tuple.Item1 + item.Item1, tuple.Item2 + item.Item2);
                            if (visited.Contains(neighbor) || neighbor.Item1 < 0 ||  neighbor.Item2 < 0 || neighbor.Item1 >= input[y].Length || neighbor.Item2 >= input.Length || character != input[neighbor.Item2][neighbor.Item1])
                            {
                                continue;
                            }
                            visited.Add(neighbor);
                            tuples.Enqueue(neighbor);
                        }
                    }
                    regions.Add(region);
                }
            }

            foreach (var region in regions)
            {
                res += region.Count * FindSides(region);
            }

            return res;
        }

        public static long FindPerimiter(HashSet<Tuple<int,int>> region)
        {
            long res = 0;

            List<Tuple<int, int>> dirs = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(-1, 0),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(0, -1)
            };

            foreach (var pos in region)
            {
                foreach (var dir in dirs)
                {
                    var neighbor = new Tuple<int, int>(pos.Item1 + dir.Item1, pos.Item2 + dir.Item2);
                    if (region.Contains(neighbor))
                    {
                        continue;
                    }
                    res++;
                }
            }


            return res;
        }

        public static Tuple<int, int> Offset(Tuple<int, int> tuple, int xOffset, int yOffset)
        {
            return new Tuple<int, int>(tuple.Item1 + xOffset, tuple.Item2 + yOffset);
        }

        public static long FindSides(HashSet<Tuple<int, int>> region)
        {
            long corners = 0;
            foreach (var pos in region)
            {
                if (!region.Contains(Offset(pos, -1, 0)) && ! region.Contains(Offset(pos, 0, -1)))
                {
                    corners++;
                }
                if (!region.Contains(Offset(pos, 1, 0)) && !region.Contains(Offset(pos, 0, -1)))
                {
                    corners++;
                }
                if (!region.Contains(Offset(pos, -1, 0)) && !region.Contains(Offset(pos, 0, 1)))
                {
                    corners++;
                }
                if (!region.Contains(Offset(pos, 1, 0)) && !region.Contains(Offset(pos, 0, 1)))
                {
                    corners++;
                }


                if (region.Contains(Offset(pos, -1, 0)) && region.Contains(Offset(pos, 0, -1)) && !region.Contains(Offset(pos, -1, -1)))
                {
                    corners++;
                }
                if (region.Contains(Offset(pos, 1, 0)) && region.Contains(Offset(pos, 0, -1)) && !region.Contains(Offset(pos, 1, -1)))
                {
                    corners++;
                }
                if (region.Contains(Offset(pos, -1, 0)) && region.Contains(Offset(pos, 0, 1)) && !region.Contains(Offset(pos, -1, 1)))
                {
                    corners++;
                }
                if (region.Contains(Offset(pos, 1, 0)) && region.Contains(Offset(pos, 0, 1)) && !region.Contains(Offset(pos, 1, 1)))
                {
                    corners++;
                }
            }
            
            return corners;
        }
    }
}
