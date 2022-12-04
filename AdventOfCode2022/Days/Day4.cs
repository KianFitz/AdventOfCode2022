
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    internal class Day4 : Day
    {
        string[] _input;
        
        public Day4(int number) : base(number)
        {
            Setup();
        }

        public override void Setup()
        {
            _input = GetInput();
        }

        public override void Part1()
        {
            int fullyContained = 0;
            foreach (string input in _input)
            {
                var split = input.Split(",");

                List<int[]> l = new List<int[]>();

                foreach (var a in split)
                {
                    var s = a.Split("-");

                    var vs = new Tuple<int, int>(int.Parse(s[0]), int.Parse(s[1]) + 1);

                    var p = Enumerable.Range(vs.Item1, vs.Item2 - vs.Item1);
                    l.Add(p.ToArray());
                }

                var intersect = l.First().Intersect(l.Last());
                if (l.Any(x => x.Count() == intersect.Count())) {
                    fullyContained++;
                }
            }
            Log("[PART 1]: Output: " + fullyContained);
        }

        public override void Part2()
        {
            int partiallyContained = 0;
            foreach (string input in _input)
            {
                var split = input.Split(",");
                List<int[]> l = new List<int[]>();
                foreach (var a in split)
                {
                    var s = a.Split("-");
                    var vs = new Tuple<int, int>(int.Parse(s[0]), int.Parse(s[1]) + 1);
                    var p = Enumerable.Range(vs.Item1, vs.Item2 - vs.Item1);
                    l.Add(p.ToArray());
                }

                var intersect = l.First().Intersect(l.Last());
                if (intersect.Count() > 0)
                {
                    partiallyContained++;
                }
            }

            Log("[PART 2]: Output: " + partiallyContained);
        }
    }
}
