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

    class Menu
    {
        private ConsoleColor _defaultColor;
        private ConsoleColor _selectedColor;
        private List<string> _itemsList;
        private int _selectedIndex;
        private bool _isOpen;

        public Menu(ConsoleColor defaultColor, ConsoleColor selectedColor, string[] itemsArray)
        {
            _defaultColor = defaultColor;
            _selectedColor = selectedColor;
            _itemsList = new List<string>(itemsArray);
            _selectedIndex = 0;
        }

        public void AddItem(string name)
        {
            _itemsList.Add(name);
        }

        public void RemoveAt(int index)
        {
            _itemsList.RemoveAt(index);
        }

        public int TryGetItemIndex(out int index)
        {
            _isOpen = true;

            while (_isOpen)
            {
                ShowMenu();

                ConsoleKeyInfo userKey = Console.ReadKey();

                if (KeyInputHandle(userKey) == false)
                    return false;
            }

            index = _selectedIndex;
            return true;
        }

        private void KeyInputHandle(ConsoleKeyInfo userKey)
        {
            switch (userKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if (_selectedIndex > 0)
                        _selectedIndex--;
                    else
                        _selectedIndex = _itemsList.Count - 1;

                    break;

                case ConsoleKey.DownArrow:
                    if (_selectedIndex < _itemsList.Count - 1)
                        _selectedIndex++;
                    else
                        _selectedIndex = 0;

                    break;

                case ConsoleKey.Enter:
                    _isOpen = false;
                    break;

                case ConsoleKey.Escape:
                    _isOpen = false;
                    _selectedIndex = -1;
                    return false;

            }

            return true;
        }

        private void ShowMenu()
        {
            for (var i = 0; i < _itemsList.Count; i++)
            {
                if (i == selectedIndex)
                    Console.ForegroundColor = selectedColor;

                _itemsList[i].ShowInfo();

                Console.ForegroundColor = defaultColor;
            }
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

        public Direction TryGetDirection(out Direction direction)
        {
            bool isOpenMenu = true;
            ConsoleColor defaultColor = Console.ForegroundColor;
            ConsoleColor selectedColor = ConsoleColor.Green;
            int selectedIndex = 0;

            while (isOpenMenu)
            {
                for (var i = 0; i < _directionsList.Count; i++)
                {
                    if (i == selectedIndex)
                        Console.ForegroundColor = selectedColor;

                    _directionsList[i].ShowInfo();

                    Console.ForegroundColor = defaultColor;
                }

                ConsoleKeyInfo userKey = Console.ReadKey();

                switch (userKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedIndex > 0)
                            selectedIndex--;
                        else 
                            selectedIndex = _directionsList.Count - 1;

                        break;

                    case ConsoleKey.DownArrow:
                        if (selectedIndex < _directionsList.Count - 1)
                            selectedIndex++;
                        else
                            selectedIndex = 0;

                        break;

                    case ConsoleKey.Enter:
                        isOpenMenu = false;
                        break;

                    case ConsoleKey.Escape:
                        direction = null;
                        return false;
                        
                }
            }

            direction = _directionsList[selectedIndex];
            _directionsList.RemoveAt(selectedIndex);
            return true;
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

        public void ShowInfo()
        {
            Console.WriteLine($"Путь {StartPoint}-{FinishPoint}: всего пассажиров {PassengersCount});
        }
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