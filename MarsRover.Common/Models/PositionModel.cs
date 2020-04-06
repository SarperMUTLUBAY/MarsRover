using MarsRover.Common.Enums;

namespace MarsRover.Common.Models {
    public class PositionModel {
        public int x { get; set; }
        public int y { get; set; }

        public Direction Direction { get; set; }

        public override string ToString() {
            return $"{x} {y} {Direction}";
        }

        public PositionModel CalculateNextPosition() {
            PositionModel nextPosition = new PositionModel {
                x = this.x,
                y = this.y,
                Direction = this.Direction
            };

            switch (this.Direction) {
                case Direction.N:
                    nextPosition.y++;
                    break;
                case Direction.S:
                    nextPosition.y--;
                    break;
                case Direction.E:
                    nextPosition.x++;
                    break;
                case Direction.W:
                    nextPosition.x--;
                    break;
            }

            return nextPosition;
        }

        public Direction CalculateRotateDirection(char to) {
            return this.Direction = to == 'L' ? Constants.Rotation[this.Direction].Left : Constants.Rotation[this.Direction].Right;
        }
    }
}
