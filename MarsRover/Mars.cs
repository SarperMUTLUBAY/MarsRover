using MarsRover.Common.Enums;
using MarsRover.Common.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover {
    public class Mars {
        private readonly ArrayList rovers;

        public int width { get; }
        public int height { get; }

        public IEnumerable<Rover> Rovers => rovers.Cast<Rover>();
        public int RoverCount => rovers.Count;
        public int? ActiveRoverIndex { get; private set; }

        public Mars(int width, int height) {
            rovers = new ArrayList();

            this.width = width;
            this.height = height;
        }

        public int AddRover(int x, int y, Direction direction, bool setActive = false) {
            if (!IsPositionAvailable(x, y)) {
                throw new Exception("Rover position is invalid");
            }

            var rover = new Rover(x, y, direction);
            var roverIndex = rovers.Add(rover);

            if (ActiveRoverIndex == null || setActive) {
                ActiveRoverIndex = roverIndex;
            }

            return roverIndex;
        }

        public void ChangeActiveRover(int roverIndex) {
            if (rovers.Count < roverIndex + 1) {
                throw new Exception("Rover index is invalid, please check index number and try again.");
            }

            ActiveRoverIndex = roverIndex;
        }

        public void ProcessControlCommands(string commands) {
            var rover = GetActiveRover();
            rover.ProcessControlCommands(commands, IsPositionAvailable);
        }

        public PositionModel GetRoverPosition(int? roverIndex = null) {
            var rover = roverIndex != null ? GetRover(roverIndex.Value) : GetActiveRover();
            return rover.Position;
        }

        public bool IsPositionAvailable(int x, int y) {
            if (x >= 0 && x <= width && y >= 0 && y <= height) {
                var coordinateRoverCheck = rovers.Cast<Rover>().ToList().Any(q => q.Position.x == x && q.Position.y == y);
                if (coordinateRoverCheck) {
                    throw new Exception($"Another rover landed x : {x} and y : {y} coordinates.");
                }

                return true;
            }

            return false;
        }

        private Rover GetActiveRover() {
            if (ActiveRoverIndex == null) {
                throw new Exception("There is no active rover.");
            }

            return GetRover(ActiveRoverIndex.Value);
        }

        private Rover GetRover(int roverIndex) {
            if (rovers.Count < roverIndex + 1) {
                throw new Exception("Rover index is invalid, please check index number and try again.");
            }

            return (Rover)rovers[roverIndex];
        }
    }
}
