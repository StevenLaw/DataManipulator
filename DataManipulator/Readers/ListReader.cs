using DataManipulator.Interfaces;
using System.Collections.Generic;

namespace DataManipulator.Readers
{
    /// <summary>
    /// Reader for a generic list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="IReader{T}" />
    public class ListReader<T> : IReader<T>
    {
        readonly List<T> data;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListReader{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public ListReader(List<T> data)
        {
            this.data = data;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetData()
        {
            return data;
        }
    }
}
