using AoCR.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCR._2024
{
    public static class _2
    {
        static bool Solve(List<int> level)
        {
            int sign = Math.Sign(level[0] - level[1]);
            if (sign == 0)
            {
                return false;
            }

            bool safe = true;
            for (int j = 0; j < level.Count - 1; j++)
            {
                int value = level[j] - level[j + 1];
                if (sign != Math.Sign(value) || Math.Abs(value) > 3)
                {
                    safe = false;
                    break;
                }
            }

            return safe;
        }


        public static HashSet<int> Solve1(List<List<int>> levels)
        {
            HashSet<int> safeLvls = new HashSet<int>(); 

            for (int i = 0; i < levels.Count; i++)
            {
                if (Solve(levels[i]))
                {
                    safeLvls.Add(i);
                }
            }
            
            return safeLvls;
        }

        public static string Solve2(List<List<int>> levels, HashSet<int> visited)
        {
            int res = 0;

            for (int i = 0; i < levels.Count; i++)
            {
                if (visited.Contains(i))
                {
                    continue;
                }

                List<int> level = levels[i];
                for (int j = 0; j < level.Count; j++)
                {
                    List<int> copy = new List<int>(level);
                    copy.RemoveAt(j);
                    if (Solve(copy))
                    {
                        res++;
                        break;
                    }
                }
            }


            return (res + visited.Count).ToString();
        }

        public static string[] Day2()
        {
            string[] input = Input.GetRealInput();
            List<List<int>> levels = new List<List<int>>();

            foreach (var str in input)
            {
                string[] data = str.Split(' ');
                List<int> level = new List<int>();
                foreach (var d in data)
                {
                    level.Add(int.Parse(d));
                }
                levels.Add(level);
            }

            HashSet<int> res1 = Solve1(levels);
            string res2 = Solve2(levels, res1);

            return new string[] { res1.Count.ToString(), res2 };
        }
    }
}
