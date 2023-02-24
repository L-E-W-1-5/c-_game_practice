using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects
{
    internal static class Utility
    {
        //static Coordinate Pit = new Coordinate(2, 0);
       // static Coordinate Pit2 = new Coordinate(0, 1);
        public static bool IsAdjacent(Coordinate A, Coordinate B)
        {
            int differenceX = A.X - B.X;
            int differenceY = A.Y - B.Y;
            if (Math.Abs(differenceX) == 1 && differenceY == 0) return true;
            if (Math.Abs(differenceY) == 1 && differenceX == 0) return true;
            return false;
        }
    }
}

