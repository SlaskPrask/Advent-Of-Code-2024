using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AoCR.Utils;

namespace AoCR.Old
{
    public class _14
    {
        const long width = 101;
        const long height = 103;

        const long qWidth = width / 2;
        const long qHeight = height / 2;

        const long seconds = 100;

        public class Data
        {
            public Vec2 pos;
            public Vec2 dir;
        }

        public static long Q1()
        {
            string[] input = File.ReadAllLines("../../../Input.txt");

            List<long> quadrants = new List<long>()
            {
                0,0,0,0
            };



            Regex regex = new Regex(@"p=(\d*),(\d*) v=(.\d*),(.\d*)");
            List<Vec2> positions = new();
            foreach (string line in input)
            {
                Data data = new Data();
                var res = regex.Match(line);
                data.pos = new Vec2(res.Groups[1].Value, res.Groups[2].Value);
                data.dir = new Vec2(res.Groups[3].Value, res.Groups[4].Value);
                data.dir.X += width;
                data.dir.Y += height;

                data.dir = data.dir * seconds;
                data.pos = data.pos + data.dir;
                data.pos.X = data.pos.X % width;
                data.pos.Y = data.pos.Y % height;

                if (data.pos.X == qWidth || data.pos.Y == qHeight)
                {
                    continue;
                }

                long qX = data.pos.X / (qWidth + 1);
                long qY = data.pos.Y / (qHeight + 1);
                quadrants[(int)(qY * 2 + qX)]++;
            }

            return quadrants[0] * quadrants[1] * quadrants[2] * quadrants[3];
        }

        public static long Day14()
        {
            string[] input = File.ReadAllLines("../../../Input.txt");
            Regex regex = new Regex(@"p=(\d*),(\d*) v=(.\d*),(.\d*)");

            List<Data> robots = new List<Data>();

            foreach (string line in input)
            {
                Data data = new Data();
                var res = regex.Match(line);
                data.pos = new Vec2(res.Groups[1].Value, res.Groups[2].Value);
                data.dir = new Vec2(res.Groups[3].Value, res.Groups[4].Value);
                data.dir.X += width;
                data.dir.Y += height;

                robots.Add(data);
            }

            long seconds = 0;

            string[] pages = new string[height];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pages[i] += " ";
                }
            }
             
            while (true)
            {
                string data = "Seconds: " + seconds + "\n";
                string[] lines = new string[height];
                pages.CopyTo(lines, 0);

                foreach (var robot in robots)
                {
                    Vec2 pos = robot.pos + robot.dir * seconds;
                    pos.X = pos.X % width;
                    pos.Y = pos.Y % height;
                    char[] line = lines[(int)pos.Y].ToCharArray();
                    line[(int)pos.X] = 'X';
                    lines[(int)pos.Y] = new string(line);
                }

                Console.WriteLine(data);

                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine("---------------------------------------");
                seconds++;
            }

            return 0;
        }
    }
}
