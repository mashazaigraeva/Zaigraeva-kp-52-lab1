public static class ConsoleUsing
{
    public static void AddRecordMenu(Sorter sorter)
    {
        try
        {
            Console.Write("Введіть номер картки: ");
            int card = int.Parse(Console.ReadLine());
            
            Console.Write("Введіть прізвище: ");
            string lastName = Console.ReadLine();

            Console.Write("Введіть ім'я: ");
            string firstName = Console.ReadLine();

            Console.Write("Введіть район: ");
            string district = Console.ReadLine();

            sorter.AddRecord(new Record(card, lastName, firstName, district));
            Console.WriteLine("Запис успішно додано.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: Номер картки має бути числом.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}.");
        }
    }

    public static void RemoveRecordMenu(Sorter sorter)
    {
        try
        {
            Console.Write("Введіть номер картки для видалення: ");
            int card = int.Parse(Console.ReadLine());
            sorter.RemoveRecord(card);
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: Некоректний формат числа.");
        }
    }

    public static void SearchByLetterMenu(Sorter sorter)
    {
        Console.Write("Введіть першу літеру прізвища: ");
        string input = Console.ReadLine();
        
        if (!string.IsNullOrEmpty(input))
        {
            sorter.FindPatientsByLetter(input[0]);
        }
        else
        {
            Console.WriteLine("Помилка: Літера не введена.");
        }
    }
}