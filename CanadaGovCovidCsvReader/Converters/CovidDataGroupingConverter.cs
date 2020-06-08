using CanadaGovCovidCsvReader.Model;
using DataManipulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CanadaGovCovidCsvReader.Converters
{
    public class CovidDataGroupingConverter : IConverter<CanadaGovCovidData, CovidDataByProvince, DateTime?>
    {
        public Func<CanadaGovCovidData, DateTime?> KeySelector => item => item.Date;
        public Func<CanadaGovCovidData, double?> Fetch { get; set; }

        public CovidDataGroupingConverter(Func<CanadaGovCovidData, double?> fetch)
        {
            Fetch = fetch;
        }

        public CovidDataByProvince AverageProperties(IEnumerable<CovidDataByProvince> item, int groupSize)
        {
            return new CovidDataByProvince
            {
                Date = item.Last().Date,
                Canada = item.Sum(c => c.Canada) / groupSize,
                Alberta = item.Sum(c => c.Alberta) / groupSize,
                BritishColumbia = item.Sum(c => c.BritishColumbia) / groupSize,
                Manitoba = item.Sum(c => c.Manitoba) / groupSize,
                NewBrunswick = item.Sum(c => c.NewBrunswick) / groupSize,
                NewfoundlandAndLabrador = item.Sum(c => c.NewfoundlandAndLabrador) / groupSize,
                NorthwestTerritories = item.Sum(c => c.NorthwestTerritories) / groupSize,
                NovaScotia = item.Sum(c => c.NovaScotia) / groupSize,
                Nunavut = item.Sum(c => c.Nunavut) / groupSize,
                Ontario = item.Sum(c => c.Ontario) / groupSize,
                PrinceEdwardIsland = item.Sum(c => c.PrinceEdwardIsland) / groupSize,
                Quebec = item.Sum(c => c.Quebec) / groupSize,
                Saskatchewan = item.Sum(c => c.Saskatchewan) / groupSize,
                Yukon = item.Sum(c => c.Yukon) / groupSize,
                RepatriatedTravelers = item.Sum(c => c.RepatriatedTravelers) / groupSize
            };
        }

        public CovidDataByProvince Convert(IEnumerable<CanadaGovCovidData> item)
        {
            return new CovidDataByProvince
            {
                Date = item.Last().Date,
                Canada = Fetch(item.FirstOrDefault(p => p.ProvinceId == 1)),
                Alberta = Fetch(item.FirstOrDefault(p => p.ProvinceId == 48)),
                BritishColumbia = Fetch(item.FirstOrDefault(p => p.ProvinceId == 59)),
                Manitoba = Fetch(item.FirstOrDefault(p => p.ProvinceId == 46)),
                NewBrunswick = Fetch(item.FirstOrDefault(p => p.ProvinceId == 13)),
                NewfoundlandAndLabrador = Fetch(item.FirstOrDefault(p => p.ProvinceId == 10)),
                NorthwestTerritories = Fetch(item.FirstOrDefault(p => p.ProvinceId == 61)),
                NovaScotia = Fetch(item.FirstOrDefault(p => p.ProvinceId == 12)),
                Nunavut = Fetch(item.FirstOrDefault(p => p.ProvinceId == 62)),
                Ontario = Fetch(item.FirstOrDefault(p => p.ProvinceId == 35)),
                PrinceEdwardIsland = Fetch(item.FirstOrDefault(p => p.ProvinceId == 11)),
                Quebec = Fetch(item.FirstOrDefault(p => p.ProvinceId == 24)),
                Saskatchewan = Fetch(item.FirstOrDefault(p => p.ProvinceId == 47)),
                Yukon = Fetch(item.FirstOrDefault(p => p.ProvinceId == 60)),
                RepatriatedTravelers = Fetch(item.FirstOrDefault(p => p.ProvinceId == 99))
            };
        }
    }
}
