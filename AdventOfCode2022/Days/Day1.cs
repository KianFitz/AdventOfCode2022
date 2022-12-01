using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    internal class Day1 : Day
    {
        string[] _input;
        List<int> totalCaloriesPerElf = new();

        public Day1(int number) : base(number)
        {
            Setup();
        }

        public override void Setup()
        {
            _input = GetInput();
        }

        public override void Part1()
        {
            int thisElvesAvailableCalories = 0;
            foreach (var inputLine in _input)
            {
                if (string.IsNullOrEmpty(inputLine))
                {
                    totalCaloriesPerElf.Add(thisElvesAvailableCalories);
                    thisElvesAvailableCalories = 0;
                }
                else
                {
                    thisElvesAvailableCalories += int.Parse(inputLine.Trim());
                }
            }

            Log("[PART 1]: Output " + totalCaloriesPerElf.Max());
        }

        public override void Part2()
        {
            totalCaloriesPerElf = totalCaloriesPerElf.OrderByDescending(x => x).ToList();
            int sumOfThreeHighestValues = totalCaloriesPerElf.Take(3).Sum();

            Log("[PART 2]: Output " + sumOfThreeHighestValues);
        }
    }
}
