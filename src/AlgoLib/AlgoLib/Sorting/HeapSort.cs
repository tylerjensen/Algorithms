using AlgoLib.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoLib.Sorting
{
    public enum SortOrder
    {
        Ascending,
        Descending
    }

    /// <summary>
    /// Sorter supplies classic sorting algorithms.
    /// </summary>
    public static partial class Sorter
    {
        /// <summary>
        /// HeapSort is an in-place sort with O(n lg n) run time using Heap structure.
        /// </summary>
        public static void HeapSort<T>(IList<T> data, 
            SortOrder ascending = SortOrder.Ascending) where T : IComparable
        {
            var heapSize = data.Count;
            if (ascending == SortOrder.Ascending)
                Heap.BuildMaxHeap(data);
            else
                Heap.BuildMinHeap(data);
            for (int index = data.Count - 1; index > 0; index--)
            {
                //exchange data[0] with data[i]
                var tempRef = data[0];
                data[0] = data[index];
                data[index] = tempRef;
                //maxify with diecremented heap size to achieve ascending order sort
                heapSize--;
                if (ascending == SortOrder.Ascending)
                    Heap.MaxHeapify(data, 0, heapSize);
                else
                    Heap.MinHeapify(data, 0, heapSize);
            }
        }
    }
}
