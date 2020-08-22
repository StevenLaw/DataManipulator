using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleSheetsReader.Tests
{
    public class ParseableData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public int Ints { get; set; }
        public decimal Decimal { get; set; }
        public static ParseableData Build(IList<object> list)
        {
            if (list.Count != 7)
            {
                throw new ArgumentException("The list has the wrong number of items.");
            }
            var data = new ParseableData
            {
                FirstName = list[1] as string,
                LastName = list[2] as string,
            };
            if (int.TryParse(list[0] as string, out int id))
                data.Id = id;
            else data.Id = 0;
            string datetime = $"{list[3]} {list[4]}";
            if (DateTime.TryParse(datetime as string, out DateTime date))
                data.Date = date;
            else data.Date = DateTime.Now;
            if (int.TryParse(list[5] as string, out int ints))
                data.Ints = ints;
            else data.Ints = 0;
            if (decimal.TryParse(list[6] as string, out decimal dec))
                data.Decimal = dec;
            else data.Decimal = 0;
            return data;
        }
    }

    [TestClass()]
    public class ReaderTests
    {
        [TestMethod()]
        public void GetDataTest()
        {
            var reader = new Reader<ParseableData>("1LsVmwn_EHIACJd12_VRGdQzJm8SjXcNmLTDCrR3UqQk", "MOCK_DATA!A2:G", ParseableData.Build);

            var data = reader.GetData();

            var idSum = data.Sum(i => i.Id);
            var intsSum = data.Sum(i => i.Ints);
            var decimalSum = data.Sum(i => i.Decimal);

            Assert.AreEqual(1000, data.Count());
            Assert.AreEqual(500500, idSum);
            Assert.AreEqual(50164, intsSum);
            Assert.AreEqual(51072.52m, decimalSum);
        }
    }
}