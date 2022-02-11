using Domain.DataModels;

namespace Ensek.Services.Interfaces
{
    public interface IMeterReadingService
    {
        Task InsertMany(IEnumerable<MeterReading> meterReadings);

        Task<IEnumerable<MeterReading>> GetAll();

        Task<(IEnumerable<MeterReading>, MeterUploadResult)> getValidReadingsAndResults(IEnumerable<MeterReading> meterReadings);
    }
}
