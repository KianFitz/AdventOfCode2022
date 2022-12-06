using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    internal class Day5 : Day
    {
        string[] _input;
        List<Stack<CharBox>> _stacks;

        struct CharBox
        {
            internal string Box;
            public override string ToString()
            {
                return Box;
            }
        }

        public Day5(int number) : base(number)
        {
        }
        public override void Setup()
        {
            _input = GetInput();

            var firstEmptyLine = _input.First(x => string.IsNullOrEmpty(x));
            var emptyLineIndex = Array.IndexOf(_input, firstEmptyLine);

            var stacksInput = _input.Take(emptyLineIndex).ToArray();
            _input = _input.Skip(emptyLineIndex).ToArray();

            _stacks = new List<Stack<CharBox>>();
            for (int i = 0; i < stacksInput.Length; i++)
            {
                _stacks.Add(new Stack<CharBox>());
            }

            int currentIndex = 0;
            for (int i = stacksInput.Length - 2; i >= 0; i--)
            {
                for (int j = 0; j < stacksInput[i].Length; j++)
                {
                    CharBox box = new CharBox()
                    {
                        Box = new string(stacksInput[i].Skip(currentIndex).Take(3).ToArray())
                    };

                    if (box.Box.Any(y => y != 32))
                    {
                        _stacks[j].Push(box);
                    }
                    currentIndex += 4;
                }
                currentIndex = 0;
            }
        }

        public override void Part1()
        {
            Setup();

            Regex pattern = new Regex(@"move (?<amount>\d+) from (?<source>\d+) to (?<dest>\d+)");
            _input.ToList().ForEach(y =>
            {
                var match = pattern.Match(y);
                if (match.Success)
                {
                    int amount = int.Parse(match.Groups["amount"].Value);
                    int source = int.Parse(match.Groups["source"].Value) - 1;
                    int dest = int.Parse(match.Groups["dest"].Value) - 1;
                    
                    for (int i = 0; i < amount; i++)
                    {
                        _stacks[dest].Push(_stacks[source].Pop());
                    }
                }
                else
                {
                    Log("Did not match! String: " + y);
                }
            });

            _stacks.ForEach(y => Log(y.Peek().ToString()));
        }

        public override void Part2()
        {
            Setup();
            Regex pattern = new Regex(@"move (?<amount>\d+) from (?<source>\d+) to (?<dest>\d+)");
            _input.ToList().ForEach(y =>
            {
                var match = pattern.Match(y);
                if (match.Success)
                {
                    int amount = int.Parse(match.Groups["amount"].Value);
                    int source = int.Parse(match.Groups["source"].Value) - 1;
                    int dest = int.Parse(match.Groups["dest"].Value) - 1;

                    Stack<CharBox> items = new Stack<CharBox>();
                    for (int i = 0; i < amount; i++)
                    {
                        var item = _stacks[source].Pop();
                        items.Push(item);
                    }
                    for (int i = 0; i < amount; i++)
                    {
                        var item = items.Pop();
                        _stacks[dest].Push(item);
                    }
                }
                else
                {
                    Log("Did not match! String: " + y);
                }
            });

            Log(string.Join(" ", _stacks.Select(y => y.Peek())));
        }
    }
}
