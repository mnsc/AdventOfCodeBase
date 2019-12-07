using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2019
{

    class Day04 : ASolution
    {

        public Day04() : base(4, 2019, "")
        {
        }

        protected override string SolvePartOne()
        {
            int from = int.Parse(Input.Split('-')[0]);
            int to = int.Parse(Input.Split('-')[1]);
            var numberofvalid =
                Enumerable.Range(from, to - from)
                .Select(number => (number, valid: IsNondecreasingAndHasRepeatedDigit(number)))
                .Count(x => x.valid)
                ;

            return $"Total non-decreasing numbers with a repeated digit in interval {Input} is {numberofvalid}";
        }

        private static bool IsNondecreasingAndHasRepeatedDigit(int number)
        {
            int current = 0;
            bool valid = false;
            foreach (var digit in number.ToString().Select(c => int.Parse(c.ToString())))
            {
                if (digit < current)
                {
                    return false;
                }
                else if (digit == current)
                {
                    valid = true;
                }

                current = digit;
            }
            return valid;
        }

        protected override string SolvePartTwo()
        {
            int from = int.Parse(Input.Split('-')[0]);
            int to = int.Parse(Input.Split('-')[1]);
            var numberofvalid =
                Enumerable.Range(from, to - from)
                .Select(number => (number, valid: IsNondecreasingAndHasDoubleDigit(number)))
                .Count(x => x.valid)
                ;


            return $"Total non-decreasing numbers with single double digit in interval {Input} is {numberofvalid}";
        }

        private static bool IsNondecreasingAndHasDoubleDigit(int number)
        {
            int current = 0;
            int sequenceCount = 1;
            bool valid = false;

            foreach (var digit in number.ToString().Select(c => int.Parse(c.ToString())))
            {
                if (digit < current)
                {
                    return false;
                }
                else if (digit == current)
                {
                    sequenceCount++;
                }
                else
                {
                    if (sequenceCount == 2)
                    {
                        valid = true;
                    }
                    sequenceCount = 1;
                }

                current = digit;
            }

            // case when double digit at end 133
            if (sequenceCount == 2)
            {
                valid = true;
            }
            return valid;
        }

    }
}
