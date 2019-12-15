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

            return 
                "\nDebug outputs: " + (string.Join(", ", outputs.Take(outputs.Count - 1).Select(x => x.ToString()))) + 
                "\nDiagnostic code is: " + outputs[outputs.Count - 1].ToString();
        }

        protected override string SolvePartTwo()
        {
            var program = Input.ToIntArray(",");

            var outputs = IntCodeComputer.RunOnMemory(program, 5);

            return "Diagnostic code is: " + outputs[0].ToString();

        }
    }
}
