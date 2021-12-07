namespace Hydrothermal
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate()
        {

        }
        public Coordinate(int x1, int y1)
        {
            X = x1;
            Y = y1;
        }
        public override int GetHashCode()
        {
            return 31*X+17*Y;
        }
        public override bool Equals(object? obj)
        {
            return obj is Coordinate && Equals((Coordinate)obj);
        }
        public bool Equals(Coordinate c)
        {
            return X == c.X && Y == c.Y;
        }
    }
}