using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2019
{
    public enum ParameterMode
    {
        Position,
        Immediate
    }
    public static class IntCodeComputer
    {
        public static List<int> RunOnMemory(int[] program, int? input = null)
        {
            var returns = new List<int>();
            int instructionPointer = 0;
            while (program[instructionPointer] != 99)
            {
                int instruction = program[instructionPointer];
                int move;
                var modeParam1 = ParameterMode.Position;
                var modeParam2 = ParameterMode.Position;
                if (instruction > 100)
                {
                    var instructionArray = instruction.ToString().Select(c => int.Parse(c.ToString())).ToArray();

                    if (instructionArray[instructionArray.Count() - 3] == 1)
                    {
                        modeParam1 = ParameterMode.Immediate;
                    }
                    if (instruction > 1000)
                    {
                        if (instructionArray[instructionArray.Count() - 4] == 1)
                        {
                            modeParam2 = ParameterMode.Immediate;
                        }
                    }
                    instruction = instructionArray[instructionArray.Count() - 1];
                }
                int param1;
                int param2;
                switch (instruction)
                {
                    case 1: // addition
                        param1 = modeParam1 == ParameterMode.Position ? program[program[instructionPointer + 1]] : program[instructionPointer + 1];
                        param2 = modeParam2 == ParameterMode.Position ? program[program[instructionPointer + 2]] : program[instructionPointer + 2];
                        program[program[instructionPointer + 3]] = param1 + param2;
                        move = 4;
                        break;
                    case 2: // mult
                        param1 = modeParam1 == ParameterMode.Position ? program[program[instructionPointer + 1]] : program[instructionPointer + 1];
                        param2 = modeParam2 == ParameterMode.Position ? program[program[instructionPointer + 2]] : program[instructionPointer + 2];
                        program[program[instructionPointer + 3]] = param1 * param2;
                        move = 4;
                        break;
                    case 3: // store from input
                        program[program[instructionPointer + 1]] = input.Value;
                        move = 2;
                        break;
                    case 4: // output
                        param1 = modeParam1 == ParameterMode.Position ? program[program[instructionPointer + 1]] : program[instructionPointer + 1];
                        returns.Add(param1);
                        move = 2;
                        break;
                    case 5: // 
                        param1 = modeParam1 == ParameterMode.Position ? program[program[instructionPointer + 1]] : program[instructionPointer + 1];
                        param2 = modeParam2 == ParameterMode.Position ? program[program[instructionPointer + 2]] : program[instructionPointer + 2];
                        if (param1 != 0)
                        {
                            instructionPointer = param2;
                            move = 0;
                        }
                        else
                        {
                            move = 3;
                        }

                        break;
                    case 6: // 
                        param1 = modeParam1 == ParameterMode.Position ? program[program[instructionPointer + 1]] : program[instructionPointer + 1];
                        param2 = modeParam2 == ParameterMode.Position ? program[program[instructionPointer + 2]] : program[instructionPointer + 2];
                        if (param1 == 0)
                        {
                            instructionPointer = param2;
                            move = 0;
                        }
                        else
                        {
                            move = 3;
                        }

                        break;
                    default:
                        throw new System.Exception("💥");
                }


                instructionPointer += move;
            }
            return returns;
        }

        private static object List<T>()
        {
            throw new NotImplementedException();
        }
    }
}




