using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DataManipulator.Readers.Tests
{
    [TestClass()]
    public class DynamicCsvReaderTests
    {
        [TestMethod()]
        public void DynamicCsvReaderTest()
        {
            var reader = new DynamicCsvReader("MOCK_DATA.csv", true);

            Assert.IsTrue(reader.GetData().Count() > 0);
        }

        [TestMethod()]
        public void GetDataTest()
        {
            // arrange
            var reader = new DynamicCsvReader("MOCK_DATA.csv", true);

            // act
            var data = reader.GetData();

            // assert
            Assert.AreEqual(1000, data.Count());
        }
    }
}