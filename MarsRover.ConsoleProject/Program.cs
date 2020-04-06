using System;

namespace MarsRover.ConsoleProject {
    class Program {
        static void Main() {
            bool continueProcess = true;
            while (continueProcess) {
                Console.WriteLine("What do you want?");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("1 - Run Study Case");
                Console.WriteLine("2 - Run Program Manual");
                Console.WriteLine("3 - Exit program");
                Console.WriteLine("-----------------------------------");

                Console.Write("Please enter process number : ");
                var process = Console.ReadLine();
                Console.WriteLine("-----------------------------------");

                IMarsRoverProgram program;
                switch (process) {
                    case "1":
                        program = new ProgramWithStudyCaseInput();
                        break;
                    case "2":
                        program = new ProgramWithUserInput();
                        break;
                    case "3":
                        continueProcess = false;
                        continue;
                    default:
                        throw new Exception("Invalid process. please use valid process (1, 2, 3)");
                }

                program.Run();
            }
        }
    }
}
