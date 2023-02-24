using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects
{
    internal class NewGame
    {

        public int X { get; set; }      
        public int Y { get; set; }
        public string[,] grid;
        public int Row { get; set; } = 0;  // Can store the user position as a Coordinate instead?
        public int Column { get; set; } = 0;
        // public Coordinate gridPosition {get; set;}
        Dictionary<Coordinate, Action> rooms = new();
        public bool FountainActivated = false;
        public string gridPosition;
        public bool Death = false;
        string reply;
       
        List<Coordinate> Pits = new List<Coordinate>();
        public ICommand command { get; set; }

        public string this[int row, int column]     // Included 12/04/2022. Not impemented. Would replace the string 'gridPosition'?
        {
            get => grid[row, column];   
            set => grid[row, column] = value;

            // 07/01/23... a better way could be to access the grid through the coordinates? Could loop through the pit coords in the 
            // GridPosition function?

            // public string this[Coordinate coord] {
            //     get => grid[coord.X, coord.Y];
            //     set => grid[coord.X, coord.Y];
            // }

            // this[gridPosition]
        }

        public NewGame(string reply)
        {
            // gridPosition = new(0,0); when we change to Coords
            this.reply = reply;
            bool difficulty = true;
            while (difficulty)
            {
               // Console.WriteLine("Easy, Medium or Hard?");
                //reply = Console.ReadLine().ToLower();
                if (reply == "easy")
                {
                    X = 4; Y = 4; difficulty = false;
                    string[,] grid = new string[X, Y]; 
                    this.grid = grid;
                }
                else if (reply == "medium")
                {
                    X = 5; Y = 5; difficulty = false;
                    string[,] grid = new string[X, Y];
                    this.grid = grid;
                }
                else if (reply == "hard")
                {
                    X = 6; Y = 6; difficulty = false;
                    string[,] grid = new string[X, Y];
                    this.grid = grid;
                }
                else
                {
                    difficulty = true;
                }
            }
            InitializeGrid();InitializeSpecialRooms();

        }
        public void TakeTurn()
        {

            if (command != null)
            {
                command.Run(this);
            }
            gridPosition = $"{ Column},{ Row}";
          
            GridPosition();
            
          

        }
        public void GridPosition()
        {

            // when this function gets called, we can just loop through the keys until we find a match with gridPosition, then run the function

            foreach(KeyValuePair<Coordinate, Action> entry in rooms)
            {
                if (gridPosition == entry.Key)
                {
                    entry.Value.Invoke();   // very much doubt i can do it like this but you get the idea :)
                }
            }
            Coordinate coord = new Coordinate(Column, Row);

            switch (gridPosition)
            {
                case "0,2":
                    TheFountainRoom();
                    break;
                case "0,0":
                    if (FountainActivated == true)
                    {
                        Console.WriteLine("You Win");
                    }
                    else
                    {
                        Console.WriteLine("you must activate the fountain first");
                    }
                    break;
                case "2,2":
                    Pit();
                    break;
                case "0,1":
                    Pit();
                    break;      // Rather than this, could store all special coordinates in a dictionary and just check if your coords are there
                case "3,2":     // If not, have a generic answer...
                    Pit();
                    break;
                case "2,0":
                    Pit();
                    break;
                default:
                    Console.WriteLine($"{ grid[Column,Row]}");
                    int currentRow = Row;
                    int currentColumn = Column;
                    foreach (Coordinate c in Pits)
                    {
                        bool pitDanger = Utility.IsAdjacent(coord, c);
                        if (pitDanger)
                        {
                            Console.WriteLine("You can hear an echo from nearby, could mean a pit is lurking in an adjacent room! dum dum duuum!");
                        }
                    }
                    break;

                    // TODO - refine method for hearing a pit in adjacent room
            }
        }
        public void InitializeGrid()
        {

            for (int i = 0; i < X; i++)
            {
                for (int s = 0; s < Y; s++)
                {
                    grid[s, i] = "Empty Room";
                }

            }
           


        }
        public void InitializeSpecialRooms()
        {

            // Can have a dictionary with the coords as the key and a function as the value, each time the GridPosition function runs
            // we can loop through the keys until it matches the current coords, then run the function.
            
            rooms.Add(new Coordinate(0,2), TheFountainRoom);    // Not sure which 1.
            rooms[new Coordinate(0,2)] = TheFountainRoom;
            
            
                            // 07/01/23 - better way? :)
            grid[2, 0] = "Pit"; Pits.Add(new Coordinate(2, 0)); // Coordinate Pit1 = new Coordinate(2, 0); Pits.Add(Pit1); 
            grid[0, 2] = "Fountain"; 
            grid[0, 1] = "Pit"; Coordinate Pit2 = new Coordinate(0, 1); Pits.Add(Pit2);
            grid[2, 2] = "Pit"; Coordinate Pit3 = new Coordinate(2, 2); Pits.Add(Pit3);
            grid[3, 2] = "Pit"; Coordinate Pit4 = new Coordinate(3, 2); Pits.Add(Pit4);
            // TODO - Create other rooms + rooms for easy medium + hard
        }
        public void TheFountainRoom()
        {
            Console.WriteLine("You can hear water dripping and feel moisture in the air, what you wanna do?");
            string d = Console.ReadLine().ToLower();
            if (d == "enable")
            {
                FountainActivated = true;
                Console.WriteLine("You have activated the fountain! You just need to find your way out..");
            }
            
        }
        public void Pit()
        {
            Console.WriteLine("You fell down a pit and died, nice one, give yourself a round of applause");
            Console.WriteLine("You think you can handle pressing enter? or will that be a struggle too?");
            Console.ReadKey();
            Death = true;
        }
        
        
    }
   
}



