using Domain.DataModels;
using Domain.Helpers;
using Ensek.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ensek.Controllers
{
    [ApiController]
    [Route("meter-reading-uploads")]
    public class MeterController : Controller
    {
        private readonly IMeterReadingService _meterReadingService;

        public MeterController(IMeterReadingService meterRidingService) => _meterReadingService = meterRidingService;

        [HttpPost(Name = "PostMeterReadings")]
        public async Task<MeterUploadResult?> Post(IFormFile file)
        {
            var meterReadings = CsvParsingHelper.ConvertFromStreamToRecords<MeterReading>(file.OpenReadStream());

            var (validReadings, results) = await _meterReadingService.getValidReadingsAndResults(meterReadings);

            await _meterReadingService.InsertMany(validReadings);

            return results;
        }
    }
}
