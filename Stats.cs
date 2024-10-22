using System;
using System.Collections.Generic;
using System.Linq;

class Stats
{
    // Funció per llistar els jocs més venuts
    public static void ListTopSellingGames(List<VideoGame> games)
    {
        var topGames = games.OrderByDescending(g => g.GlobalSales).Take(10);
        foreach (var game in topGames)
        {
            Console.WriteLine(game);
        }
    }

    // Funció per cercar un joc pel nom
    public static void SearchGameByName(List<VideoGame> games)
    {
        Console.Write("Introdueix el nom del joc: ");
        string gameName = Console.ReadLine();

        var game = games.FirstOrDefault(g => g.Name != null && g.Name.Equals(gameName, StringComparison.OrdinalIgnoreCase));

        if (game != null)
        {
            Console.WriteLine(game);
        }
        else
        {
            Console.WriteLine("No s'ha trobat el joc.");
        }
    }

    // Funció per trobar els Top 5 gèneres més venuts globalment
    public static void ShowTopGenresGlobal(List<VideoGame> games)
    {
        var totalGlobalSales = games.Sum(g => g.GlobalSales);
        var topGenres = games
            .GroupBy(g => g.Genre)
            //Select és similar a "map" de javascript
            .Select(group => new
            {
                Genre = group.Key,
                TotalSales = group.Sum(g => g.GlobalSales),
                Percentage = (group.Sum(g => g.GlobalSales) / totalGlobalSales) * 100
            })
            .OrderByDescending(stat => stat.TotalSales)
            .Take(5);

        Console.WriteLine("Top 5 gèneres més venuts globalment:");
        foreach (var genre in topGenres)
        {
            Console.WriteLine($"{genre.Genre}: {Math.Round(genre.TotalSales, 2)}M - {Math.Round(genre.Percentage, 2)}%");
        }
    }

    // Funció per trobar Top 3 gèneres més venuts per regió
    public static void ShowTopGenresByRegion(List<VideoGame> games)
    {
        Console.WriteLine("Top 3 gèneres per regió:");


    }

    // Funció per trobar Top 3 plataformes més venudes per regió
    public static void ShowTopPlatformsByRegion(List<VideoGame> games)
    {
        Console.WriteLine("Top 3 plataformes per regió:");
    }

    // Funcions per estadístiques per gènere i plataforma
    public static void ShowGenreStatistics(List<VideoGame> games)
    {
              Console.WriteLine("Estadistiques per gènere:");
    }

    public static void ShowPlatformStatistics(List<VideoGame> games)
    {
        Console.WriteLine("Estadistiques per plataforma:");
    }
}
