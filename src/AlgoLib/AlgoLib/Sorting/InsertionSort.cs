using System;
using System.Collections.Generic;

namespace AlgoLib.Sorting
{
    /// <summary>
    /// The insertion sort is easy and fast for smaller sets of data.
    /// </summary>
    public static partial class Sorter
    {
        /// <summary>
        /// Simple insertion sort of IList or array in place.
        /// </summary>
        /// <typeparam name="T">Type to be sorted.</typeparam>
        /// <param name="data">IList or array to be sorted.</param>
        public static void InsertionSort<T>(IList<T> data) 
            where T : IComparable
        {
            if (data == null || data.Count < 2) return;
            for (int keyIndex = 1; keyIndex < data.Count; keyIndex++)
            {
                var key = data[keyIndex];
                var priorIndex = keyIndex - 1;
                while (priorIndex > -1 
                    && data[priorIndex] != null 
                    && data[priorIndex].CompareTo(key) > 0)
                {
                    data[priorIndex + 1] = data[priorIndex];
                    priorIndex -= 1;
                }
                data[priorIndex + 1] = key;
            }
        }
    }
}
