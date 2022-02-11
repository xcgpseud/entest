using Domain.DataModels;
using Domain.Validators;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests.Domain.Validators
{
    [TestFixture]
    public class MeterReadingValidatorTests
    {
        private const int VALID_ACCOUNT_ID = 1;
        private const string VALID_DATE_TIME_STRING = "01/01/2010 09:00";

        private List<string> _invalidMeterReadings = new List<string>
        {
                "A1",
                "A1234",
                "1234A",
                "1234",
                "123456",
                "-1234",
        };

        private List<string> _validMeterReadings = new List<string>
        {
                "12345",
                "00000",
                "11111",
        };

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void InvalidValues_IsValidIsFalse()
        {
            var validator = new MeterReadingValidator();

            _invalidMeterReadings.ForEach(invalidReading =>
            {
                var reading = new MeterReading
                {
                    AccountId = VALID_ACCOUNT_ID,
                    MeterReadingDateTime = VALID_DATE_TIME_STRING,
                    MeterReadValue = invalidReading,
                };

                var result = validator.Validate(reading);

                Assert.IsFalse(result.IsValid);
            });
        }

        [Test]
        public void ValidValues_IsValidIsTrue()
        {
            var validator = new MeterReadingValidator();

            _validMeterReadings.ForEach(validReading =>
            {
                var reading = new MeterReading
                {
                    AccountId = VALID_ACCOUNT_ID,
                    MeterReadingDateTime = VALID_DATE_TIME_STRING,
                    MeterReadValue = validReading,
                };

                var result = validator.Validate(reading);

                Assert.IsTrue(result.IsValid);
            });
        }
    }
}
