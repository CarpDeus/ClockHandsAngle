using CommandLine;

namespace ClockHandsAngle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(opts => Console.WriteLine($"With the hour hand at {opts.Hours} and the minute hand at {opts.Minutes} the angle between them would be {ClockHandAngles(opts.Hours, opts.Minutes)}"));
        }

        static float ClockHandAngles(int hours, int minutes)
        {
            // Stub function
            float degreePerMinute = 360 / 60;
            float degreePerHour = 360 / 12;
            float degreePerPartialHour = degreePerHour / 60;

            float minuteDegrees = minutes * degreePerMinute;
            float hourDegrees = hours * degreePerHour;
            Console.WriteLine($"Initial Minute degrees: {minuteDegrees}");
            Console.WriteLine($"Initial Hour degrees: {hourDegrees}");
            
            if (hours == 12) hourDegrees = 0;
            if (minutes == 0) // Hours don't need modification
                return Math.Abs(minuteDegrees - hourDegrees);
            else
            {
                Console.WriteLine($"DegreesPerPartialHour*Minutes {degreePerPartialHour*minutes}");
                
                return Math.Abs(minuteDegrees - hourDegrees - (degreePerPartialHour * minutes));
            }
        }
    }

    class Options
    {
        [Option('h', "hours", Required = true, HelpText = "Set the hours.")]
        public int Hours { get; set; }

        [Option('m', "minutes", Required = true, HelpText = "Set the minutes.")]
        public int Minutes { get; set; }
    }
}
