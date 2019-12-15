using AdventOfCode.Solutions.Year2019;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode
{
    public class IntCodeComputerTest
    {
        [Theory]
        [InlineData(
            new int[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 },
            new int[] { 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 })]
        [InlineData(
            new int[] { 1, 0, 0, 0, 99 },
            new int[] { 2, 0, 0, 0, 99 })]
        [InlineData(
            new int[] { 2, 3, 0, 3, 99 },
            new int[] { 2, 3, 0, 6, 99 })]
        [InlineData(
            new int[] { 2, 4, 4, 5, 99, 0 },
            new int[] { 2, 4, 4, 5, 99, 9801 })]
        [InlineData(
            new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 },
            new int[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 })]
        public void BasicFromDay2(int[] memory, int[] desiredEndState)
        {
            IntCodeComputer.RunOnMemory(memory);
            Assert.Equal(memory, desiredEndState);
        }

        [Fact]
        public void Opcode3FromInput()
        {
            var memory = new int[] { 3, 0, 99 };
            int input = 44;
            var desiredEndState = new int[] { 44, 0, 99 };

            IntCodeComputer.RunOnMemory(memory, input);
            Assert.Equal(memory, desiredEndState);
        }

        [Fact]
        public void Opcode4GetOutput()
        {
            var memory = new int[] { 3, 0, 4, 0, 99 };
            int input = 44;

            var output = IntCodeComputer.RunOnMemory(memory, input);
            Assert.Equal(input, output[0]);
        }
           [Fact]
        public void Parameters_kan_have_different_modes_modes()
        {
            var memory = new int[] { 1002, 4, 3, 4, 33 };
            var desiredEndState = new int[] { 1002, 4, 3, 4, 99 };

            IntCodeComputer.RunOnMemory(memory);
            Assert.Equal(memory, desiredEndState);
        }
        [Fact]
        public void Negative_values_is_ok()
        {
            var memory = new int[] { 1101, 100, -1, 4, 0 };
            var desiredEndState = new int[] { 1101, 100, -1, 4, 99 };

            IntCodeComputer.RunOnMemory(memory);
            Assert.Equal(memory, desiredEndState);
        }
        [Fact]
        public void Param_for_output_instruction_can_have_immediate_mode()
        {
            var memory = new int[] { 1, 0, 0, 0, 104, 0, 99 };
            
            var outputs = IntCodeComputer.RunOnMemory(memory);
            Assert.Equal(0, outputs[0]);
        }


        [Theory]
        [InlineData(
            new int[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 },
            1, 1)]
        [InlineData(
            new int[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 },
            1, 1)] 
        [InlineData(
            new int[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 },
            0, 0)]
        [InlineData(
            new int[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 },
            0, 0)]
       
        public void JumpTrueNotTrue(int[] memory, int input, int expectedOutput)
        {
            var outputs = IntCodeComputer.RunOnMemory(memory, input);

            Assert.Equal(expectedOutput, outputs[0]);
        }




        [Theory]
        [InlineData(
            new int[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 },
            8, 1)]
        [InlineData(
            new int[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 },
            88, 0)]
        [InlineData(
            new int[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 },
            8, 1)]
        [InlineData(
            new int[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 },
            88, 0)]
        

        public void Check_if_input_is_8(int[] memory, int input, int expectedOutput)
        {
            var outputs = IntCodeComputer.RunOnMemory(memory, input);

            Assert.Equal(expectedOutput, outputs[0]);
        }

    }

}
