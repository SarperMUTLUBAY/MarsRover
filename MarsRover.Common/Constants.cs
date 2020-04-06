using MarsRover.Common.Enums;
using MarsRover.Common.Models;
using System.Collections.Generic;

namespace MarsRover.Common {
    public static class Constants {
        public static Dictionary<Direction, RotationModel> Rotation = new Dictionary<Direction, RotationModel> {
            {Direction.N, new RotationModel{Left = Direction.W, Right = Direction.E} },
            {Direction.E, new RotationModel{Left = Direction.N, Right = Direction.S} },
            {Direction.S, new RotationModel{Left = Direction.E, Right = Direction.W} },
            {Direction.W, new RotationModel{Left = Direction.S, Right = Direction.N} }
        };
    }
}
