public class Sorter
{
    private List<Record> collection;
    private List<string> intermediateSteps;
    public SortStatistics Stats { get; set; }

    public Sorter()
    {
        Stats = new SortStatistics();
        InitCollection();
    }

    public void InitCollection()
    {
        collection = new List<Record>();
        intermediateSteps = new List<string>();
        Stats.Reset();
    }

    public void AddRecord(Record record)
    {
        collection.Add(record);
    }

    public void RemoveRecord(int cardNumber)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            if (collection[i].CardNumber == cardNumber)
            {
                collection.RemoveAt(i);
                Console.WriteLine("Пацієнта видалено.");
                return;
            }
        }
        Console.WriteLine("Пацієнта з такою карткою не знайдено.");
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
            Console.WriteLine(collection[i].ToString());
        }
    }

    public void GenerateControlData()
    {
        InitCollection();
        AddRecord(new Record(1, "Шевченко", "Тарас", "Шевченківський"));
        AddRecord(new Record(2, "Франко", "Іван", "Печерський"));
        AddRecord(new Record(3, "Українка", "Леся", "Подільський"));
        AddRecord(new Record(4, "Коцюбинський", "Михайло", "Шевченківський"));
        AddRecord(new Record(5, "Шевченко", "Андрій", "Дарницький")); 
        AddRecord(new Record(6, "Стус", "Василь", "Голосіївський"));
        AddRecord(new Record(7, "Симоненко", "Василь", "Печерський"));
        AddRecord(new Record(8, "Костенко", "Ліна", "Голосіївський"));
        AddRecord(new Record(9, "Грушевський", "Михайло", "Подільський"));
        AddRecord(new Record(10, "Довженко", "Олександр", "Дарницький"));
        AddRecord(new Record(11, "Хмельницький", "Богдан", "Оболонський"));
        Console.WriteLine("Контрольні дані згенеровано.");
    }

    public void SortCollection()
    {
        if (collection.Count <= 1)
        {
            return;
        }

        Stats.Reset();
        intermediateSteps.Clear();
        Record[] arr = collection.ToArray(); 

        DateTime startTime = DateTime.Now;
        MergeSortRecursive(arr, 0, arr.Length - 1);
        DateTime endTime = DateTime.Now;
        TimeSpan duration = endTime - startTime;
        Stats.ExecutionTimeMs = (long)duration.TotalMilliseconds;

        for (int i = 0; i < arr.Length; i++)
        {
            collection[i] = arr[i];
        }
        Console.WriteLine("\nСортування завершено!");
    }

    private void MergeSortRecursive(Record[] arr, int left, int right)
    {
        Stats.RecursiveCalls++;

        if (left < right)
        {
            int mid = left + (right - left) / 2;

            MergeSortRecursive(arr, left, mid);
            MergeSortRecursive(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    private void Merge(Record[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        Record[] L = new Record[n1];
        Record[] R = new Record[n2];

        for (int i = 0; i < n1; i++) 
        { 
            L[i] = arr[left + i]; 
            Stats.Copies++; 
        }
        for (int j = 0; j < n2; j++) 
        { 
            R[j] = arr[mid + 1 + j]; 
            Stats.Copies++; 
        }

        int iL = 0;
        int iR = 0;
        int k = left;

        while (iL < n1 && iR < n2)
        {
            Stats.Comparisons++;
            int cmp = string.Compare(L[iL].LastName, R[iR].LastName, StringComparison.OrdinalIgnoreCase);
            
            if (cmp == 0)
            {
                Stats.Comparisons++;
                cmp = string.Compare(L[iL].FirstName, R[iR].FirstName, StringComparison.OrdinalIgnoreCase);
            }

            if (cmp <= 0)
            {
                arr[k] = L[iL];
                iL++;
            }
            else
            {
                arr[k] = R[iR];
                iR++;
            }
            Stats.Copies++;
            k++;
        }

        while (iL < n1) 
        { 
            arr[k] = L[iL]; 
            iL++;
            k++;
            Stats.Copies++;
        }
        while (iR < n2) 
        { 
            arr[k] = R[iR];
            iR++; 
            k++; 
            Stats.Copies++; 
        }

        SaveIntermediateStep(arr, left, right);
    }

    private void SaveIntermediateStep(Record[] arr, int left, int right)
    {
        string stepInfo = $"Злиття індексів з {left} по {right}:\n";
        for (int i = left; i <= right; i++)
        {
            stepInfo += $"  {arr[i].LastName} {arr[i].FirstName}\n";
        }
        intermediateSteps.Add(stepInfo);
    }

    public void PrintIntermediateSteps()
    {
        if (intermediateSteps.Count == 0)
        {
            Console.WriteLine("Немає збережених кроків. Спершу запустіть сортування.");
            return;
        }
        
        Console.WriteLine("--- Проміжні кроки злиття (Merge Sort) ---");
        for (int i = 0; i < intermediateSteps.Count; i++)
        {
            Console.WriteLine($"Крок {i + 1}:\n{intermediateSteps[i]}");
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

    public void FindPatientsByLetter(char letter)
    {
        Console.WriteLine($"\nПацієнти на літеру '{letter}':");
        bool found = false;
        for (int i = 0; i < collection.Count; i++)
        {
            if (collection[i].LastName.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(collection[i].ToString());
                found = true;
            }
        }
        if (!found) 
        {
            Console.WriteLine("Таких пацієнтів не знайдено.");
        }
    }

    public void CountPatientsByDistrict()
    {

        Dictionary<string, int> districtCounts = new Dictionary<string, int>();

        for (int i = 0; i < collection.Count; i++)
        {
            string district = collection[i].District;
            if (districtCounts.ContainsKey(district))
            {
                districtCounts[district]++;
            }
            else
            {
                districtCounts.Add(district, 1);
            }
        }

        Console.WriteLine("\nСтатистика по районах:");
        foreach (KeyValuePair<string, int> kvp in districtCounts)
        {
            Console.WriteLine($"Район: {kvp.Key} | Кількість: {kvp.Value}");
        }
    }
}