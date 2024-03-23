namespace WinFormMap
{
    public partial class Form1 : Form
    {
        private readonly APIManager apiManager = new();
        private readonly Bitmap mapImage;
        private Dictionary<int, SKUD> SKUDs;

        public Form1()
        {
            InitializeComponent();
            mapImage = new Bitmap(pictureBoxMap.Image);
        }

        private void InitializeSKUDs()
        {
            SKUDs = new Dictionary<int, SKUD>()
            {
                {0, new SKUD(0, [new(691, 150), new(798, 148), new(796, 56), new(693, 57)])},
                {1, new SKUD(1, [new(884, 142), new(951, 143), new(879, 63), new(955, 58)])},
                {2, new SKUD(2, [new(1014, 152), new(1013, 108), new(1015, 70), new(1014, 26)])},
                {3, new SKUD(3, [new(1078, 152), new(1076, 110), new(1078, 54), new(1078, 20)])},
                {4, new SKUD(4, [new(1131, 159), new(1192, 123), new(1136, 93), new(1184, 46)])},
                {5, new SKUD(5, [new(1240, 161), new(1297, 127), new(1234, 97), new(1292, 54)])},
                {6, new SKUD(6, [new(1360, 158), new(1438, 110), new(1351, 63), new(1434, 33)])},
                {7, new SKUD(7, [new(1302, 354), new(1435, 355), new(1308, 461), new(1440, 475)])},
                {8, new SKUD(8, [new(1122, 357), new(1256, 360), new(1128, 471), new(1248, 468)])},
                {9, new SKUD(9, [new(1015, 354), new(1074, 357), new(1017, 478), new(1073, 477)])},
                {10, new SKUD(10, [new(933, 350), new(969, 389), new(935, 438), new(973, 488)])},
                {11, new SKUD(11, [new(836, 354), new(885, 393), new(847, 445), new(886, 485)])},
                {12, new SKUD(12, [new(667, 358), new(778, 364), new(686, 459), new(783, 467)])},
                {13, new SKUD(13, [new(608, 359), new(608, 405), new(607, 453), new(607, 488)])},
                {14, new SKUD(14, [new(548, 352), new(542, 465), new(357, 470), new(353, 358)])},
                {15, new SKUD(15, [new(288, 353), new(143, 350), new(148, 471), new(291, 473)])},
                {16, new SKUD(16, [new(99, 352), new(28, 352), new(26, 477), new(93, 479)])},
                {17, new SKUD(17, [new(37, 23), new(32, 75), new(33, 116), new(34, 159)])},
                {18, new SKUD(18, [new(102, 149), new(102, 107), new(106, 58), new(100, 17)])},
                {19, new SKUD(19, [new(164, 26), new(223, 33), new(154, 125), new(217, 130)])},
                {20, new SKUD(20, [new(292, 146), new(289, 96), new(292, 50), new(292, 20)])},
                {21, new SKUD(21, [new(353, 155), new(481, 33), new(355, 28), new(473, 150)])},
                {22, new SKUD(22, [new(545, 155), new(543, 94), new(546, 55), new(550, 18)])}
            };
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            InitializeSKUDs();
            Graphics graphics = pictureBoxMap.CreateGraphics();
            graphics.Clear(Color.White);
            graphics.DrawImage(mapImage, 0, 0, pictureBoxMap.Width, pictureBoxMap.Height);
            _ = DrawMovements(graphics);
        }

        private async Task DrawMovements(Graphics graphics)
        {
            List<PersonMovement> persons = await apiManager.getMovements();
            RandomizeLastSecurityPointNumber(persons); //Рандомим положение персон т.к апи возвращает статичные данные

            if (persons == null)
                return;

            foreach (PersonMovement person in persons)
            {
                Point coord = GetCoordForPerson(person);

                if (coord.IsEmpty)
                    continue;

                Brush brush = person.PersonRole == "Сотрудник" ? Brushes.Blue : Brushes.Green;
                graphics.FillEllipse(brush, coord.X, coord.Y, 10, 10);
            }
        }

        private Point GetCoordForPerson(PersonMovement person)
        {
            if (!SKUDs.TryGetValue(person.LastSecurityPointNumber, out SKUD? value))
                return new Point();

            return value.GetFreePoint();
        }

        private static void RandomizeLastSecurityPointNumber(List<PersonMovement> persons)
        {
            Random random = new();

            foreach (var person in persons)
            {
                person.LastSecurityPointNumber = random.Next(0, 23);
            }
        }
    }
}
