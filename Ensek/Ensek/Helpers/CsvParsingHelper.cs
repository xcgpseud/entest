using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Ensek.Helpers
{
    public class CsvParsingHelper
    {
        public static IEnumerable<T> ConvertFromStringToRecords<T>(Stream stream)
        {
            IEnumerable<T> output;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture);

            var reader = new StreamReader(stream);
            var csvReader = new CsvReader(reader, config);

            output = csvReader.GetRecords<T>().ToList();

            return output;
        }
    }
}
