using CanadaGovCovidCsvReader.Maps;
using CanadaGovCovidCsvReader.Model;
using CsvHelper;
using DataManipulator.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

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
    }
}
