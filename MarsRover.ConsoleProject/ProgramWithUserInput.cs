using MarsRover.Common.Enums;
using System;

namespace MarsRover.ConsoleProject {
    public class ProgramWithUserInput : IMarsRoverProgram {
        private Mars mars;

        public void Run() {
            Console.WriteLine("Running manual process...");
            Console.WriteLine("-----------------------------------");

            bool continueProcess = true;
            while (continueProcess) {
                try {
                    Console.WriteLine("What do you want?");
                    Console.WriteLine("1 - Create new mars");
                    Console.WriteLine("2 - Add new rover");
                    Console.WriteLine("3 - Enter Process command");
                    Console.WriteLine("4 - Get active rover position");
                    Console.WriteLine("5 - List rovers");
                    Console.WriteLine("6 - Change active rover");
                    Console.WriteLine("7 - Return to main menu");
                    Console.WriteLine("-----------------------------------");

                    Console.Write("Please enter process number : ");
                    var process = Console.ReadLine();

                    switch (process) {
                        case "1":
                            CreateMars();
                            break;
                        case "2":
                            AddNewRover();
                            break;
                        case "3":
                            ProcessCommand();
                            break;
                        case "4":
                            GetActiveRoverPosition();
                            break;
                        case "5":
                            ListRovers();
                            break;
                        case "6":
                            ChangeActiveRover();
                            break;
                        case "7":
                            continueProcess = false;
                            break;
                        default:
                            Console.WriteLine("Invalid process!");
                            continue;
                    }
                } catch (Exception e) {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine($"# Error : {e.Message}");
                    Console.WriteLine("-----------------------------------");
                }
            }
        }

        private void CreateMars() {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1 - Create New Mars");
            Console.Write("Please enter right coordinate: ");
            string widthString = Console.ReadLine();
            Console.Write("Please enter top coordinate: ");
            string heightString = Console.ReadLine();

            bool widthParse = int.TryParse(widthString, out var width);

            bool heightParse = int.TryParse(heightString, out var height);

            if (!widthParse || !heightParse) {
                throw new Exception("right or top coordinate is invalid, please try again.");
            }

            mars = new Mars(width, height);
            Console.WriteLine("-----------------------------------");
        }

        private void AddNewRover() {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("2 - Add New Rover");
            ValidateMars(false);

            Console.Write("Please enter x coordinate: ");
            string xString = Console.ReadLine();
            Console.Write("Please enter y coordinate: ");
            string yString = Console.ReadLine();
            Console.Write("Please enter facing direction (N,S,E,W): ");
            string facingString = Console.ReadLine();
            Console.Write("Mark new vehicle actively? (Y/N): ");
            string activeString = Console.ReadLine();

            bool widthParse = int.TryParse(xString, out var x);

            bool heightParse = int.TryParse(yString, out var y);

            bool facingParse = Enum.TryParse(facingString, out Direction facing);

            bool active = activeString == "Y";

            if (!widthParse || !heightParse || !facingParse) {
                throw new Exception("x - y coordinate or facing is invalid, please try again.");
            }

            mars.AddRover(x, y, facing, active);
            Console.WriteLine("-----------------------------------");
        }

        private void ProcessCommand() {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("3 - Process Command");
            ValidateMars(true);

            Console.Write("Please enter your command combination - (L)eft | (R)ight | (M)ove : ");
            var commands = Console.ReadLine();
            mars.ProcessControlCommands(commands);
            Console.WriteLine($"Rover new position: {mars.GetRoverPosition()}");
            Console.WriteLine("-----------------------------------");
        }

        private void GetActiveRoverPosition() {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("4 - Get Active Rover Position");
            ValidateMars(true);

            Console.WriteLine($"Active rover position: {mars.GetRoverPosition()}");
            Console.WriteLine("-----------------------------------");
        }

        private void ListRovers() {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("5 - List Rovers");
            // validate active rover because first rover automatically set active
            ValidateMars(true);

            int index = 0;
            foreach (var rover in mars.Rovers) {
                Console.WriteLine($"{index + 1}. Rover number {index} and position is {rover.Position}");
                index++;
            }
            Console.WriteLine("-----------------------------------");
        }

        private void ChangeActiveRover() {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("6 - Change Active Rover");
            ValidateMars(true);
            while (true) {
                Console.Write("Please enter rover number or 'e' for exit: ");
                var indexString = Console.ReadLine();

                if (indexString?.ToLower() == "e") {
                    break;
                }

                var indexParse = int.TryParse(indexString, out var index);

                if (!indexParse) {
                    Console.WriteLine("Please enter numeric character or 'e' for exit");
                    continue;
                }

                if (mars.RoverCount < index + 1) {
                    throw new Exception("Rover index is invalid, please check index number and try again.");
                }

                mars.ChangeActiveRover(index);
                Console.WriteLine($"Rover {index} is active.");
                break;
            }
            Console.WriteLine("-----------------------------------");
        }

        private void ValidateMars(bool validateActiveRover) {
            if (mars == null) {
                throw new Exception("First of all you should be create new mars!");
            }

            if (validateActiveRover) {
                if (mars.RoverCount == 0) {
                    throw new Exception("Please add a rover!");
                }

                if (mars.ActiveRoverIndex == null) {
                    throw new Exception("Please set active any rover!");
                }
            }
        }
    }
}
