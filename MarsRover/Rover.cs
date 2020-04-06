using MarsRover.Common.Enums;
using MarsRover.Common.Extensions;
using MarsRover.Common.Models;
using System;

namespace MarsRover {
    public class Rover {
        public PositionModel Position { get; private set; }

        public Rover(int x, int y, Direction direction) {
            Position = new PositionModel {
                x = x,
                y = y,
                Direction = direction
            };
        }

        public void ProcessControlCommands(string commands, Func<int, int, bool> predicate) {
            string fallback = "";

            try {
                foreach (var command in commands) {
                    switch (command) {
                        case 'L':
                            fallback += "R";
                            Turn(command);
                            break;
                        case 'R':
                            fallback += "L";
                            Turn(command);
                            break;
                        case 'M':
                            fallback += "LLMLL";
                            Move(predicate);
                            break;
                        default:
                            throw new Exception($"Invalid command : {command}. Rover is returning to its previous location.");
                    }
                }
            } catch (Exception e) {
                Console.WriteLine($"The rover had a problem with the {this.Position} coordinates.");
                Console.WriteLine(e.Message);
                ProcessControlCommands(fallback.Reverse(), predicate);
            }
        }

        public void Turn(char to) {
            Position.Direction = this.Position.CalculateRotateDirection(to);
        }

        public void Move(Func<int, int, bool> predicate) {
            var nextPosition = this.Position.CalculateNextPosition();

            var positionAvailable = predicate(nextPosition.x, nextPosition.y);

            if (positionAvailable) {
                this.Position = nextPosition;
            } else {
                throw new Exception($"x : {nextPosition.x} and y : {nextPosition.y} Position is not available !");
            }
        }
    }
}
