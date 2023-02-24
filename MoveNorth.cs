using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects
{
    internal class MoveNorth : ICommand
    {
        public void Run(NewGame newGame)
        {
           
            if (newGame.Row < newGame.Y - 1)
            {
                // newGame.gridPosition.Y++;
                newGame.Row++;
                Console.WriteLine($"You are now in room {newGame.Column},{newGame.Row}");
            }
            else
            {
                Console.WriteLine("you have reached the edge of the playing area and cannot move further north");
            }
        }
    }
}
