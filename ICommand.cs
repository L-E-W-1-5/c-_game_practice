﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects
{
    interface ICommand
    {
        void Run(NewGame newGame);
    }
}
