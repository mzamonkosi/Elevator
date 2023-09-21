using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    class Passenger
    {
        public string Name { get; }
        public int Weight { get; }
        public int destinationfloors  { get; }
        public Passenger(string name, int weight, int DestinationFloor)
        {
            Name = name;
            Weight = weight;
            destinationfloors = DestinationFloor;
        }

    }
}
