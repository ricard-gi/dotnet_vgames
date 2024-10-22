using System;
using System.Collections.Generic;
using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "vgsales.csv";
            var games = CsvReader.ReadGames(filePath);

            while (true)
            {
                Console.WriteLine("==== MENU ====");
                Console.WriteLine("1. Llistar els jocs més venuts");
                Console.WriteLine("2. Buscar informació d'un joc");
                Console.WriteLine("3. Estadístiques per gènere");
                Console.WriteLine("4. Estadístiques per plataforma");
                Console.WriteLine("5. Top 5 gèneres més venuts (Global)");
                Console.WriteLine("6. Top 3 gèneres més venuts per regió");
                Console.WriteLine("7. Top 3 plataformes més venudes per regió");
                Console.WriteLine("8. Sortir");
                Console.Write("Tria una opció: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Stats.ListTopSellingGames(games);
                        break;
                    case "2":
                        Stats.SearchGameByName(games);
                        break;
                    case "3":
                        Stats.ShowGenreStatistics(games);
                        break;
                    case "4":
                        Stats.ShowPlatformStatistics(games);
                        break;
                    case "5":
                        Stats.ShowTopGenresGlobal(games);
                        break;
                    case "6":
                        Stats.ShowTopGenresByRegion(games);
                        break;
                    case "7":
                        Stats.ShowTopPlatformsByRegion(games);
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Opció no vàlida!");
                        break;
                }
            }
        }

    }
