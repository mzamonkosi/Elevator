using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    class Building
    {
        public List<Elevator> Elevators { get; } = new List<Elevator>();

        public Building(int numElevators, int maxCapacity)
        {
            for (int i = 0; i < numElevators; i++)
            {
                Elevators.Add(new Elevator(maxCapacity));
            }
        }

        public Elevator GetNearestElevator(int floor)
        {
            var nearestElevator = Elevators
                .OrderBy(e => Math.Abs(e.CurrentFloor - floor))
                .ThenBy(e => e.Direction == ElevatorDirection.Idle ? 0 : 1)
                .FirstOrDefault();

            return nearestElevator;
        }
    }
}
