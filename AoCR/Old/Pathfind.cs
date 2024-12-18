using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCR.Old
{
    public class Pathfind
    {
        private static double Heuristic(Vec2 current, Vec2 end)
        {
            return (end - current).Length();
        }

        private static List<Vec2> ConstructPath(Dictionary<Vec2, Vec2> parentMap, Vec2 current)
        {
            var path = new List<Vec2>() { current };

            while (parentMap.ContainsKey(current))
            {
                current = parentMap[current];
                path.Add(current);
            }

            path.Reverse();
            return path;
        }

        public static List<Vec2> AStar(Vec2 start, Vec2 end, int[,] map)
        {
            var openPoints = new PriorityQueue<Vec2, double>();
            var addedPoints = new HashSet<Vec2>();
            var closedPoints = new HashSet<Vec2>();

            var startHeuruistic = Heuristic(start, end);
            openPoints.Enqueue(start, startHeuruistic);

            var gScore = new Dictionary<Vec2, double> { [start] = 0 };
            var hScore = new Dictionary<Vec2, double> { [start] = startHeuruistic };
            var parentMap = new Dictionary<Vec2, Vec2>();

            List<Vec2> directions = new List<Vec2>()
            {
                new Vec2(1, 0),
                new Vec2(-1, 0),
                new Vec2(0, 1),
                new Vec2(0, -1)
            };

            while (openPoints.Count > 0)
            {
                var current = openPoints.Dequeue();
                if (current == end)
                {

                    return ConstructPath(parentMap, current);
                }

                closedPoints.Add(current);

                foreach (var dir in directions)
                {
                    var neighbor = current + dir;
                    if (closedPoints.Contains(neighbor) || neighbor.X < 0 || neighbor.Y < 0 || neighbor.X >= map.GetLength(0) || neighbor.Y >= map.GetLength(1) || map[neighbor.X, neighbor.Y] != 0)
                    {
                        continue;
                    }

                    double tentativeG = gScore[current] + 1;
                    if (!gScore.ContainsKey(neighbor) || tentativeG < gScore[neighbor])
                    {
                        double fScore = gScore[neighbor] = tentativeG;
                        fScore += hScore[neighbor] = Heuristic(neighbor, end);

                        parentMap[neighbor] = current;

                        if (!addedPoints.Contains(neighbor))
                        {
                            openPoints.Enqueue(neighbor, fScore);
                            addedPoints.Add(neighbor);
                        }
                    }
                }
            }
            return null;
        }
    }
}
