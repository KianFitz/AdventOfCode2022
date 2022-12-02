using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    internal class Day2 : Day
    {
        string[] _input;

        class RPSPlay {
            internal string First;
            internal string Second;

            internal static string GetPlay(char play)
            {
                switch (play)
                {
                    case 'A':
                    case 'X':
                        return "Rock";
                    case 'B':
                    case 'Y':
                        return "Paper";
                    case 'C':
                    case 'Z':
                        return "Scissors";
                }
                return "";
            }

            internal static string GetPlay(char opponentsPlay, char winType)
            {
                switch (winType)
                {
                    case 'Z':
                        {
                            switch (opponentsPlay) {
                                case 'A':
                                    return "Paper";
                                case 'B':
                                    return "Scissors";
                                case 'C':
                                    return "Rock";
                            }
                            break;
                        }
                    case 'Y':
                        return GetPlay(opponentsPlay);
                    case 'X':
                        {
                            switch (opponentsPlay) {
                                case 'A':
                                    return "Scissors";
                                case 'B':
                                    return "Rock";
                                case 'C':
                                    return "Paper";
                            }
                        }
                        break;
                } 
                return "";
            }

            internal int Score()
            {
                int myPlayScore = 0;
                string beatsMove = "";

                switch (Second)
                {
                    case "Rock":
                        myPlayScore = 1;
                        beatsMove = "Scissors";
                        break;
                    case "Paper":
                        myPlayScore = 2;
                        beatsMove = "Rock";
                        break;
                    case "Scissors":
                        myPlayScore = 3;
                        beatsMove = "Paper";
                        break;
                }
                if (First == Second)
                    return myPlayScore + 3;
                else if (beatsMove == First)
                    return myPlayScore + 6;
                else
                    return myPlayScore;
            }
        }

        public Day2(int number) : base(number)
        {
            Setup();
        }

        public override void Setup()
        {
            _input = GetInput();
        }

        public override void Part1()
        {
            var _plays = _input.Select(x => new RPSPlay()
            {
                First = RPSPlay.GetPlay(x[0]),
                Second = RPSPlay.GetPlay(x[2]),
            });

            int totalScore = _plays.Sum(x => x.Score());

            Log("[PART 1]: Total Score " + totalScore);
        }

        public override void Part2()
        {
            var _plays = _input.Select(x => new RPSPlay()
            {
                First = RPSPlay.GetPlay(x[0]),
                Second = RPSPlay.GetPlay(x[0], x[2]),
            });

            int totalScore = _plays.Sum(x => x.Score());

            Log("[PART 2]: Total Score " + totalScore);
        }
    }
}
