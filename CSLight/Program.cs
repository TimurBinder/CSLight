namespace Terminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

        }
    }

    class Terminal
    {
        private Station _station;

        public Terminal() 
        { 
            _station = new Station();
        }

        public void Work()
        {
            bool isWork = true;

        }
    }

    class Station
    {
        private Random _random;
        private string[] _pathPoints;
        private List<Direction> _directionsList;
        private List<Train> _trainsList;

        private int _minDirectionPassengersCount;
        private int _maxDirectionPassengersCount;

        public Station()
        {
            _random = new Random();
            _pathPoints = new string[]
            {
                "Москва", "Санкт-Петербург", "Новосибирск", "Екатеринбург", "Казань",
                "Нижний Новгород", "Красноярск", "Челябинск", "Самара", "Уфа",
                "Ростов-на-Дону", "Краснодар", "Омск", "Воронеж", "Пермь",
                "Волгоград", "Саратов", "Тюмень", "Тольятти", "Барнаул",
                "Махачкала", "Ижевск", "Хабаровск", "Ульяновск", "Иркутск",
                "Владивосток", "Ярославль", "Севастополь", "Томск", "Ставрополь",
                "Кемерово", "Набережные Челны", "Оренбург", "Новокузнецк", "Балашиха"
            };

            _minDirectionPassengersCount = 300;
            _maxDirectionPassengersCount = 800;
        }

        public void AddRandomDirection()
        {
            int passengersCount = _random.Next(_minDirectionPassengersCount, _maxDirectionPassengersCount);
            int startPointIndex = _random.Next(0, _pathPoints.Length);
            int finishPointIndex = _random.Next(0, _pathPoints.Length);

            if (finishPointIndex == startPointIndex)
            {
                if (finishPointIndex < _pathPoints.Length - 1)
                    finishPointIndex++;
                else 
                    finishPointIndex--;
            }

            string startPoint = _pathPoints[startPointIndex];
            string finishPoint = _pathPoints[finishPointIndex];

            _directionsList.Add(new Direction(startPoint, finishPoint, passengersCount));
        }

        public void AddTrain()
        {
            
        }
    }

    class Direction
    {
        public Direction(string startPoint, string finishPoint, int passengersCount)
        {
            StartPoint = startPoint;
            FinishPoint = finishPoint;
            PassengersCount = passengersCount;
        }

        public string StartPoint { get; }
        public string FinishPoint { get; }
        public int PassengersCount { get; }
    }

    class Train
    {

    }

    abstract class Wagon
    {
        public Wagon(int number, int placesCount) 
        {
            Number = number;
            PlacesCount = placesCount;
        }

        public int PlacesCount { get; }
        public int Number { get; }


    }
}