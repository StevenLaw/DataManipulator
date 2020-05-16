using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulator.Interfaces
{
    /// <summary>
    /// A simple reader that allows the customization of fetching data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReader<T>
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// the data.
        /// </returns>
        IEnumerable<T> GetData();
    }
}
