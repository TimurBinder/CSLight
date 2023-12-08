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

        private bool _isOpen;
        private int _selectedIndex;
        private int _positionX;
        private int _positionY;

        public Menu(int positionX, int positionY)
        {
            _defaultColor = Console.ForegroundColor;
            _selectedColor = ConsoleColor.Green;
            _selectedIndex = 0;
            _positionX = positionX;
            _positionY = positionY;
            _itemsList = new List<string>();
        }
        public Menu(string[] itemsArray, int positionX, int positionY) : this(positionX, positionY)
        {
            _itemsList = new List<string>(itemsArray);
        }
        public Menu(List<string> itemsList, int positionX, int positionY) : this(positionX, positionY)
        {
            _itemsList = itemsList;
        }

        public void AddItem(string name)
        {
            _itemsList.Add(name);
        }

        public void RemoveAt(int index)
        {
            _itemsList.RemoveAt(index);
        }

        public bool TryGetItemIndex(out int index)
        {
            _isOpen = true;

            while (_isOpen)
            {
                ShowMenu();

                ConsoleKeyInfo userKey = Console.ReadKey();

                if (KeyInputHandle(userKey) == false)
                {
                    index = -1;
                    return false;
                }
            }

            index = _selectedIndex;
            return true;
        }

        private bool KeyInputHandle(ConsoleKeyInfo userKey)
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
                if (i == _selectedIndex)
                    Console.ForegroundColor = _selectedColor;

                Console.WriteLine(_itemsList[i]);

                Console.ForegroundColor = _defaultColor;
            }
        }
    }

    class Station
    {
        private Random _random;
        private Menu _menu;

        private string[] _pathPoints;
        private List<Direction> _directionsList;
        private List<Train> _trainsList;

        private int _minDirectionPassengersCount;
        private int _maxDirectionPassengersCount;

        public Station()
        {
            _random = new Random();
            _menu = new Menu(0, 0);

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

            _directionsList = new List<Direction>();

            _minDirectionPassengersCount = 300;
            _maxDirectionPassengersCount = 800;
        }

        public bool TryGetDirection(out Direction direction)
        {

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

            Direction direction = new Direction(startPoint, finishPoint, passengersCount);
            _directionsList.Add(direction);
            _menu.AddItem(direction.GetInfo());
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

        public string GetInfo()
        {
            return $"Путь {StartPoint}-{FinishPoint}: всего пассажиров {PassengersCount}";
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