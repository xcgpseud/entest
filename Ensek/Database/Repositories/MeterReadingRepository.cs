using Database.Contexts;
using Database.Repositories.Interfaces;
using Domain.DataModels;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class MeterReadingRepository : IMeterReadingRepository
    {
        private readonly BaseContext _context;

        public MeterReadingRepository(SqliteContext context) => _context = context;

        public async Task<IEnumerable<MeterReading>> GetAll()
        {
            var entities = await _context.MeterReadings.ToListAsync();

            return entities.Select(entity => entity.Adapt<MeterReading>());
        }

        public async Task<MeterReading?> GetByAccountIdAndReadValue(int accountId, string readValue)
        {
            var entity = await _context.MeterReadings.SingleOrDefaultAsync(
                meterReadingEntity =>
                    meterReadingEntity.AccountId == accountId &&
                    meterReadingEntity.MeterReadValue == readValue
            );

            return entity?.Adapt<MeterReading>();
        }

        public async Task InsertMany(IEnumerable<MeterReading> meterReadings)
        {
            // Would definitely expand this out into a bit of a smarter system if we expected large datasets but for this case I've kept it nice and basic
            foreach (var meterReading in meterReadings)
            {
                var entity = meterReading.Adapt<MeterReadingEntity>();
                await _context.MeterReadings.AddAsync(entity);
            }

            await _context.SaveChangesAsync();
        }
    }
}
