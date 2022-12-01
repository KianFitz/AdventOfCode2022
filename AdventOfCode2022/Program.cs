using AdventOfCode2022.Days;

while (true)
{
    Console.WriteLine("Enter the day number you want to run (1-25) or type 'exit' to quit.");

    string input = Console.ReadLine();

    if (input == "exit")
        break;

    if (int.TryParse(input, out int dayNumber))
    {
        if (dayNumber < 1 || dayNumber > 25)
        {
            Console.WriteLine("Invalid day number. Please enter a number between 1 and 25.");
        }
        else
        {
            var type = Type.GetType($"AdventOfCode2022.Days.Day{dayNumber}");

            if (type is null)
            {
                Console.WriteLine("Day not implemented yet.");
            }
            else
            {
                var instance = Activator.CreateInstance(type, dayNumber);
                if (instance is null) return;
                
                var dayToRun = (Day)instance;
                dayToRun.Part1();
                dayToRun.Part2();
            }
        }
    }
    else
    { 
        Console.WriteLine("Invalid input. Please enter a number between 1 and 25.");
    }
}