namespace Rover.Models
{
    public class Crater
    {
        public Crater(Placement start)
        {
            Current = new Placement(start);
            Next = new Placement(start);
        }

        public int Scuffs { get; set; }

        public Placement Current { get; set; }

        public Placement Next { get; set; }

        public void Update()
        {
            if (Next.InCrater())
            {
                Current = new Placement(Next);
            }
            else
            {
                Next = new Placement(Current);
                Scuffs++;
            }
        }
    }
}
