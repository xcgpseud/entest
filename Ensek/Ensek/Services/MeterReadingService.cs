using Database.Repositories.Interfaces;
using Domain.DataModels;
using Domain.Validators;
using Ensek.Services.Interfaces;

namespace Ensek.Services
{
    public class MeterReadingService : IMeterReadingService
    {
        private readonly IMeterReadingRepository _meterReadingRepository;

        private readonly IAccountRepository _accountRepository;

        public MeterReadingService(
            IMeterReadingRepository meterReadingRepository,
            IAccountRepository accountRepository
        )
        {
            _meterReadingRepository = meterReadingRepository;
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<MeterReading>> GetAll()
        {
            return await _meterReadingRepository.GetAll();
        }

        public async Task InsertMany(IEnumerable<MeterReading> meterReadings)
        {
            await _meterReadingRepository.InsertMany(meterReadings);
        }

        public async Task<(IEnumerable<MeterReading>, MeterUploadResult)> getValidReadingsAndResults(IEnumerable<MeterReading> meterReadings)
        {
            var (successful, failed) = (0, 0);

            List<MeterReading> validReadings = new List<MeterReading>();

            var validator = new MeterReadingValidator();

            foreach (var meterReading in meterReadings)
            {
                var result = validator.Validate(meterReading);

                if (!result.IsValid)
                {
                    failed++;
                    continue;
                }

                var account = await _accountRepository.GetAccountById(meterReading.AccountId);

                if (account == null)
                {
                    failed++;
                    continue;
                }

                // If we are expecting potential duplicates in the csv upload then I'd need to track these here and check against already-read data.
                var existingReading = await _meterReadingRepository.GetByAccountIdAndReadValue(meterReading.AccountId, meterReading.MeterReadValue);

                if (existingReading == null)
                {
                    validReadings.Add(meterReading);
                    successful++;

                    continue;
                }

                var existingTime = DateTime.Parse(existingReading.MeterReadingDateTime);
                var incomingTime = DateTime.Parse(meterReading.MeterReadingDateTime);

                if (existingTime >= incomingTime)
                {
                    failed++;
                    continue;
                }

                validReadings.Add(meterReading);
                successful++;
            }

            return (validReadings, new MeterUploadResult
            {
                Successful = successful,
                Failed = failed,
            });
        }
    }
}
