using CanadaGovCovidCsvReader.Converters;
using CanadaGovCovidCsvReader.Model;
using CsvHelper.Configuration;

namespace CanadaGovCovidCsvReader.Maps
{
	public class CanadaGovCovidDataMap : ClassMap<CanadaGovCovidData>
	{
		public CanadaGovCovidDataMap()
		{
			Map(m => m.ProvinceId).Name("pruid");
			Map(m => m.ProvinceName).Name("prname");
			Map(m => m.ProvinceNameFrench).Name("prnameFR");
			Map(m => m.Date).Name("date").TypeConverter<DMYDateTimeConverter>();
			Map(m => m.Confirmed).Name("numconf").TypeConverter<NullDoubleConverter>();
			Map(m => m.Probability).Name("numprob").TypeConverter<NullDoubleConverter>();
			Map(m => m.Deaths).Name("numdeaths").TypeConverter<NullDoubleConverter>();
			Map(m => m.Total).Name("numtotal").TypeConverter<NullDoubleConverter>();
			Map(m => m.Tested).Name("numtested").TypeConverter<NullDoubleConverter>();
			Map(m => m.Recovered).Name("numrecover").TypeConverter<NullDoubleConverter>();
			Map(m => m.PercentRecovered).Name("percentrecover").TypeConverter<NullDoubleConverter>();
			Map(m => m.RateTested).Name("ratetested").TypeConverter<NullDoubleConverter>();
			Map(m => m.Today).Name("numtoday").TypeConverter<NullDoubleConverter>();
			Map(m => m.PercentToday).Name("percentoday").TypeConverter<NullDoubleConverter>();
		}
	}
}
