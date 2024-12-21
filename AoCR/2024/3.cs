using AoCR.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoCR._2024
{
    public static class _3
    {
        public static string[] Day3()
        {
            string[] input = Input.GetRealInput();
            long res1 = 0;
            long res2 = 0;

            Regex regex = new Regex(@"mul\((\d*),(\d*)\)|do\(\)|don't\(\)");

            bool mult = true;
            foreach (var str in input)
            {
                MatchCollection matches = regex.Matches(str);

                for (int i = 0; i < matches.Count; i++)
                {
                    Match match = matches[i];
                    if (match.Value == "do()")
                    {
                        mult = true;
                    }
                    else if (match.Value == "don't()")
                    {
                        mult = false;
                    }
                    else
                    {
                        long res = long.Parse(match.Groups[1].Value) * long.Parse(match.Groups[2].Value);
                        res1 += res;
                        if (mult)
                        {
                            res2 += res;
                        }
                    }
                }
            }

            return new string[] { res1.ToString(), res2.ToString() };
        }
    }
}
