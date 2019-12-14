﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2019
{
    public static class IntCodeComputer
    {
        public static int RunOnMemory(int[] program, int? input = null)
        {
            int headPos = 0;
            while (program[headPos] != 99)
            {
                int instruction = program[headPos];
                int move;
                switch (instruction)
                {
                    case 1: // addition
                        program[program[headPos + 3]] = program[program[headPos + 1]] + program[program[headPos + 2]];
                        move = 4;
                        break;
                    case 2: // mult
                        program[program[headPos + 3]] = program[program[headPos + 1]] * program[program[headPos + 2]];
                        move = 4;
                        break;
                    case 3: // store from input
                        program[program[headPos + 1]] = input.Value;
                        move = 2;
                        break;
                    case 4: // output
                        return program[program[headPos + 1]];
                    default:
                        throw new System.Exception("💥");
                }
                headPos += move;
            }
            return -1;
        }
    }
}
