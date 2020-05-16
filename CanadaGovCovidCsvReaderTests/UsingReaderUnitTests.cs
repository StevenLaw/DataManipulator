using CanadaGovCovidCsvReader;
using CanadaGovCovidCsvReader.Converters;
using CanadaGovCovidCsvReader.Model;
using DataManipulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CanadaGovCovidCsvReaderTests
{
    [TestClass]
    public class UsingReaderUnitTests
    {
        [TestMethod]
        public void GetData()
        {
            // assign
            var reader = new Reader("C:\\Users\\Temp\\Downloads\\covid19.csv");

            // arrange
            var results = reader.GetData();

            // assert
            Assert.IsTrue(results.Count() > 0);
        }

        [TestMethod]
        public void GetGroupedDataReader()
        {
            // assign
            var reader = new Reader("C:\\Users\\Temp\\Downloads\\covid19.csv");
            var converter = new CovidDataGroupingConverter(c => c?.Total);
            var dm = new DataManipulator<CanadaGovCovidData, CovidDataByProvince, DateTime?>(reader, converter);

            // arrange
            var rawData = reader.GetData();
            var grouped = dm.GetGroupedData();
            var numDates = rawData.Select(r => r.Date).Distinct().Count();

            // assert
            Assert.IsTrue(grouped.Count() > 0);
            Assert.AreEqual(grouped.Count(), numDates, "The number of dates in the raw data should equal the number of records in the grouped data");
        }

        [TestMethod]
        public void TestAveragedReader()
        {
            // assign
            var reader = new Reader("C:\\Users\\Temp\\Downloads\\covid19.csv");
            var converter = new CovidDataGroupingConverter(c => c?.Total);
            var dm = new DataManipulator<CanadaGovCovidData, CovidDataByProvince, DateTime?>(reader, converter);

            // arrange
            var grouped = dm.GetGroupedData();
            var averaged = dm.GetAveraged();

            // assert
            Assert.AreEqual(grouped.Count() - 2, averaged.Count(), "The grouped should have 2 more items due to the size 3 sliding window");
        }

        [TestMethod]
        public void TestAveraged10DayReader()
        {
            // assign
            var reader = new Reader("C:\\Users\\Temp\\Downloads\\covid19.csv");
            var converter = new CovidDataGroupingConverter(c => c?.Total);
            var dm = new DataManipulator<CanadaGovCovidData, CovidDataByProvince, DateTime?>(reader, converter);

            // arrange
            var grouped = dm.GetGroupedData();
            var averaged = dm.GetAveraged(10);

            // assert
            Assert.AreEqual(grouped.Count() - 9, averaged.Count(), "The grouped should have 9 more items due to the size 10 sliding window");
        }
    }
}
