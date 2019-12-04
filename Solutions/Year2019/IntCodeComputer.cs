using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2019
{
    public static class IntCodeComputer
    {
        public static void RunOnMemory(int[] program)
        {
            int headPos = 0;
            while (program[headPos] != 99)
            {

                int instruction = program[headPos];
                int firstParam = program[program[headPos + 1]];
                int secondParam = program[program[headPos + 2]];
                int storePos = program[headPos + 3];
                switch (instruction)
                {
                    case 1: // addition
                        program[storePos] = firstParam + secondParam;
                        break;
                    case 2: // mult
                        program[storePos] = firstParam * secondParam;
                        break;
                    default:
                        throw new System.Exception("💥");
                }
                headPos += 4;
            }
        }
    }
}
