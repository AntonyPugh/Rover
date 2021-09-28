using static Rover.Models.Enums;

namespace Rover.Models
{
    public class Placement
    {
        public Placement(int positionX, int positionY, Cardinal direction)
        {
            PositionX = positionX;
            PositionY = positionY;
            Direction = direction;
        }

        public Placement(Placement placement)
        {
            PositionX = placement.PositionX;
            PositionY = placement.PositionY;
            Direction = placement.Direction;
        }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public Cardinal Direction { get; set; }
    }
}
