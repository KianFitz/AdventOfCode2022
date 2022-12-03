using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    internal class Day3 : Day
    {
        string[] _input;
        
        public Day3(int number) : base(number)
        {
            Setup();
        }

        public override void Setup()
        {
            _input = GetInput();
        }

        public override void Part1()
        {
            var rucksacks = _input.ToList().Select(x => new
            {
                First = x.Substring(0, x.Length / 2),
                Second = x.Substring(x.Length / 2)
            });

            int totalSum = rucksacks.Sum(x =>
            {
                var charCode = x.First.Intersect(x.Second).First();
                return char.IsUpper(charCode) ? charCode - 38 : charCode - 96;
            });

            Log("[PART 1]: Output: " + totalSum);
        }

        public override void Part2()
        {
            int totalSum = 0;

            List<string> thisGroup = new List<string>();
            for (int i = 0; i < _input.Length; i++)
            {
                thisGroup.Add(_input[i]);
                if (thisGroup.Count == 3)
                {
                    var intersections = thisGroup.Skip(1)
                        .Aggregate(
                        new HashSet<char>(thisGroup.First()),
                        (h, s) => { h.IntersectWith(s); return h; });

                    var intersection = intersections.First();

                    totalSum += char.IsUpper(intersection) ? intersection - 38 : intersection - 96;
                    thisGroup.Clear();
                }
            }

            Log("[PART 2]: Output: " + totalSum);
        }
    }
}
