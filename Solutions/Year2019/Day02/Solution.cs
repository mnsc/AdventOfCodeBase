using System;

namespace AdventOfCode.Solutions.Year2019
{

    class Day02 : ASolution
    {

        public Day02() : base(2, 2019, "")
        {
        }

        protected override string SolvePartOne()
        {
            var program = Input.ToIntArray(",");
            // fix state
            const int noun = 12;
            const int verb = 2;

            program[1] = noun;
            program[2] = verb;

            IntCodeComputer.RunOnMemory(program);

            return program[0].ToString();
        }

        protected override string SolvePartTwo()
        {
            for (int noun = 0; noun < 99; noun++)
            {
                for (int verb = 0; verb < 99; verb++)
                {
                    int result = TestNounVerb(noun, verb);
                    if (result == 19690720)
                        return $"{noun} and {verb} gives 100 * noun + verb = {100 * noun + verb}";
                }
            }
            throw new ArgumentException("💔");
        }

        private int TestNounVerb(int noun, int verb)
        {
            var freshMemory = Input.ToIntArray(",");

            freshMemory[1] = noun;
            freshMemory[2] = verb;

            IntCodeComputer.RunOnMemory(freshMemory);
            return freshMemory[0];
        }
    }
}
