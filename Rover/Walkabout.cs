using Rover.Models;
using System;
using System.Linq;

namespace Rover
{
    public class Walkabout
    {
        private static Crater _crater;

        public static Crater Go(Scenario scenario)
        {
            _crater = new Crater(scenario.Start);

            foreach (var instruction in scenario.Instructions.Select(x => new string(x, 1)).ToArray())
            {
                if (Enum.TryParse(instruction, out Enums.Move move))
                {
                    _crater.Next.Move();
                    _crater.Update();
                }
                else if (Enum.TryParse(instruction, out Enums.Turn turn))
                {
                    _crater.Next.Turn(turn);
                    _crater.Update();
                }
                else
                {
                    throw new ArgumentException(string.Format("Instruction '{0}' is not a valid option", instruction));
                }
            }

            return _crater;
        }
    }
}
