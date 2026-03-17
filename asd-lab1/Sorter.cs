public class Sorter
{
    private List<Record> collection;
    public SortStatistics Stats { get; set; }

    public Sorter()
    {
        Stats = new SortStatistics();
        InitCollection();
    }

    public void InitCollection()
    {
        collection = new List<Record>();
        Stats.Reset();
    }

    public void AddRecord(Record record)
    {
        collection.Add(record);
    }

    public void RemoveRecord(string reservationCode)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            if (collection[i].ReservationCode == reservationCode)
            {
                collection.RemoveAt(i);
                Console.WriteLine("Пасажира видалено.");
                return;
            }
        }
        Console.WriteLine("Пасажира з такою бронню не знайдено.");
    }

    public void PrintCollection()
    {
        if (collection.Count == 0)
        {
            Console.WriteLine("Колекція порожня.");
            return;
        }

        for (int i = 0; i < collection.Count; i++)
        {
            Console.WriteLine(collection[i]);
        }
    }

    public void GenerateControlData()
    {
        InitCollection();
        AddRecord(new Record("A102", "Шевченко", "Бізнес", 22.5));
        AddRecord(new Record("B103", "Франко", "Економ", 5.0));
        AddRecord(new Record("C104", "Українка", "Перший", 15.0));
        AddRecord(new Record("A105", "Коцюбинський", "Економ", 10.0));
        AddRecord(new Record("B106", "Шевченко", "Економ", 25.9));
        AddRecord(new Record("C107", "Стус", "Бізнес", 8.0));
        AddRecord(new Record("A108", "Симоненко", "Перший", 12.3));
        AddRecord(new Record("B109", "Костенко", "Перший", 18.0));
        AddRecord(new Record("C110", "Грушевський", "Економ", 15.0));
        AddRecord(new Record("A111", "Довженко", "Економ", 20.1));
        AddRecord(new Record("B112", "Хмельницький", "Бізнес", 16.7));
        Console.WriteLine("Контрольні дані згенеровано.");
    }

    public void SortCollection()
    {
        if (collection.Count <= 1) 
        {
            return;
        }
        
        Stats.Reset();

        DateTime startTime = DateTime.Now;
        QuickSortRecursive(collection, 0, collection.Count - 1);
        DateTime endTime = DateTime.Now;
        TimeSpan duration = endTime - startTime;
        Stats.ExecutionTimeMs = (long)duration.TotalMilliseconds;

        Console.WriteLine("Сортування завершено.");
    }

    private void QuickSortRecursive(List<Record> list, int low, int high)
    {
        Stats.RecursiveCalls++;
        if (low < high)
        {
            int pivotIndex = Partition(list, low, high);
            
            QuickSortRecursive(list, low, pivotIndex - 1);
            QuickSortRecursive(list, pivotIndex + 1, high);
        }
    }

    private int Partition(List<Record> list, int low, int high)
    {
        Record pivot = list[high]; 
        int i = low - 1; 

        for (int j = low; j < high; j++)
        {
            Stats.Comparisons++;
            if (ShouldComeBefore(list[j], pivot))
            {
                i++;
                Record temp1 = list[i];
                list[i] = list[j];
                list[j] = temp1;
                Stats.Copies += 3;
            }
        }
        Record temp2 = list[i + 1];
        list[i + 1] = list[high];
        list[high] = temp2;
        Stats.Copies += 3;
        
        return i + 1;
    }

    private bool ShouldComeBefore(Record a, Record b)
    {
        if (a.BaggageWeight > b.BaggageWeight)
        {
            return true;
        }
        if (a.BaggageWeight < b.BaggageWeight) 
        {
            return false;
        }
        Stats.Comparisons++;
        if (string.Compare(a.PassengerSurname.ToUpper(), b.PassengerSurname.ToUpper()) < 0) 
        {
            return true;
        }
        
        return false;
    }

    public void ExceededNormPassengers()
    {
        Console.WriteLine("Пасажири, що перевищили норму багажу для свого класу:");
        bool found = false;

        for (int i = 0; i < collection.Count; i++)
        {
            double limit = 0;
            string seatClass = collection[i].SeatClass.ToUpper();

            if (seatClass == "ECONOMY" || seatClass == "ЕКОНОМ")
            {
                limit = 20.0;
            }
            else if (seatClass == "BUSINESS" || seatClass == "БІЗНЕС")
            {
                limit = 30.0;
            }
            else
            {
                limit = 40.0;
            }

            if (collection[i].BaggageWeight > limit)
            {
                Console.WriteLine($"{collection[i]} (Норма: {limit} кг)");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Пасажирів із перевищенням норми не знайдено.");
        }
    }
    public void MoreThan20kgPassengers()
    {
        Console.WriteLine("Пасажири, що перевищили норму багажу (понад 20 кг):");
        bool found = false;
        for (int i = 0; i < collection.Count; i++)
        {
            if (collection[i].BaggageWeight > 20.0) 
            {
                Console.WriteLine(collection[i]);
                found = true;
            }
        }
        if (!found) 
        {
            Console.WriteLine("Пасажирів із перевищенням не знайдено.");
        }
    }

    public void Top5Heaviest()
    {
        Console.WriteLine("Топ-5 пасажирів із найбільшим багажем:");
        if (collection.Count == 0)
        {
            Console.WriteLine("Колекція порожня.");
            return;
        }

        List<Record> tempCopy = new List<Record>();
        for (int i = 0; i < collection.Count; i++)
        {
            tempCopy.Add(collection[i]);
        }

        int limit;
        if (tempCopy.Count < 5)
        {
            limit = tempCopy.Count;
        }
        else
        {
            limit = 5;
        }

        for (int i = 0; i < limit; i++)
        {
            int maxIndex = i;
            
            for (int j = i + 1; j < tempCopy.Count; j++)
            {
                if (tempCopy[j].BaggageWeight > tempCopy[maxIndex].BaggageWeight)
                {
                    maxIndex = j;
                }
                else if (tempCopy[j].BaggageWeight == tempCopy[maxIndex].BaggageWeight)
                {
                    if (string.Compare(tempCopy[j].PassengerSurname.ToUpper(), tempCopy[maxIndex].PassengerSurname.ToUpper()) < 0)
                    {
                        maxIndex = j;
                    }
                }
            }

            Record temp = tempCopy[i];
            tempCopy[i] = tempCopy[maxIndex];
            tempCopy[maxIndex] = temp;

            Console.WriteLine($"{i + 1}. {tempCopy[i]}");
        }
    }

    public void PrintStatistics()
    {
        Console.WriteLine("--- Статистика сортування ---");
        Console.WriteLine($"Кількість порівнянь:      {Stats.Comparisons}");
        Console.WriteLine($"Кількість копіювань:      {Stats.Copies}");
        Console.WriteLine($"Рекурсивних викликів:     {Stats.RecursiveCalls}");
        Console.WriteLine($"Час виконання:            {Stats.ExecutionTimeMs} мс");
    }
}