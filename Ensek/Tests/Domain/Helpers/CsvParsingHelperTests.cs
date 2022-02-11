using Domain.DataModels;
using Domain.Helpers;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace Tests.Domain.Helpers
{
    [TestFixture]
    public class CsvParsingHelperTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void ConvertFromStringToRecords_CorrectOutput()
        {
            var validCSV = @"AccountId,MeterReadingDateTime,MeterReadValue
2344,22/04/2019 09:24,10021
2233,22/04/2019 12:25,32321
8766,22/04/2019 12:25,34401
2344,22/04/2019 12:25,10021
";

            var validAccountIds = new int[] { 2344, 2233, 8766, 2344 };
            var validMeterReadValues = new string[] { "10021", "32321", "34401", "10021" };

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(validCSV);
            writer.Flush();

            stream.Position = 0;

            var results = CsvParsingHelper.ConvertFromStreamToRecords<MeterReading>(stream).ToList();

            Assert.AreEqual(4, results.Count);

            var resultsAccountIds = results.Select(x => x.AccountId).ToArray();
            var resultsMeterReadValues = results.Select(x => x.MeterReadValue).ToArray();

            Assert.AreEqual(validAccountIds, resultsAccountIds);
            Assert.AreEqual(validMeterReadValues, resultsMeterReadValues);
        }
    }
}
