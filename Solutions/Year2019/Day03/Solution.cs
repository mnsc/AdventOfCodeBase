using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2019
{

    class Day03 : ASolution
    {

        public Day03() : base(3, 2019, "")
        {
//            DebugInput = @"R75,D30,R83,U83,L12,D49,R71,U7,L72
//U62,R66,U55,R34,D71,R55,D58,R83";
        }

        protected override string SolvePartOne()
        {
            var instructionsLeftWire = Input.SplitByNewline()[0].Split(',').Select(x => x.GetStringIntTuple(true));
            var instructionsRightWire = Input.SplitByNewline()[1].Split(',').Select(x => x.GetStringIntTuple(true));

            var leftWirePath = CreateWirePath(instructionsLeftWire);
            var rightWirePath = CreateWirePath(instructionsRightWire);

            var crosses = leftWirePath.Intersect(rightWirePath);

           int v = crosses.Min(x => Utilities.ManhattanDistance((0, 0), x));
            return ";";
        }

        private static List<(int, int)> CreateWirePath(IEnumerable<(string String, int Int)> instructionsLeftWire)
        {
            var wirePath = new List<(int x, int y)>();
            var current = (x: 0, y: 0);

            foreach (var item in instructionsLeftWire)
            {
                for (int i = 0; i < item.Int; i++)
                {
                    switch (item.String)
                    {
                        case "u":
                            wirePath.Add(current = (current.x, current.y + 1));
                            break;
                        case "d":
                            wirePath.Add(current = (current.x, current.y - 1));
                            break;
                        case "r":
                            wirePath.Add(current = (current.x + 1, current.y));
                            break;
                        case "l":
                            wirePath.Add(current = (current.x - 1, current.y));
                            break;
                        default:
                            break;
                    }
                }
            }
            return wirePath;
        }

        protected override string SolvePartTwo()
        {
            var instructionsLeftWire = Input.SplitByNewline()[0].Split(',').Select(x => x.GetStringIntTuple(true));
            var instructionsRightWire = Input.SplitByNewline()[1].Split(',').Select(x => x.GetStringIntTuple(true));

            var leftWirePath = CreateWirePath(instructionsLeftWire).ToList();
            var rightWirePath = CreateWirePath(instructionsRightWire).ToList();

            var crosses = leftWirePath.Intersect(rightWirePath);

            var totalSteps = new List<int>();
            foreach (var cross in crosses)
            {
                int leftSteps = leftWirePath.TakeWhile(x => x != cross).Count();
                int rightSteps = rightWirePath.TakeWhile(x => x != cross).Count();
                totalSteps.Add(leftSteps + rightSteps);
            }
            var min = totalSteps.Min();
            return $"minimum steps is {min}";
        }

        /// <summary>
        /// Intuition, first crossing is the shortest. Brute force until first hit! Slow.
        /// </summary>
        /// <returns></returns>
        protected string SolvePartTwoSlowly()
        {
            var instructionsLeftWire = Input.SplitByNewline()[0].Split(',').Select(x => x.GetStringIntTuple(true));
            var instructionsRightWire = Input.SplitByNewline()[1].Split(',').Select(x => x.GetStringIntTuple(true));

            var leftWirePath = CreateWirePath(instructionsLeftWire).ToList();
            var rightWirePath = CreateWirePath(instructionsRightWire).ToList();

            for (int l = 0; l < leftWirePath.Count(); l++)
            {
                for (int r = 0; r < rightWirePath.Count(); r++)
                {
                    if (leftWirePath[l] == rightWirePath[r])
                        return $"First crossing at {leftWirePath[l]}, {l+1} steps on the left wire, {r+1} steps on the right\nfor a total of {l + 1 + r + 1} steps";
                }
                
            }
            throw new System.DataMisalignedException("w(ﾟДﾟ)w");
        }
    }
}
