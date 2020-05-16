using System;

namespace CanadaGovCovidCsvReader.Model
{
	public class CovidDataByProvince
    {
		public DateTime? Date { get; set; }
		public double? Canada { get; set; }
		public double? Alberta { get; set; }
		public double? BritishColumbia { get; set; }
		public double? Manitoba { get; set; }
		public double? NewBrunswick { get; set; }
		public double? NewfoundlandAndLabrador { get; set; }
		public double? NorthwestTerritories { get; set; }
		public double? NovaScotia { get; set; }
		public double? Nunavut { get; set; }
		public double? Ontario { get; set; }
		public double? PrinceEdwardIsland { get; set; }
		public double? Quebec { get; set; }
		public double? Saskatchewan { get; set; }
		public double? Yukon { get; set; }
		public double? RepatriatedTravelers { get; set; }
	}
}
