public class Record
{
    public string ReservationCode { get; set; }
    public string PassengerSurname { get; set; }
    public string SeatClass { get; set; }
    public double BaggageWeight { get; set; }

    public Record(string reservationCode, string passengerSurname, string seatClass, double baggageWeight)
    {
        ReservationCode = reservationCode;
        PassengerSurname = passengerSurname;
        SeatClass = seatClass;
        BaggageWeight = baggageWeight;
    }

    public override string ToString()
    {
        return $"Бронь: {ReservationCode} | Прізвище: {PassengerSurname} | Клас: {SeatClass} | Вага багажу: {BaggageWeight} кг";
    }
}