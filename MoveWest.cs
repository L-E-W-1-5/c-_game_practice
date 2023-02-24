using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects
{
    internal class MoveWest : ICommand
    {
        public void Run(NewGame newGame)
        {
            if (newGame.Column > 0)
            {
                // newGame.gridPosition.X--;
                newGame.Column--;
                Console.WriteLine($"You are now in room {newGame.Column},{newGame.Row}");
            }
            else
            {
                Console.WriteLine("you have reached the edge of the playing area and cannot move further west");
            }
        }
    }
}
