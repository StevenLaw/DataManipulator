using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CanadaGovCovidCsvReader.Converters
{
	public class NullDoubleConverter : DefaultTypeConverter
    {
		/// <summary>
		/// Converts the string to an object.
		/// </summary>
		/// <param name="text">The string to convert to an object.</param>
		/// <param name="row">The <see cref="T:CsvHelper.IReaderRow" /> for the current record.</param>
		/// <param name="memberMapData">The <see cref="T:CsvHelper.Configuration.MemberMapData" /> for the member being created.</param>
		/// <returns>
		/// The object created from the string.
		/// </returns>
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			if (double.TryParse(text, out double tmp))
				return tmp;
			return null;
		}
	}
}
