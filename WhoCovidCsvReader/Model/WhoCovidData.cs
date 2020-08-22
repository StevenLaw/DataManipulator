using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoCovidCsvReader.Model
{
    public class WhoCovidData
    {
        public DateTime DateReported { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public string WhoRegion { get; set; }
        public int NewCases { get; set; }
        public int CumulativeCases { get; set; }
        public int NewDeaths { get; set; }
        public int CumulativeDeaths { get; set; }
    }
}
