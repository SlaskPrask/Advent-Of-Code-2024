using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AoCR.Old
{
    public class _7
    {

        public static long Day7()
        {
            string[] input = File.ReadAllLines("../../../Input.txt");

            long res = 0;

            bool TryMake(long goal, List<long> values)
            {
                int possible = 0;
                int perms = (int)Math.Pow(2, values.Count - 1);

                for (int i = 0; i < perms; i++)
                {
                    long sum = values[0];
                    for (int j = 1; j < values.Count; j++)
                    {
                        if ((((int)Math.Pow(2, j - 1)) & i) != 0)
                        {
                            sum *= values[j];
                        }
                        else
                        {
                            sum += values[j];
                        }
                    }
                    if (sum == goal)
                    {
                        possible = 1;
                        break;
                    }
                }



                return possible > 0;
            }

            bool TryHarder(long goal, List<long> values)
            {
                int possible = 0;
                int perms = (int)Math.Pow(3, values.Count - 1);

                List<string> opStrings = new List<string>()
    {
        "+","*","|"
    };


                for (int spot = 1; spot < values.Count - 1; spot++)
                {
                    string[] temp = new string[opStrings.Count];
                    opStrings.CopyTo(temp);
                    opStrings.AddRange(temp);
                    opStrings.AddRange(temp);
                    for (int op = 0; op < 3; op++)
                    {
                        char rator = (op == 0 ? '+' : (op == 1 ? '*' : '|'));


                        for (int i = 0 + (opStrings.Count / 3) * op; i < (opStrings.Count / 3) * (op + 1); i++)
                        {
                            opStrings[i] += rator;
                        }
                    }
                }

                for (int i = 0; i < opStrings.Count; i++)
                {
                    long sum = values[0];
                    for (int j = 1; j < values.Count; j++)
                    {
                        switch (opStrings[i][j - 1])
                        {
                            case '+':
                                sum += values[j];
                                break;
                            case '*':
                                sum *= values[j];
                                break;
                            case '|':
                                sum = long.Parse(sum.ToString() + values[j].ToString());
                                break;
                        }
                    }
                    if (sum == goal)
                    {
                        possible = 1;
                        break;
                    }
                }



                return possible > 0;
            }


            foreach (string line in input)
            {
                var data = line.Split(' ');
                long goal = long.Parse(data[0].TrimEnd(':'));
                List<long> parts = new List<long>();
                for (int i = 1; i < data.Length; i++)
                {
                    parts.Add(long.Parse(data[i]));
                }
                if (TryMake(goal, parts))
                {
                    res += goal;
                }
                else if (TryHarder(goal, parts))
                {
                    res += goal;
                }
            }


            return res;
        }
    }
}