using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    class Elevator
    {
        public int CurrentFloor { get; private set; }
        public ElevatorDirection Direction { get; private set; }
        public int MaxCapacity { get; }
        public int CurrentCapacity { get; private set; }
        public List<Passenger> Passengers { get; } = new List<Passenger>();
        private List<int> destinationFloors = new List<int>();
        public Elevator(int maxCapacity)
        {
            CurrentFloor = 1;
            Direction = ElevatorDirection.Idle;
            MaxCapacity = maxCapacity;
        }

        public void MoveToFloor(int floor)
        {
            Direction = floor > CurrentFloor ? ElevatorDirection.Up : floor < CurrentFloor ? ElevatorDirection.Down : ElevatorDirection.Idle;
            CurrentFloor = floor;
        }

        public bool BoardPassenger(Passenger passenger)
        {
            if (CurrentCapacity + passenger.Weight <= MaxCapacity)
            {
                Passengers.Add(passenger);
                CurrentCapacity += passenger.Weight;
                return true;
            }
            return false;
        }

        public void DisembarkPassengers(int destinationFloor)
        {
            var disembarkedPassengers = Passengers.Where(p => p.destinationfloors == destinationFloor).ToList();
            foreach (var passenger in disembarkedPassengers)
            {
                Passengers.Remove(passenger);
                CurrentCapacity -= passenger.Weight;
                Console.WriteLine($"Destination Floor: {passenger.destinationfloors}");
                CurrentFloor = passenger.destinationfloors;

            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Current Floor: {CurrentFloor}");
            Console.WriteLine($"Direction: {Direction}");
            Console.WriteLine($"Number of People: {Passengers.Count}");
            Console.WriteLine($"Weight: {CurrentCapacity} / {MaxCapacity}");
        }
    }
}
