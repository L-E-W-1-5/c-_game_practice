using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects
{
    internal class StartTurn
    {
        //static NewGame game { get; } = new NewGame();
       static NewGame game;

        public static NewGame Turn(NewGame Game, string c)
        {
            bool Valid = false;
            while (!Valid)
            {
                bool ValidCommand = Validate(c);
                if (ValidCommand)
                {
                    game = Game;
                    if (c == "north") { TurnNorth(); }
                    else if (c == "south") { TurnSouth(); }
                    else if (c == "east") { TurnEast(); }
                    else if (c == "west") { TurnWest(); }
                    Valid = true;
                }
                else if(!ValidCommand)
                {
                    Console.WriteLine("you must enter a valid command, North, East, South or West.");
                    c = Console.ReadLine().ToLower();
                }
            }

            return game;
        }
        static bool Validate(string c)
        {
            if (c == "north" || c == "east" || c == "south" || c == "west") { return true; }
           else
            return false;
        }
        static void TurnNorth()
        {
            MoveNorth MN = new MoveNorth();
            game.command = MN;
            
        }
        static void TurnEast()
        {
            MoveEast ME = new MoveEast();
            game.command = ME;
        }
        static void TurnSouth()
        {
            MoveSouth MS = new MoveSouth();
            game.command = MS;
        }
        static void TurnWest()
        {
            MoveWest MW = new MoveWest();
            game.command = MW;
        }
    }
}
