using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoCR.Old
{
    public class Data
    {
        public Vec2 A;
        public Vec2 B;
        public Vec2 Prize;
    };

    public class _13
    {
        public static long ComputeTokens(Data data)
        {
            /*
                (data.Prize - data.B * b) / data.A == a;  
             */

            long a = -(data.B.Y * data.Prize.X - data.B.X * data.Prize.Y);
            long b = -(data.A.X * data.Prize.Y - data.A.Y * data.Prize.X);

            long div = data.A.Y * data.B.X - data.A.X * data.B.Y;

            if (a % div != 0 || b % div != 0)
            {
                return 0;
            }

            return (3 * a + b) / div;

        }

        public static long Day13()
        {
            string[] input = File.ReadAllLines("../../../Input.txt");
            long res = 0;

            Regex buttA = new Regex(@"Button A: X\+(\d*), Y\+(\d*)");
            Regex buttB = new Regex(@"Button B: X\+(\d*), Y\+(\d*)");
            Regex prize = new Regex(@"Prize: X=(\d*), Y=(\d*)");
            List<Data> data = new List<Data>();

            for (int i = 0; i < input.Length; i++)
            {
                Match match;
                switch (i % 4)
                {
                    case 0:
                        data.Add(new Data());
                        match = buttA.Match(input[i]);
                        data[data.Count - 1].A = new Vec2 { X = long.Parse(match.Groups[1].Value), Y = long.Parse(match.Groups[2].Value) }; 
                        break;
                    case 1:
                        match = buttB.Match(input[i]);
                        data[data.Count - 1].B = new Vec2 { X = long.Parse(match.Groups[1].Value), Y = long.Parse(match.Groups[2].Value) };
                        break;
                    case 2:
                        match = prize.Match(input[i]);
                        data[data.Count - 1].Prize = new Vec2 { X = long.Parse(match.Groups[1].Value) + 10000000000000, Y = long.Parse(match.Groups[2].Value) + 10000000000000 };
                        break;
                    case 3:
                        break;
                }
            }

            foreach (var r in data)
            {
                res += ComputeTokens(r);
            }


            return res;
        }
    }
}
