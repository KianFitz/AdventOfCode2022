using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    abstract public class Day
    {
        protected int DayNumber { get; set; }

        protected string InputPath { get; set; }

        public Day(int number)
        {
            DayNumber = number;
            InputPath = Assembly.GetEntryAssembly().Location + $@"\Inputs\Day{DayNumber}.txt";
        }

        abstract public void Part1();
        abstract public void Part2();
        abstract public void Setup();

        protected string[] GetInput()
        {
            return System.IO.File.ReadAllLines(InputPath);
        }

        protected void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("hh:mm:ss")}] [DAY {DayNumber}]: {message}");
        }
    }
}
