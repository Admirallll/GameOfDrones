using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
namespace GameOfDrones
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = ReadInitialInput();
            while (true)
            {
                LoopInput(game);
                for (int i = 0; i < game.DronesCount; i++)
                {
                    var location = game.GetNotMyZones()
                        .OrderBy(zone => zone.Location.DistanceTo(game.GetMyDrone(i)))
                        .First().Location;
                    Console.WriteLine(location.ToGameString());
                }
            }
        }

        public static Game ReadInitialInput()
        {
            var inputs = Console.ReadLine().Split(' ');
            var P = int.Parse(inputs[0]); // number of players in the game (2 to 4 players)
            var ID = int.Parse(inputs[1]); // ID of your player (0, 1, 2, or 3)
            var D = int.Parse(inputs[2]); // number of drones in each team (3 to 11)
            var Z = int.Parse(inputs[3]); // number of zones on the map (4 to 8)
            var bot = new Game(P, ID, D, Z);
            for (int i = 0; i < bot.ZonesCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                var x = int.Parse(inputs[0]); // corresponds to the position of the center of a zone. A zone is a circle with a radius of 100 units.
                var y = int.Parse(inputs[1]);
                bot.Zones.Add(new Zone(x, y));
            }
            return bot;
        }

        public static void LoopInput(Game bot)
        {
            for (int i = 0; i < bot.ZonesCount; i++)
            {
                var ownerId = int.Parse(Console.ReadLine());
                bot.Zones[i].Owner = ownerId;
            }
            for (int i = 0; i < bot.PlayersInGame; i++)
            {
                bot.Players[i].Drones = new List<Location>();
                for (int j = 0; j < bot.DronesCount; j++)
                {
                    var inputs = Console.ReadLine().Split(' ');
                    var x = int.Parse(inputs[0]); // The first D lines contain the coordinates of drones of a player with the ID 0, the following D lines those of the drones of player 1, and thus it continues until the last player.
                    var y = int.Parse(inputs[1]);
                    bot.Players[i].Drones.Add(new Location(x, y));
                }
            }
        }
    }
    
    public class Game
    {
        public int PlayersInGame { get; }
        public int MyId { get; }
        public int DronesCount { get; }
        public int ZonesCount { get; set; }
        public List<Zone> Zones { get; } 
        public List<Player> Players { get; }

        public Game(int playersInGame, int myId, int dronesCount, int zonesCount)
        {
            PlayersInGame = playersInGame;
            MyId = myId;
            DronesCount = dronesCount;
            ZonesCount = zonesCount;
            Zones = new List<Zone>();
            Players = new List<Player>();
            for (var i = 0; i < playersInGame; i++)
                Players.Add(new Player());
        }

        public IEnumerable<Zone> GetNotMyZones()
        {
            return Zones.Where(zone => zone.Owner != MyId);
        }

        public Location GetMyDrone(int id)
        {
            return Players[MyId].Drones[id];
        }
    }

    public class Player
    {
        public List<Location> Drones { get; set; }
    }

    public class Zone
    {
        public const int Radius = 100;
        public Location Location { get; }
        public int Owner { get; set; }

        public Zone(int x, int y)
        {
            Location = new Location(x, y);
        }
    }

    public class Location
    {
        public int X { get; }
        public int Y { get; }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public string ToGameString()
        {
            return $"{X} {Y}";
        }

        public double DistanceTo(Location location)
        {
            return Math.Sqrt((location.X - X) * (location.X - X) + (location.Y - Y) * (location.Y - Y));
        }
    }
}