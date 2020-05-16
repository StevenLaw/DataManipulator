using DataManipulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace DataManipulatorTests.TestData
{
    public class TestDataReader : IReader<InitialValues>
    {
        public string Path { get; private set; } = @"TestData\data.csv";

        public TestDataReader() {}

        public TestDataReader(string path)
        {
            Path = path;
        }

        public IEnumerable<InitialValues> GetData()
        {
            using (var reader = new StreamReader(Path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<InitialValuesMap>();
                csv.Configuration.HasHeaderRecord = true;
                return csv.GetRecords<InitialValues>().ToArray();
            }
        }
    }
}
