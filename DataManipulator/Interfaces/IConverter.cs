using System;
using System.Collections.Generic;

namespace DataManipulator.Interfaces
{
    /// <summary>
    /// Converter template for the <see cref="DataManipulator"/>
    /// </summary>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    /// <typeparam name="TKey">The type of the key to group by.</typeparam>
    public interface IConverter<TInput, TOutput, TKey>
    {
        /// <summary>
        /// Gets the key selector.
        /// </summary>
        /// <value>
        /// The key selector.
        /// </value>
        /// <remarks>
        /// Is to be used in a group by statment.
        /// </remarks>
        Func<TInput, TKey> KeySelector { get; }
        /// <summary>
        /// Converts the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// the item.
        /// </returns>
        TOutput Convert(IEnumerable<TInput> item);
        /// <summary>
        /// Averages the properties.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="groupSize">Size of the group.</param>
        /// <returns>
        /// a list of <see cref="TOutput" /> objects containing averages over the group size.
        /// </returns>
        TOutput AverageProperties(IEnumerable<TOutput> item, int groupSize);
    }
}
