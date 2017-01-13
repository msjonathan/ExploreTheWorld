using ExploreTheWorld.Data.Entities;
using ExploreTheWorld.DataGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ExploreTheWorld data generator!");

        var extractionTypes = new Dictionary<ExtractionType, string>()
        {
             { ExtractionType.Airport , "airports.dat" },
             { ExtractionType.Airline , "airlines.dat" },
             { ExtractionType.Route , "routes.dat" }
        };

        ExtractData(extractionTypes);
      

        Console.WriteLine("Press a key to close this window.");
        Console.ReadKey();
    }

    static void ExtractData(Dictionary<ExtractionType, string> extractionTypes)
    {
        var basePath = @".\\Data";
        var countries = new List<Country>();
        var airports = new List<Airport>();
        var airlines = new List<Airline>();
        var routes = new List<Route>();

        foreach (var data in extractionTypes)
        {
            using (var fileStream = File.OpenRead(Path.Combine(basePath, data.Value)))
            using (var reader = new StreamReader(fileStream))
            {
                string rawline;
                while ((rawline = reader.ReadLine()) != null)
                {
                    var splittedData = rawline.Split(',');

                    switch (data.Key)
                    {
                        case ExtractionType.Airport:
                            var country = ParseCountry(Clean(splittedData[3]), countries);
                            airports.Add(new Airport()
                            {
                                Name = Clean(splittedData[1]),
                                City = Clean(splittedData[2]),
                                Country = country,
                                ITATA = Clean(splittedData[4]),
                                ICAO = Clean(splittedData[5]),
                                Latitude = Clean(splittedData[6]),
                                Longitude = Clean(splittedData[7])
                            });
                            break;
                        case ExtractionType.Airline:
                            break;
                        case ExtractionType.Route:
                            break;
                        default:
                            throw new ArgumentException("Unknown extraction type.");
                    }
                }
            }
        }
    }

    private static string Clean(string rawData)
    {
       return rawData.Trim('"');
    }
    private static Country ParseCountry(string rawCountry, List<Country> countries)
    {
        var country = countries.SingleOrDefault(f => f.Name.Equals(rawCountry, StringComparison.OrdinalIgnoreCase));
        if (country == null)
        {
            country = new Country() { Name = rawCountry };
            countries.Add(country);
        }
        return country;
    }
}