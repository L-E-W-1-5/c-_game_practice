using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public static void Start()
        {
            bool play = true;
            while (play)
            {

                bool gameStatus = true;
                Console.WriteLine("You have entered a Labrynth, aside from this room, at the entrance");
                Console.WriteLine("of the Labrynth, it is pitch black and you will need to use your");
                Console.WriteLine("other senses to navigate.\nYou must find your way to the fountain,");
                Console.WriteLine("turn it on, and get back out! The Labrynth is a 4x4 grid and you");
                Console.WriteLine("start at the lower left corner. Using the commands 'North', 'East,");
                Console.WriteLine("'South' and 'West', you must traverse the grid.\n Good Luck!");

                Console.WriteLine("Easy, Medium or Hard?");
                string reply = Console.ReadLine().ToLower();
                NewGame game = new NewGame(reply); DateTime startTime = DateTime.Now;

                while (gameStatus) 
                {
                    Console.WriteLine("Make your move");
                    string choice = Console.ReadLine().ToLower();
                    StartTurn.Turn(game, choice);
                    game.TakeTurn();
                    if (game.FountainActivated == true && game.gridPosition == "0,0")
                    {
                        DateTime endTime = DateTime.Now;
                        TimeSpan timeTaken = startTime - endTime;
                        Console.WriteLine($"Time Taken: {timeTaken}");
                        gameStatus = false;
                    }
                    if (game.Death == true)
                    {
                        game.FountainActivated = false;
                        game.Row = 0; game.Column = 0;
                        gameStatus = false;
                    }


                }
                Console.WriteLine("Would you like to try again?");
                string reply1 = Console.ReadLine().ToLower();
                if (reply1 == "yes" || reply1 == "y")
                {

                    gameStatus = true;
                }
                else
                {
                    play = false;
                    Console.WriteLine("Thanks for playing");
                }
            }
        }
    }
}

