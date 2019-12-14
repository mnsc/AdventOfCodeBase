using System.Linq;

namespace AdventOfCode.Solutions.Year2019
{

    class Day05 : ASolution
    {

        public Day05() : base(5, 2019, "")
        {

        }

        protected override string SolvePartOne()
        {
            var program = Input.ToIntArray(",");

            var outputs = IntCodeComputer.RunOnMemory(program, 1);

            return "\nDebug outputs: " + (string.Join(", ", outputs.Take(outputs.Count - 1).Select(x => x.ToString()))) + "\nFinal output is: "  + outputs[outputs.Count - 1].ToString();
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
