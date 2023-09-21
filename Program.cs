using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    class Program
    {

        static void Main(string[] args)
        {
            Building building = new Building(numElevators: Convert.ToInt32(Settings.numElevators), maxCapacity: Convert.ToInt32(Settings.maxCapacity));
            try
            {


                // Move an elevator to a specific floor.
                var elevator1 = building.Elevators[2];
                List<Passenger> passengerslist = new List<Passenger>();
                Console.WriteLine("Call the Elevator to a specific floor");

                int input = Convert.ToInt32(Console.ReadLine());
                elevator1.MoveToFloor(input);
                Console.WriteLine("Enter number of passangers");
                int numberofPassangers = Convert.ToInt32(Console.ReadLine());
                int totalnumberofPassangers = numberofPassangers;
                while (numberofPassangers > 0)
                {
                    numberofPassangers -= 1;

                    Console.WriteLine("Enter passanger name");

                    String PassangerName = Console.ReadLine();
                    Console.WriteLine("Enter weight of the passanger");

                    int weight = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Destination floor");

                    int Destinationfloor = Convert.ToInt32(Console.ReadLine());


                    // Create passengers.
                    var passenger = new Passenger(name: PassangerName, weight: Convert.ToInt32(weight), DestinationFloor: Convert.ToInt32(Destinationfloor));
                    passengerslist.Add(passenger);

                    Console.Clear();
                }
                foreach (var passage in passengerslist)
                {
                    if (elevator1.BoardPassenger(passage))
                    {
                        Console.WriteLine($"{passage.Name} boarded the elevator.");
                    }

                }


                // Show elevator status.
                elevator1.ShowStatus();
                foreach (var passage in passengerslist)
                {
                    elevator1.DisembarkPassengers(passage.destinationfloors);
                }
                Console.WriteLine("after disembarking.");
                elevator1.ShowStatus();
                foreach (var passage in passengerslist)
                {
                    var nearestElevator = building.GetNearestElevator(passage.destinationfloors);
                    Console.WriteLine($"The nearest elevator is on floor {nearestElevator.CurrentFloor}.");
                }
                Console.ReadKey();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
