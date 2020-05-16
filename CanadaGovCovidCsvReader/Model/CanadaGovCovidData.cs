using System;

namespace CanadaGovCovidCsvReader.Model
{
	public class CanadaGovCovidData
    {
		public int ProvinceId { get; set; }
		public string ProvinceName { get; set; }
		public string ProvinceNameFrench { get; set; }
		public DateTime? Date { get; set; }
		public double? Confirmed { get; set; }
		public double? Probability { get; set; }
		public double? Deaths { get; set; }
		public double? Total { get; set; }
		public double? Tested { get; set; }
		public double? Recovered { get; set; }
		public double? PercentRecovered { get; set; }
		public double? RateTested { get; set; }
		public double? Today { get; set; }
		public double? PercentToday { get; set; }
		public double? GetValueByPropertyName(string propName)
		{
			var propertyInfo = GetType().GetProperty(propName);
			return propertyInfo.GetValue(this, null) as double?;
		}
	}
}
