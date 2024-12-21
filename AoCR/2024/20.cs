using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoCR.Utils;

namespace AoCR.Old
{
    public static class _20
    {
        public static string Day20()
        {
            string[] input = File.ReadAllLines("../../../Input.txt");
            int[,] map = new int[input[0].Length - 2,input.Length - 2];
            Vec2 start = new Vec2();
            Vec2 end = new Vec2();
            long res = 0;

            for (int y = 1; y < input.Length - 1; y++)
            {
                for (int x = 1; x < input[y].Length - 1; x++)
                {
                    char val = input[y][x];

                    if (val == '#')
                    {
                        map[x - 1,y - 1] = 1;
                    } 
                    else if (val == 'S')
                    {
                        start = new Vec2(x - 1, y- 1);
                    } 
                    else if (val == 'E')
                    {
                        end = new Vec2(x - 1, y - 1);
                    }
                }
            }

            List<Vec2> path = Pathfind.DFS(start, end, map);
            int cheatLength = 20;
            int saveSec = 100;

            for (int i = 0; i < path.Count - saveSec; i++)
            {
                for (int j = i + (saveSec - 1); j < path.Count; j++)
                {
                    Vec2 dist = path[i] - path[j];
                    long distVal = Math.Abs(dist.X) + Math.Abs(dist.Y);
                    long actualTimesave = (j - i) - distVal;

                    if (actualTimesave >= saveSec && distVal <= cheatLength)
                    {
                        res++;
                    }

                }
            }

            

            return res.ToString();
        }
    }
}
