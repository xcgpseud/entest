namespace Domain.DataModels
{
    public class MeterReading
    {
        public int AccountId { get; set; }
        public string MeterReadingDateTime { get; set; }
        public string MeterReadValue { get; set; }
    }
}
