using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects
{
    internal class Coordinate
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int x, int y)
        {
            X = x; Y = y; 
        }

        public static bool operator ==(Coordinate a, Coordinate b)
        {
            if (a.X == b.X && a.Y == b.Y)
            {
                return true;
            }

            return false;
        }
    }
}
