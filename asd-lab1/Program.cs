class Program
{
    public static void Main()
    {
        Sorter sorter = new Sorter();

        while (true)
        {
            Console.WriteLine("\n---------- ГОЛОВНА ----------");
            Console.WriteLine("1. Очистити колекцію");
            Console.WriteLine("2. Згенерувати контрольні дані (11 елементів)");
            Console.WriteLine("3. Додати пасажира вручну");
            Console.WriteLine("4. Видалити пасажира за номером броні");
            Console.WriteLine("5. Вивести поточний список");
            Console.WriteLine("6. Відсортувати список за спаданням ваги (QuickSort)");
            Console.WriteLine("7. Вивести статистику сортування");
            Console.WriteLine("8. Вивести пасажирів, чий багаж вийшов за норму");
            Console.WriteLine("9. Вивести топ-5 пасажирів із найбільшим багажем");
            Console.WriteLine("10. Вивести пасажирів, чий багаж понад 20 кг");
            Console.WriteLine("0. Вихід");
            Console.Write("Оберіть дію: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                sorter.InitCollection();
                Console.WriteLine("Колекцію очищено.");
            }
            else if (choice == "2")
            {
                sorter.GenerateControlData();
            }
            else if (choice == "3")
            {
                ConsoleUsing.AddRecordMenu(sorter);
            }
            else if (choice == "4")
            {
                ConsoleUsing.RemoveRecordMenu(sorter);
            }
            else if (choice == "5")
            {
                sorter.PrintCollection();
            }
            else if (choice == "6")
            {
                sorter.SortCollection();
            }
            else if (choice == "7")
            {
                sorter.PrintStatistics();
            }
            else if (choice == "8")
            {
                sorter.ExceededNormPassengers();
            }
            else if (choice == "9")
            {
                sorter.Top5Heaviest();
            }
            else if (choice == "10")
            {
                sorter.MoreThan20kgPassengers();
            }
            else if (choice == "0")
            {
                break;
            }
            else
            {
                Console.WriteLine("Такий вибір непередбачений.");
            }
        }
    }
}