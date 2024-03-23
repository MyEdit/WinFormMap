namespace WinFormMap
{
    internal class SKUD
    {
        public int ID { get; set; }
        public List<Tuple<bool, Point>> Points { get; set; }

        public SKUD(int ID, List<Point> Points)
        {
            this.ID = ID;
            this.Points = [];

            foreach (var point in Points)
            {
                this.Points.Add(Tuple.Create(true, point));
            }
        }

        public Point GetFreePoint()
        {
            for (int i = 0; i < Points.Count; i++)
            {
                bool isFree = Points[i].Item1;
                Point point = Points[i].Item2;

                if (isFree)
                {
                    Points[i] = new Tuple<bool, Point>(false, point);
                    return point;
                }
            }

            return new Point();
        }
    }
}
