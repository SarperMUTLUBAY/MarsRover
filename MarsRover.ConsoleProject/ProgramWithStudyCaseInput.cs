using MarsRover.Common.Enums;
using System;

namespace MarsRover.ConsoleProject {
    public class ProgramWithStudyCaseInput : IMarsRoverProgram {
        public void Run() {
            Console.WriteLine("Running study case process...");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Mars right and top coordinate: 5 and 5");
            var localMars = new Mars(5, 5);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Add first rover on position: 1 2 N");
            localMars.AddRover(1, 2, Direction.N);

            Console.WriteLine("Run control command in first rover: LMLMLMLMM");
            localMars.ProcessControlCommands("LMLMLMLMM");

            Console.Write("First rover current position: ");
            Console.WriteLine(localMars.GetRoverPosition());

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Add second rover on position: 3 3 E");
            localMars.AddRover(3, 3, Direction.E, true);

            Console.WriteLine("Run control command in second rover: MMRMMRMRRM");
            localMars.ProcessControlCommands("MMRMMRMRRM");

            Console.Write("Second rover current position: ");
            Console.WriteLine(localMars.GetRoverPosition());
            Console.WriteLine("-----------------------------------");
        }
    }
}
