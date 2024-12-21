using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCR.Old
{
    public class _11
    {
        public static long Day11()
        {
            string[] input = File.ReadAllLines("../../../Input.txt");

            long res = 0;

            List<string> initialStones = input[0].Split(' ').ToList();
            Dictionary<string, string> cache = new Dictionary<string, string>();
            Dictionary<string, long> stones = new Dictionary<string, long>();

            for (int i = 0; i < initialStones.Count; i++)
            {
                if (stones.ContainsKey(initialStones[i]))
                {
                    stones[initialStones[i]]++;
                }
                else
                {
                    stones[initialStones[i]] = 1;
                }
            }

            for (int i = 0; i < 75; i++)
            {
                Dictionary<string, long> newStones = new Dictionary<string, long>();
                foreach (var keyValPair in stones)
                {
                    var stone = keyValPair.Key;
                    var count = keyValPair.Value;
                    if (cache.ContainsKey(stone))
                    {
                        string[] keys = cache[stone].Split();
                        for (int j = 0; j < keys.Length; j++)
                        {
                            if (newStones.ContainsKey(keys[j]))
                            {
                                newStones[keys[j]] += count;
                            }
                            else
                            {
                                newStones[keys[j]] = count;
                            }
                        }
                        continue;
                    }

                    string result = "";
                    if (stone == "0")
                    {
                        result = "1";
                    }
                    else if (stone.Length % 2 == 0)
                    {
                        result = stone.Substring(0, stone.Length / 2);
                        var second = stone.Substring(stone.Length / 2).TrimStart('0');
                        if (second.Length == 0)
                        {
                            second = "0";
                        }

                        result += " " + second;
                    }
                    else
                    {
                        result = (long.Parse(stone) * 2024).ToString();
                    }
                    cache.Add(stone, result);
                    string[] ressess = result.Split();
                    for (int j = 0; j < ressess.Length; j++)
                    {
                        if (newStones.ContainsKey(ressess[j]))
                        {
                            newStones[ressess[j]] += count;
                        }
                        else
                        {
                            newStones[ressess[j]] = count;
                        }
                    };
                }
                stones = newStones;
            }

            foreach (var item in stones)
            {
                res += item.Value;
            }

            return res;
        }
    }
}
