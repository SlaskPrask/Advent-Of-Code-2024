using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AoCR.Utils;

namespace AoCR.Old
{
    public static class _18
    {
        const int width = 71;
        const int height = 71;
        const int readBytes = 1024;

        public static string Day18()
        {
            string[] input = File.ReadAllLines("../../../Input.txt");
            long res = 0;

            int[,] map = new int[width,height];
            Regex regex = new Regex(@"(\d*),(\d*)");
            for (int i = 0; i < readBytes; ++i)
            {
                Match match = regex.Match(input[i]);
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                map[x, y] = 1;
            }

            for (int i = readBytes; i < input.Length; ++i) {
                Match match = regex.Match(input[i]);
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                map[x, y] = 1;
                List<Vec2> path = Pathfind.AStar(new Vec2(0, 0), new Vec2(width - 1, height - 1), map);
                
                if (path == null)
                {
                    return input[i];
                }
            }
            return ":(";
        }
    }
}
