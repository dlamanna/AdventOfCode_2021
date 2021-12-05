namespace _5_Hydrothermal
{
    public class Vector
    {
        public int Xfrom { get; set; }
        public int Yfrom { get; set; }
        public int Xto { get; set; }
        public int Yto { get; set; }
        public bool IsStraight { get; set; }
        public bool IsHorizontal { get; set; }
        public bool IsVertical { get; set; }
        public bool IsDiagonal { get; set; }

        public Vector() { }
        public Vector(int x1, int y1, int x2, int y2)
        {
            Xfrom = x1;
            Yfrom = y1;
            Xto = x2;
            Yto = y2;

            if(x1 == x2)
            {
                IsStraight = true;
                IsHorizontal = false;
                IsVertical = true;          // vertical line
                IsDiagonal = false;
            }
            else if(y1 == y2)
            {
                IsStraight = true;
                IsHorizontal = true;        // horizontal line
                IsVertical = false;
                IsDiagonal = false;
            }
            else
            {
                IsHorizontal = false;
                IsVertical = false;
                if(Math.Abs(x1-x2) == Math.Abs(y1-y2))
                {
                    IsStraight = true;
                    IsDiagonal = true;      // diagonal line
                }
                else
                {
                    IsStraight = false;
                    IsDiagonal = false;
                }
            }
        }
        public List<Coordinate> ExpandVectors()
        {
            var list = new List<Coordinate>();
            if (!IsStraight) return null;

            if(IsHorizontal)
            {
                list.Add(new Coordinate(Xfrom,Yfrom));                                              // Always add this node
                int addingInc = 1;
                if(Xfrom > Xto) addingInc = -1;

                for(int i = 0; i<Math.Abs(Xfrom-Xto); i++)
                {
                    list.Add(new Coordinate(Xfrom + (addingInc * (i + 1)), Yfrom));
                }               
            }
            else if(IsVertical)
            {
                list.Add(new Coordinate(Xfrom, Yfrom));                                            // Always add this node
                int addingInc = 1;
                if (Yfrom > Yto) addingInc = -1;

                for (int i = 0; i < Math.Abs(Yfrom - Yto); i++)
                {
                    list.Add(new Coordinate(Xfrom, Yfrom + (addingInc * (i + 1))));
                }
            }
            else if(IsDiagonal)
            {
                list.Add(new Coordinate(Xfrom, Yfrom));                                            // Always add this node
                int YaddingInc = 1;
                if (Yfrom > Yto) YaddingInc = -1;
                int XaddingInc = 1;
                if (Xfrom > Xto) XaddingInc = -1;

                for(int i = 0; i<Math.Abs(Xfrom - Xto); i++)
                {
                    list.Add(new Coordinate(Xfrom + (XaddingInc * (i + 1)), Yfrom + (YaddingInc * (i + 1))));
                }
            }
            return list;
        }       
    }
}