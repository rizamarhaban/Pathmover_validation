/*using PathMover;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

class VehicleEvent
{
    public string Event { get; set; }
    public string Time { get; set; }
    public string VehicleID { get; set; }
    public string Location { get; set; }

    public DateTime GetDateTime()
    {
        if (DateTime.TryParse(Time, out var dateTime))
        {
            return dateTime;
        }
        else
        {
            throw new FormatException($"Unable to parse the date time value: {Time}");
        }
    }
}

class PathInformation
{
    public double Length { get; set; }
    public int Capacity { get; set; }
}

class PathTransitTime
{
    public string VehicleID { get; set; }
    public TimeSpan TransitTime { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        string logFilePath = "pathmover_log.txt"; // Update with the actual path to your log file
        var vehicleEvents = File.ReadAllLines(logFilePath)
                                .Select(line => JsonSerializer.Deserialize<VehicleEvent>(line))
                                .ToList();

        var pathTransitDetails = new Dictionary<string, List<PathTransitTime>>();
        var vehicleTotalTransitTimes = new Dictionary<string, TimeSpan>();
        var vehicleEnterTimes = new Dictionary<(string VehicleID, string Location), DateTime>();

        foreach (var ve in vehicleEvents)
        {
            var key = (ve.VehicleID, ve.Location);
            var eventTime = ve.GetDateTime();

            if (ve.Event == "Arrive")
            {
                vehicleEnterTimes[key] = eventTime;
            }
            else if (ve.Event == "Complete")
            {
                if (vehicleEnterTimes.TryGetValue(key, out DateTime startTime))
                {
                    var transitTime = eventTime - startTime;
                    if (!pathTransitDetails.ContainsKey(ve.Location))
                    {
                        pathTransitDetails[ve.Location] = new List<PathTransitTime>();
                    }
                    pathTransitDetails[ve.Location].Add(new PathTransitTime { VehicleID = ve.VehicleID, TransitTime = transitTime });
                    vehicleTotalTransitTimes[ve.VehicleID] = vehicleTotalTransitTimes.GetValueOrDefault(ve.VehicleID) + transitTime;

                    vehicleEnterTimes.Remove(key);
                }
            }
        }

        // Output the transit times for each path and each vehicle
        foreach (var path in pathTransitDetails)
        {
            Console.WriteLine($"Path {path.Key}:");
            var totalTransitTime = TimeSpan.Zero;
            foreach (var transit in path.Value)
            {
                Console.WriteLine($"  Vehicle {transit.VehicleID}: Transit time = {transit.TransitTime.TotalSeconds} seconds");
                totalTransitTime += transit.TransitTime;
            }
            var averageTransitTime = path.Value.Count > 0 ? totalTransitTime.TotalSeconds / path.Value.Count : 0;
            Console.WriteLine($"  Average transit time for path: {averageTransitTime} seconds");
        }

        // Output the total transit time for each vehicle
        Console.WriteLine("\nTotal transit times for each vehicle:");
        foreach (var vehicle in vehicleTotalTransitTimes)
        {
            Console.WriteLine($"  Vehicle {vehicle.Key}: Total transit time = {vehicle.Value.TotalSeconds} seconds");
        }
    }
}
*/