using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
namespace GameOfDrones
{
    public class BotPlayer
    {
        public static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int P = int.Parse(inputs[0]); // number of players in the game (2 to 4 players)
            int ID = int.Parse(inputs[1]); // ID of your player (0, 1, 2, or 3)
            int D = int.Parse(inputs[2]); // number of drones in each team (3 to 11)
            int Z = int.Parse(inputs[3]); // number of zones on the map (4 to 8)
            for (int i = 0; i < Z; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int X = int.Parse(inputs[0]); // corresponds to the position of the center of a zone. A zone is a circle with a radius of 100 units.
                int Y = int.Parse(inputs[1]);
            }

            // game loop
            while (true)
            {
                for (int i = 0; i < Z; i++)
                {
                    int TID = int.Parse(Console.ReadLine()); // ID of the team controlling the zone (0, 1, 2, or 3) or -1 if it is not controlled. The zones are given in the same order as in the initialization.
                }
                for (int i = 0; i < P; i++)
                {
                    for (int j = 0; j < D; j++)
                    {
                        inputs = Console.ReadLine().Split(' ');
                        int DX = int.Parse(inputs[0]); // The first D lines contain the coordinates of drones of a player with the ID 0, the following D lines those of the drones of player 1, and thus it continues until the last player.
                        int DY = int.Parse(inputs[1]);
                    }
                }
                for (int i = 0; i < D; i++)
                {

                    // Write an action using Console.WriteLine()
                    // To debug: Console.Error.WriteLine("Debug messages...");


                    // output a destination point to be reached by one of your drones. The first line corresponds to the first of your drones that you were provided as input, the next to the second, etc.
                    Console.WriteLine("20 20");
                }
            }
        }
    }
}