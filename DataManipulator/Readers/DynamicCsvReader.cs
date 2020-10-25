using CsvHelper;
using DataManipulator.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace DataManipulator.Readers
{
    public class DynamicCsvReader : IReader<Dictionary<string, string>>
    {
        /// <summary>
        /// Gets or sets a value indicating whether the csv file has a header.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has header; otherwise, <c>false</c>.
        /// </value>
        public bool HasHeader { get; set; }
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicCsvReader"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="hasHeader">if set to <c>true</c> the csv file has a header.</param>
        public DynamicCsvReader(string path, bool hasHeader)
        {
            Path = path;
            HasHeader = hasHeader;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// the data.
        /// </returns>
        public IEnumerable<Dictionary<string, string>> GetData()
        {
            using (var reader = new StreamReader(Path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = HasHeader;
                return csv.GetRecords<dynamic>()
                    .Select(record => 
                    {
                        var dict = (IDictionary<string, object>)record;
                        return dict.ToDictionary(item => item.Key, item => item.Value.ToString());
                    })
                    .ToArray();
            }
        }
    }
}
