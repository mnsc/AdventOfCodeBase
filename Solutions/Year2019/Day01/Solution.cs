
using System.Linq;

namespace AdventOfCode.Solutions.Year2019 {

    class Day01 : ASolution {

        public Day01() : base(1, 2019, "") {

        }

        protected override string SolvePartOne() {
            var array = Input.ToIntArray("\n");
            return "summa: " + array.Sum(x => x / 3 - 2);
        }

        protected override string SolvePartTwo() {
            var array = Input.ToIntArray("\n");
            int total = 0;
            foreach (var item in array)
            {
                int fuelneeded = item / 3 - 2;
                while (fuelneeded > 0)
                {
                    total += fuelneeded;
                    fuelneeded = fuelneeded / 3 - 2;
                }
            }

            return total.ToString();
        }
    }
}
