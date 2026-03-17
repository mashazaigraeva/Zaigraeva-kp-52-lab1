public static class ConsoleUsing
{
    public static void AddRecordMenu(Sorter sorter)
    {
        try
        {
            Console.Write("Введіть код броні (наприклад, A101): ");
            string code = Console.ReadLine();
            if (code == null || code.Length == 0)
            {
                throw new Exception("Помилка: Код броні не може бути порожнім.");
            }

            Console.Write("Введіть прізвище пасажира: ");
            string surname = Console.ReadLine();
            if (surname == null || surname.Length == 0)
            {
                throw new Exception("Помилка: Прізвище не може бути порожнім.");
            }

            Console.Write("Введіть клас місця (Економ, Бізнес, Перший): ");
            string seatClass = Console.ReadLine();

            Console.Write("Введіть вагу багажу (у кг): ");
            string weightInput = Console.ReadLine().Replace('.', ',');
            double weight = double.Parse(weightInput);
            if (weight < 0)
            {
                throw new Exception("Помилка: Вага багажу не може бути від'ємною.");
            }

            sorter.AddRecord(new Record(code, surname, seatClass, weight));
            Console.WriteLine("Пасажира успішно додано.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: Вага має бути числом.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}.");
        }
    }

    public static void RemoveRecordMenu(Sorter sorter)
    {
        Console.Write("Введіть код броні для видалення: ");
        string code = Console.ReadLine();
        
        if (code != null && code.Length > 0)
        {
            sorter.RemoveRecord(code);
        }
        else
        {
            Console.WriteLine("Помилка: Код броні не введено.");
        }
    }
}