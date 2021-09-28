using System.ComponentModel.DataAnnotations;

namespace Rover.Models
{
    public class Enums
    {
        public enum Cardinal
        {
            [Display(Name = "North")]
            N = 0,
            [Display(Name = "East")]
            E = 1,
            [Display(Name = "South")]
            S = 2,
            [Display(Name = "West")]
            W = 3
        }

        public enum Turn
        {
            [Display(Name = "Left")]
            L = 1,
            [Display(Name = "Right")]
            R = -1
        }

        public enum Move
        {
            [Display(Name = "Forward")]
            F
        }

        public enum Boundary
        {
            Min = 0,
            Max = 4,
        }
    }
}
