using System;
using System.Linq;
using DataManipulator;
using DataManipulatorTests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataManipulatorTests
{
    [TestClass]
    public class UsingStaticDataUnitTests
    {

        [TestMethod]
        public void TestingGroupedNum1StaticData()
        {
            // assign
            var reader = new TestDataReader();
            var converter = new TestDataConverter(v => v.Num1);
            var dm = new DataManipulator<InitialValues, FinalValues, DateTime>(reader.GetData(), converter);

            // arrange
            var rawData = reader.GetData();
            var grouped = dm.GetGroupedData();
            var total = rawData.Sum(i => i.Num1);
            var commonLawTotal = rawData.Where(i => i.Status == "Common-Law").Sum(i => i.Num1);
            var divorcedTotal = rawData.Where(i => i.Status == "Divorced").Sum(i => i.Num1);
            var marriedTotal = rawData.Where(i => i.Status == "Married").Sum(i => i.Num1);
            var singleTotal = rawData.Where(i => i.Status == "Single").Sum(i => i.Num1);
            var commonLawGroupTotal = grouped.Sum(i => i.CommonLaw);
            var divorcedGroupTotal = grouped.Sum(i => i.Divorced);
            var marriedGroupTotal = grouped.Sum(i => i.Married);
            var singleGroupTotal = grouped.Sum(i => i.Single);
            var groupedTotal = commonLawGroupTotal + divorcedGroupTotal + marriedGroupTotal + singleGroupTotal;

            // assert
            Assert.IsNull(dm.Reader, "The reader is null if using static data");
            Assert.AreEqual(grouped.Count(), 7, "There should be seven days in the test data");
            Assert.AreEqual(commonLawGroupTotal, commonLawTotal, "The Common-Law totals should be the same");
            Assert.AreEqual(divorcedGroupTotal, divorcedTotal, "The Divorced totals should be the same");
            Assert.AreEqual(marriedGroupTotal, marriedTotal, "The Married totals should be the same");
            Assert.AreEqual(singleGroupTotal, singleGroupTotal, "The Single totals should be the same");
            Assert.AreEqual(groupedTotal, total, "The totals should be the same");
        }

        [TestMethod]
        public void TestingGroupedNum2StaticData()
        {
            // assign
            var reader = new TestDataReader();
            var converter = new TestDataConverter(v => v.Num2);
            var dm = new DataManipulator<InitialValues, FinalValues, DateTime>(reader.GetData(), converter);

            // arrange
            var rawData = reader.GetData();
            var grouped = dm.GetGroupedData();
            var total = rawData.Sum(i => i.Num2);
            var commonLawTotal = rawData.Where(i => i.Status == "Common-Law").Sum(i => i.Num2);
            var divorcedTotal = rawData.Where(i => i.Status == "Divorced").Sum(i => i.Num2);
            var marriedTotal = rawData.Where(i => i.Status == "Married").Sum(i => i.Num2);
            var singleTotal = rawData.Where(i => i.Status == "Single").Sum(i => i.Num2);
            var commonLawGroupTotal = grouped.Sum(i => i.CommonLaw);
            var divorcedGroupTotal = grouped.Sum(i => i.Divorced);
            var marriedGroupTotal = grouped.Sum(i => i.Married);
            var singleGroupTotal = grouped.Sum(i => i.Single);
            var groupedTotal = commonLawGroupTotal + divorcedGroupTotal + marriedGroupTotal + singleGroupTotal;

            // assert
            Assert.IsNull(dm.Reader, "The reader is null if using static data");
            Assert.AreEqual(grouped.Count(), 7, "There should be seven days in the test data");
            Assert.AreEqual(commonLawGroupTotal, commonLawTotal, "The Common-Law totals should be the same");
            Assert.AreEqual(divorcedGroupTotal, divorcedTotal, "The Divorced totals should be the same");
            Assert.AreEqual(marriedGroupTotal, marriedTotal, "The Married totals should be the same");
            Assert.AreEqual(singleGroupTotal, singleGroupTotal, "The Single totals should be the same");
            Assert.AreEqual(groupedTotal, total, "The totals should be the same");
        }

        [TestMethod]
        public void TestingGroupedNum3StaticData()
        {
            // assign
            var reader = new TestDataReader();
            var converter = new TestDataConverter(v => v.Num3);
            var dm = new DataManipulator<InitialValues, FinalValues, DateTime>(reader.GetData(), converter);

            // arrange
            var rawData = reader.GetData();
            var grouped = dm.GetGroupedData();
            var total = rawData.Sum(i => i.Num3);
            var commonLawTotal = rawData.Where(i => i.Status == "Common-Law").Sum(i => i.Num3);
            var divorcedTotal = rawData.Where(i => i.Status == "Divorced").Sum(i => i.Num3);
            var marriedTotal = rawData.Where(i => i.Status == "Married").Sum(i => i.Num3);
            var singleTotal = rawData.Where(i => i.Status == "Single").Sum(i => i.Num3);
            var commonLawGroupTotal = grouped.Sum(i => i.CommonLaw);
            var divorcedGroupTotal = grouped.Sum(i => i.Divorced);
            var marriedGroupTotal = grouped.Sum(i => i.Married);
            var singleGroupTotal = grouped.Sum(i => i.Single);
            var groupedTotal = commonLawGroupTotal + divorcedGroupTotal + marriedGroupTotal + singleGroupTotal;

            // assert
            Assert.IsNull(dm.Reader, "The reader is null if using static data");
            Assert.AreEqual(grouped.Count(), 7, "There should be seven days in the test data");
            Assert.AreEqual(commonLawGroupTotal, commonLawTotal, "The Common-Law totals should be the same");
            Assert.AreEqual(divorcedGroupTotal, divorcedTotal, "The Divorced totals should be the same");
            Assert.AreEqual(marriedGroupTotal, marriedTotal, "The Married totals should be the same");
            Assert.AreEqual(singleGroupTotal, singleGroupTotal, "The Single totals should be the same");
            Assert.AreEqual(groupedTotal, total, "The totals should be the same");
        }

        [TestMethod]
        public void TestAverageNum1StaticData()
        {
            // assign
            var reader = new TestDataReader();
            var converter = new TestDataConverter(v => v.Num1);
            var dm = new DataManipulator<InitialValues, FinalValues, DateTime>(reader.GetData(), converter);

            // arrange
            var rawData = reader.GetData();
            // average by seven to get a single group and more easily compare averages.
            var averages = dm.GetAveraged(7);
            var clAverage = rawData.Where(i => i.Status == "Common-Law").Sum(i => i.Num1) / 7m;
            var dAverage = rawData.Where(i => i.Status == "Divorced").Sum(i => i.Num1) / 7m;
            var mAverage = rawData.Where(i => i.Status == "Married").Sum(i => i.Num1) / 7m;
            var sAverage = rawData.Where(i => i.Status == "Single").Sum(i => i.Num1) / 7m;

            // assert
            Assert.IsNull(dm.Reader, "The reader is null if using static data");
            Assert.AreEqual(averages.Count(), 1, "As there are 7 days in the source and the group size there should be one result");
            Assert.AreEqual(averages.First().CommonLaw, clAverage);
            Assert.AreEqual(averages.First().Divorced, dAverage);
            Assert.AreEqual(averages.First().Married, mAverage);
            Assert.AreEqual(averages.First().Single, sAverage);
        }

        [TestMethod]
        public void TestAverageNum2StaticData()
        {
            // assign
            var reader = new TestDataReader();
            var converter = new TestDataConverter(v => v.Num2);
            var dm = new DataManipulator<InitialValues, FinalValues, DateTime>(reader.GetData(), converter);

            // arrange
            var rawData = reader.GetData();
            // average by seven to get a single group and more easily compare averages.
            var averages = dm.GetAveraged(7);
            var clAverage = rawData.Where(i => i.Status == "Common-Law").Sum(i => i.Num2) / 7m;
            var dAverage = rawData.Where(i => i.Status == "Divorced").Sum(i => i.Num2) / 7m;
            var mAverage = rawData.Where(i => i.Status == "Married").Sum(i => i.Num2) / 7m;
            var sAverage = rawData.Where(i => i.Status == "Single").Sum(i => i.Num2) / 7m;

            // assert
            Assert.IsNull(dm.Reader, "The reader is null if using static data");
            Assert.AreEqual(averages.Count(), 1, "As there are 7 days in the source and the group size there should be one result");
            Assert.AreEqual(averages.First().CommonLaw, clAverage);
            Assert.AreEqual(averages.First().Divorced, dAverage);
            Assert.AreEqual(averages.First().Married, mAverage);
            Assert.AreEqual(averages.First().Single, sAverage);
        }

        [TestMethod]
        public void TestAverageNum3StaticData()
        {
            // assign
            var reader = new TestDataReader();
            var converter = new TestDataConverter(v => v.Num3);
            var dm = new DataManipulator<InitialValues, FinalValues, DateTime>(reader.GetData(), converter);

            // arrange
            var rawData = reader.GetData();
            // average by seven to get a single group and more easily compare averages.
            var averages = dm.GetAveraged(7);
            var clAverage = rawData.Where(i => i.Status == "Common-Law").Sum(i => i.Num3) / 7m;
            var dAverage = rawData.Where(i => i.Status == "Divorced").Sum(i => i.Num3) / 7m;
            var mAverage = rawData.Where(i => i.Status == "Married").Sum(i => i.Num3) / 7m;
            var sAverage = rawData.Where(i => i.Status == "Single").Sum(i => i.Num3) / 7m;

            // assert
            Assert.IsNull(dm.Reader, "The reader is null if using static data");
            Assert.AreEqual(averages.Count(), 1, "As there are 7 days in the source and the group size there should be one result");
            Assert.AreEqual(averages.First().CommonLaw, clAverage);
            Assert.AreEqual(averages.First().Divorced, dAverage);
            Assert.AreEqual(averages.First().Married, mAverage);
            Assert.AreEqual(averages.First().Single, sAverage);
        }

        [TestMethod]
        public void TestAverageGroupSizeStaticData()
        {
            // assign
            var reader = new TestDataReader();
            var converter = new TestDataConverter(v => v.Num3);
            var dm = new DataManipulator<InitialValues, FinalValues, DateTime>(reader.GetData(), converter);

            // arrange
            var averages = dm.GetAveraged();

            // assert 
            Assert.IsNull(dm.Reader, "The reader is null if using static data");
            Assert.AreEqual(averages.Count(), 5, "Because of the sliding window the size should be the original total(7) - (groupsize - 1)");
        }
    }
}
