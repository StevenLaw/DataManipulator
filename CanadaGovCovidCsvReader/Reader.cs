using CanadaGovCovidCsvReader.Maps;
using CanadaGovCovidCsvReader.Model;
using CsvHelper;
using DataManipulator.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CanadaGovCovidCsvReader
{
    public class Reader: IReader<CanadaGovCovidData>
    {
        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Reader"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public Reader(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// the data.
        /// </returns>
        public IEnumerable<CanadaGovCovidData> GetData()
        {
            using (var reader = new StreamReader(Path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<CanadaGovCovidDataMap>();
                csv.Configuration.HasHeaderRecord = true;
                return csv.GetRecords<CanadaGovCovidData>().ToArray();
            }
        }

        ///// <summary>
        ///// A container for constant property types for grouping.
        ///// </summary>
        //public struct GroupingTypes
        //{
        //    public const string Confirmed = "Confirmed";
        //    public const string Probability = "Probability";
        //    public const string Deaths = "Deaths";
        //    public const string Total = "Total";
        //    public const string Tested = "Tested";
        //    public const string Recovered = "Recovered";
        //    public const string PercentRecovered = "PercentRecovered";
        //    public const string RateTested = "RateTested";
        //    public const string Today = "Today";
        //    public const string PercentToday = "PercentToday";
        //}

        ///// <summary>
        ///// Gets the grouped data.
        ///// </summary>
        ///// <param name="property">The property to group by (Default is "Total").</param>
        ///// <returns>
        ///// the grouped data.
        ///// </returns>
        //public CovidDataByProvince[] GetGroupedData(string property = GroupingTypes.Total)
        //{
        //    var data = GetData();

        //    return data.GroupBy(d => d.Date)
        //        .Select(d => new CovidDataByProvince
        //        {
        //            Date = d.Key,
        //            Canada = d.FirstOrDefault(p => p.ProvinceId == 1)?.GetValueByPropertyName(property),
        //            Alberta = d.FirstOrDefault(p => p.ProvinceId == 48)?.GetValueByPropertyName(property),
        //            BritishColumbia = d.FirstOrDefault(p => p.ProvinceId == 59)?.GetValueByPropertyName(property),
        //            Manitoba = d.FirstOrDefault(p => p.ProvinceId == 46)?.GetValueByPropertyName(property),
        //            NewBrunswick = d.FirstOrDefault(p => p.ProvinceId == 13)?.GetValueByPropertyName(property),
        //            NewfoundlandAndLabrador = d.FirstOrDefault(p => p.ProvinceId == 10)?.GetValueByPropertyName(property),
        //            NorthwestTerritories = d.FirstOrDefault(p => p.ProvinceId == 61)?.GetValueByPropertyName(property),
        //            NovaScotia = d.FirstOrDefault(p => p.ProvinceId == 12)?.GetValueByPropertyName(property),
        //            Nunavut = d.FirstOrDefault(p => p.ProvinceId == 62)?.GetValueByPropertyName(property),
        //            Ontario = d.FirstOrDefault(p => p.ProvinceId == 35)?.GetValueByPropertyName(property),
        //            PrinceEdwardIsland = d.FirstOrDefault(p => p.ProvinceId == 11)?.GetValueByPropertyName(property),
        //            Quebec = d.FirstOrDefault(p => p.ProvinceId == 24)?.GetValueByPropertyName(property),
        //            Saskatchewan = d.FirstOrDefault(p => p.ProvinceId == 47)?.GetValueByPropertyName(property),
        //            Yukon = d.FirstOrDefault(p => p.ProvinceId == 60)?.GetValueByPropertyName(property),
        //            RepatriatedTravelers = d.FirstOrDefault(p => p.ProvinceId == 99)?.GetValueByPropertyName(property)
        //        })
        //        .ToArray();
        //}

        //public CovidDataByProvince[] GetAveraged(int groupSize = 3,string property = GroupingTypes.Total)
        //{
        //    var grouped = GetGroupedData(property);
        //    var averages = new List<CovidDataByProvince>();
        //    for (int i = 0; i <= grouped.Length - groupSize; i++)
        //    {
        //        var slice = grouped.Skip(i).Take(groupSize);
        //        averages.Add(new CovidDataByProvince
        //        {
        //            Date = slice.Last().Date,
        //            Alberta = slice.Sum(d => d.Alberta) / groupSize,
        //            BritishColumbia = slice.Sum(d => d.BritishColumbia)/groupSize,
        //            Canada = slice.Sum(d=>d.Canada)/groupSize,
        //            Manitoba = slice.Sum(d=>d.Manitoba)/groupSize,
        //            NewBrunswick = slice.Sum(d =>d.NewBrunswick) / groupSize,
        //            NewfoundlandAndLabrador = slice.Sum(d=>d.NewfoundlandAndLabrador) / groupSize,
        //            NorthwestTerritories = slice.Sum(d=>d.NorthwestTerritories) / groupSize,
        //            NovaScotia = slice.Sum(d=>d.NovaScotia) / groupSize,
        //            Nunavut = slice.Sum(d=>d.Nunavut) / groupSize,
        //            Ontario = slice.Sum(d=>d.Ontario) / groupSize,
        //            PrinceEdwardIsland = slice.Sum(d=>d.PrinceEdwardIsland) / groupSize,
        //            Quebec=slice.Sum(d=>d.Quebec) / groupSize,
        //            RepatriatedTravelers= slice.Sum(d=>d.RepatriatedTravelers) / groupSize,
        //            Saskatchewan=slice.Sum(d=>d.Saskatchewan) / groupSize,
        //            Yukon= slice.Sum(d=>d.Yukon) / groupSize
        //        });
        //    }
        //    return averages.ToArray();
        //}
    }
}
