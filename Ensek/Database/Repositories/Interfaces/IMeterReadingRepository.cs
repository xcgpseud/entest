using Domain.DataModels;

namespace Database.Repositories.Interfaces
{
    public interface IMeterReadingRepository
    {
        Task InsertMany(IEnumerable<MeterReading> meterReadings);

        Task<IEnumerable<MeterReading>> GetAll();

        Task<MeterReading?> GetByAccountIdAndReadValue(int accountId, string readValue);
    }
}
