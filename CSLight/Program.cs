namespace Terminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            string[] pathPoints = new string[]
  {
                "Москва", "Санкт-Петербург", "Новосибирск", "Екатеринбург", "Казань",
                "Нижний Новгород", "Красноярск", "Челябинск", "Самара", "Уфа",
                "Ростов-на-Дону", "Краснодар", "Омск", "Воронеж", "Пермь",
                "Волгоград", "Саратов", "Тюмень", "Тольятти", "Барнаул",
                "Махачкала", "Ижевск", "Хабаровск", "Ульяновск", "Иркутск",
                "Владивосток", "Ярославль", "Севастополь", "Томск", "Ставрополь",
                "Кемерово", "Набережные Челны", "Оренбург", "Новокузнецк", "Балашиха"
  };

        }
    }

    class Terminal
    {

    }

    class Station
    {
        private List<Wagon> _wagonsList;

        public Station()
        {

        }

        public void AddWagon()
        {

        }

        public bool TryGetWagon(out Wagon wagon)
        {
            bool isOpenWagonsList = true;
            ConsoleColor selectedColor = ConsoleColor.Green;
            ConsoleColor defaultColor = Console.ForegroundColor;
            int selectedIndex = 0;

            while (isOpenWagonsList)
            {
                for (int i = 0; i < _wagonsList.Count; i++)
                {
                    if (i == selectedIndex)
                        Console.ForegroundColor = selectedColor;

                    Console.WriteLine($"Вагон на {_wagonsList[i].PlacesCount} мест");

                    Console.ForegroundColor = defaultColor;
                }

            }
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
        private Direction _direction;
        private List<Wagon> _wagonsList;

        public Train(Direction direction)
        {
            _direction = direction;
            _wagonsList = new List<Wagon>();
        }

        public int PlacesCount
        {
            get
            {
                int count = 0;

                foreach (var wagon in _wagonsList)
                    count += wagon.PlacesCount;

                return count;
            }
        }

        public void TryAddWagon(Station station)
        {
            if (station.TryGetWagon(out Wagon wagon))
            {
                _wagonsList.Add(wagon);
                return true;
            }
            else
            {
            }
        }
    }

    class Wagon
    {
        public Wagon(int placesCount)
        {
            PlacesCount = placesCount;
        }

        public int PlacesCount { get; }
    }
}