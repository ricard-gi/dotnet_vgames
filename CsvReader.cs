
using System.Collections.Generic;
using System.Globalization;
using System.IO;


public class CsvReader
{
    public static List<VideoGame> ReadGames(string filePath)
    {
        var games = new List<VideoGame>();

        using (var reader = new StreamReader(filePath))
        {
            // Saltar la primera línia (encapçalament)
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var fields = ParseCsvLine(line);

                if (fields.Length != 11)
                {
                    Console.WriteLine($"Línia incorrecta, saltant: {string.Join(",", fields)}");
                    continue;
                }

                try
                {
                    games.Add(new VideoGame
                    {
                        Rank = int.Parse(fields[0]),
                        Name = fields[1],
                        Platform = fields[2],
                        Year = int.TryParse(fields[3], out int year) ? year : 0,
                        Genre = fields[4],
                        Publisher = fields[5],
                        NASales = double.TryParse(fields[6], NumberStyles.Any, CultureInfo.InvariantCulture, out double naSales) ? naSales : 0.0,
                        EUSales = double.TryParse(fields[7], NumberStyles.Any, CultureInfo.InvariantCulture, out double euSales) ? euSales : 0.0,
                        JPSales = double.TryParse(fields[8], NumberStyles.Any, CultureInfo.InvariantCulture, out double jpSales) ? jpSales : 0.0,
                        OtherSales = double.TryParse(fields[9], NumberStyles.Any, CultureInfo.InvariantCulture, out double otherSales) ? otherSales : 0.0,
                        GlobalSales = double.TryParse(fields[10], NumberStyles.Any, CultureInfo.InvariantCulture, out double globalSales) ? globalSales : 0.0
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processant la línia: {ex.Message}");
                }
            }
        }

        return games;
    }

    // Funció auxiliar per gestionar línies amb cometes
    private static string[] ParseCsvLine(string line)
    {
        var result = new List<string>();
        var currentField = string.Empty;
        var inQuotes = false;

        foreach (char c in line)
        {
            if (c == '"' && !inQuotes)
            {
                // Inici d'una cadena entre cometes
                inQuotes = true;
            }
            else if (c == '"' && inQuotes)
            {
                // Fi d'una cadena entre cometes
                inQuotes = false;
            }
            else if (c == ',' && !inQuotes)
            {
                // Separador de camp fora de cometes
                result.Add(currentField);
                currentField = string.Empty;
            }
            else
            {
                // Afegeix el caràcter a l'actual camp
                currentField += c;
            }
        }

        // Afegeix l'últim camp
        if (!string.IsNullOrEmpty(currentField))
        {
            result.Add(currentField);
        }

        return result.ToArray();
    }
}
