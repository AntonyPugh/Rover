using Rover.Models;
using System;

namespace Rover
{
    public static class Moves
    {
        public static T Turn<T>(this T placement, Enums.Turn turn) where T : Placement
        {
            placement.Direction = turn == Enums.Turn.R ? placement.Direction.TurnRight() : placement.Direction.TurnLeft();

            return placement;
        }

        public static Placement Move<T>(this T placement) where T : Placement
        {
            switch (placement.Direction)
            {
                case Enums.Cardinal.N:
                    placement.PositionY++;
                    break;
                case Enums.Cardinal.S:
                    placement.PositionY--;
                    break;
                case Enums.Cardinal.E:
                    placement.PositionX++;
                    break;
                case Enums.Cardinal.W:
                    placement.PositionX--;
                    break;
                default:
                    break;
            }

            return placement;
        }

        public static bool InCrater<T>(this T placement) where T : Placement =>
            placement.PositionX <= (int)Enums.Boundary.Max && placement.PositionX >= (int)Enums.Boundary.Min &&
            placement.PositionY <= (int)Enums.Boundary.Max && placement.PositionY >= (int)Enums.Boundary.Min;

        //https://stackoverflow.com/a/643438
        private static T TurnRight<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(string.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }

        private static T TurnLeft<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(string.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf(Arr, src) - 1;
            return (j < 0) ? Arr[^1] : Arr[j];
        }
    }
}
