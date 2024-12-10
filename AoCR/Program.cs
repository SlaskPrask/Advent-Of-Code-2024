// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

string[] input = File.ReadAllLines("../../../Input.txt");

long res = 0;

/*
List<Tuple<int, int>> dirs = new List<Tuple<int, int>>()
{
    new Tuple<int, int>(1, 0),
    new Tuple<int, int>(-1, 0),
    new Tuple<int, int>(0, 1),
    new Tuple<int, int>(0, -1)
};

for (int y = 0; y < input.Length; y++)
{
    for (int x = 0; x < input.Length; x++)
    {
        if (input[y][x] == '0')
        {
            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
            queue.Enqueue(new Tuple<int, int, int>(x, y, 1));
            HashSet<Tuple<int, int>> reachableNine = new HashSet<Tuple<int, int>>();

            while (queue.Count > 0)
            {
                Tuple<int, int, int> q = queue.Dequeue();
                for (int i = 0; i < dirs.Count; i++)
                { 
                    int nX = q.Item1 + dirs[i].Item1;
                    int nY = q.Item2 + dirs[i].Item2;
                    if (nX > -1 && nX < input[y].Length && nY > -1 && nY < input.Length)
                    {
                        if (input[nY][nX] == q.Item3.ToString()[0])
                        {
                            if (q.Item3 == 9)
                            {
                                if (!reachableNine.Contains(new Tuple<int, int>(nX, nY)))
                                {
                                    reachableNine.Add(new Tuple<int, int>(nX, nY));
                                    res++;
                                }
                                continue;
                            }
                            queue.Enqueue(new Tuple<int, int, int>(nX, nY, q.Item3 + 1));
                        }
                    }
                }
                    

            }
        }
    }
}
*/

List<Tuple<int, int>> dirs = new List<Tuple<int, int>>()
{
    new Tuple<int, int>(1, 0),
    new Tuple<int, int>(-1, 0),
    new Tuple<int, int>(0, 1),
    new Tuple<int, int>(0, -1)
};

for (int y = 0; y < input.Length; y++)
{
    for (int x = 0; x < input.Length; x++)
    {
        if (input[y][x] == '0')
        {
            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
            queue.Enqueue(new Tuple<int, int, int>(x, y, 1));
            //HashSet<Tuple<int, int>> reachableNine = new HashSet<Tuple<int, int>>();

            while (queue.Count > 0)
            {
                Tuple<int, int, int> q = queue.Dequeue();
                for (int i = 0; i < dirs.Count; i++)
                {
                    int nX = q.Item1 + dirs[i].Item1;
                    int nY = q.Item2 + dirs[i].Item2;
                    if (nX > -1 && nX < input[y].Length && nY > -1 && nY < input.Length)
                    {
                        if (input[nY][nX] == q.Item3.ToString()[0])
                        {
                            if (q.Item3 == 9)
                            {
                                //if (!reachableNine.Contains(new Tuple<int, int>(nX, nY)))
                                {
                                    //reachableNine.Add(new Tuple<int, int>(nX, nY));
                                    res++;
                                }
                                continue;
                            }
                            queue.Enqueue(new Tuple<int, int, int>(nX, nY, q.Item3 + 1));
                        }
                    }
                }
            }
        }
    }
}

Console.WriteLine(res);
