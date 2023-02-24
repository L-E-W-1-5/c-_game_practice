using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects
{
    internal class MoveSouth : ICommand
    {
        public void Run(NewGame newGame)
        {
            if (newGame.Row > 0)
            {
                // newGame.gridPosition.Y--;
                newGame.Row--;
                Console.WriteLine($"You are now in room {newGame.Column},{newGame.Row}");
            }
            else
            {
                Console.WriteLine("you have reached the edge of the playing area and cannot move further south");
            }
        }
    }
}
