using DataManipulator.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataManipulator
{
    /// <summary>
    /// Reorganizes a datasource based on a converter interface.
    /// </summary>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    /// <typeparam name="TKey">The type of the key to group by.</typeparam>
    public class DataManipulator<TInput,TOutput,TKey>
    {
        /// <summary>
        /// Gets the reader.
        /// </summary>
        /// <value>
        /// The reader.
        /// </value>
        public IReader<TInput> Reader { get; private set; }
        public IEnumerable<TInput> Data { get; private set; }
        /// <summary>
        /// Gets the converter.
        /// </summary>
        /// <value>
        /// The converter.
        /// </value>
        public IConverter<TInput, TOutput, TKey> Converter { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataManipulator{TInput, TOutput, TKey}"/> class using a reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="converter">The converter.</param>
        public DataManipulator(IReader<TInput> reader, IConverter<TInput,TOutput,TKey> converter)
        {
            Data = null;
            Reader = reader;
            Converter = converter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataManipulator{TInput, TOutput, TKey}"/> class using static data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="converter">The converter.</param>
        public DataManipulator(IEnumerable<TInput> data, IConverter<TInput, TOutput, TKey> converter)
        {
            Data = data;
            Reader = null;
            Converter = converter;
        }

        /// <summary>
        /// Gets the grouped data.
        /// </summary>
        /// <returns>
        /// the grouped data.
        /// </returns>
        public IEnumerable<TOutput> GetGroupedData()
        {
            if (Reader != null)
                Data = Reader.GetData().ToArray();
            return Data
                .GroupBy(Converter.KeySelector)
                .Select(Converter.Convert);
        }

        /// <summary>
        /// Gets the averaged data.
        /// </summary>
        /// <param name="groupSize">Size of the group.</param>
        /// <returns>
        /// the averaged data.
        /// </returns>
        public IEnumerable<TOutput> GetAveraged(int groupSize = 3)
        {
            var grouped = GetGroupedData().ToArray();
            var averages = new List<TOutput>();
            for (int i = 0; i<=grouped.Length - groupSize; i++)
            {
                var slice = grouped.Skip(i).Take(groupSize);
                averages.Add(Converter.AverageProperties(slice, groupSize));
            }
            return averages;
        }
    }
}
