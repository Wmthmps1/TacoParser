using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.

            logger.LogInfo("Log initialized");
            var lines = File.ReadAllLines(csvPath);
            logger.LogInfo($"Lines: {lines[0]}");

            
            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToArray();
            ITrackable tacoBellOne = null;
            ITrackable tacoBellTwo = null;
            double distance = 0.0;
            double compDistance;

            
            foreach (var locA in locations)
            {
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                
                foreach (var locB in locations)
                {
                    var corB = new GeoCoordinate(locB.Location.Latitude,locB.Location.Longitude);
                    compDistance = corA.GetDistanceTo(corB);
                    if (compDistance > distance)
                    {
                        distance = compDistance;
                        tacoBellOne = locA;
                        tacoBellTwo = locB;
                    }
                }
            }
            
            Console.WriteLine(tacoBellOne.Name);
            Console.WriteLine($"{tacoBellOne.Location.Latitude}, {tacoBellOne.Location.Longitude}");
            Console.WriteLine(tacoBellTwo.Name);
            Console.WriteLine($"{tacoBellTwo.Location.Latitude}, {tacoBellTwo.Location.Longitude}");
            Console.WriteLine(distance);
        }
    }
}
