using Domain.DataModels;
using FluentValidation;

namespace Domain.Validators
{
    public class MeterReadingValidator : AbstractValidator<MeterReading>
    {
        public MeterReadingValidator()
        {
            // This is here to validate that the value is a 5 digit integer
            RuleFor(meterReading => meterReading.MeterReadValue).Must(BeAValidMeterReading);
        }

        private bool BeAValidMeterReading(string meterReading)
        {
            int reading = 0;

            var isNumeric = int.TryParse(meterReading, out reading);

            // Get rid of any negatives as they'd be numeric and 5 chars in length
            if (Math.Abs(reading) != reading)
            {
                return false;
            }


            return isNumeric && meterReading.Length == 5;
        }
    }
}
