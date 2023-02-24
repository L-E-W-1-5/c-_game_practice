using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects
{
    internal class MoveEast : ICommand
    {
        public void Run(NewGame newGame)
        {
            // if (newGame.gridPosition.X < newGame.X - 1)
            if (newGame.Column < newGame.X - 1)
            {
                // newGame.gridPosition.X++;
                newGame.Column++;
                Console.WriteLine($"You are now in room {newGame.Column},{newGame.Row}");
            }
            else
            {
                Console.WriteLine("you have reached the edge of the playing area and cannot move further east");
            }
        }
    }
}
