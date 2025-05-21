using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperFarmer
{
    public class Player
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public int RabbitNumber { get; set; } = 1;
        public int SheepNumber { get; set; } = 0;
        public int PigNumber { get; set; } = 0;
        public int CowNumber { get; set; } = 0;
        public int HorseNumber { get; set; } = 0;
        public int SmallDogsNumber { get; set; } = 0;
        public int BigDogsNumber { get; set; } = 0;

        public Player(string name, int id)
        {
            Name = name;
            ID = id;
        }
    }
}
