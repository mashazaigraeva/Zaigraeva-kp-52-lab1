public class Record
{
    public int CardNumber { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string District { get; set; }

    public Record(int cardNumber, string lastName, string firstName, string district)
    {
        CardNumber = cardNumber;
        LastName = lastName;
        FirstName = firstName;
        District = district;
    }

    public override string ToString()
    {
        return $"Картка: {CardNumber} | Прізвище: {LastName} | Ім'я: {FirstName} | Район: {District}";
    }
}