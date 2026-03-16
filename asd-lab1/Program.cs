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
            Console.WriteLine("3. Додати пацієнта вручну");
            Console.WriteLine("4. Видалити пацієнта за номером картки");
            Console.WriteLine("5. Вивести поточний список");
            Console.WriteLine("6. Відсортувати список за прізвищем (Merge Sort)");
            Console.WriteLine("7. Вивести проміжні кроки сортування");
            Console.WriteLine("8. Вивести статистику сортування");
            Console.WriteLine("9. Знайти пацієнтів за першою літерою прізвища");
            Console.WriteLine("10. Статистика пацієнтів по районах");
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
                Console.WriteLine("Пацієнта додано.");
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
                sorter.PrintIntermediateSteps();
            }
            else if (choice == "8")
            {
                sorter.PrintStatistics();
            }
            else if (choice == "9")
            {
                ConsoleUsing.SearchByLetterMenu(sorter);
            }
            else if (choice == "10")
            {
                sorter.CountPatientsByDistrict();
            }
            else if (choice == "0")
            {
                break;
            }
            else
            {
                Console.WriteLine("Такий вибір недоступний.");
            }
        }
    }
}