using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoLib.Structures
{
    public enum PriorityOrder
    {
        Min,
        Max
    }

    public class PriorityQueue<T> : IEnumerable<T>, ICollection, IEnumerable where T : IComparable
    {
        private readonly PriorityOrder _order;
        private readonly IList<T> _data;
        private int _heapSize = 0;

        public PriorityQueue(PriorityOrder order)
        {
            _data = new List<T>();
            _order = order;
        }

        public PriorityQueue(IEnumerable<T> data, PriorityOrder order)
        {
            _data = new List<T>(data);
            _order = order;
            _heapSize = _data.Count;
            if (_order == PriorityOrder.Max)
                Heap.BuildMaxHeap(_data);
            else
                Heap.BuildMinHeap(_data);
        }

        public PriorityQueue(int initialCapacity, PriorityOrder order)
        {
            _data = new List<T>(initialCapacity);
            _order = order;
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool Contains(T item)
        {
            if (_order == PriorityOrder.Max)
                return Heap.MaxContains(_data, item, 0, _heapSize);
            else
                return Heap.MinContains(_data, item, 0, _heapSize);
        }

        public T Dequeue()
        {
            if (_heapSize == 0) throw new InvalidOperationException();
            if (_order == PriorityOrder.Max)
                return Heap.ExtractMax(_data, _heapSize--);
            else
                return Heap.ExtractMin(_data, _heapSize--);
        }

        public void Enqueue(T item, T minItem, T maxItem)
        {
            if (_order == PriorityOrder.Max)
                Heap.MaxInsert(_data, item, maxItem, _heapSize++);
            else
                Heap.MinInsert(_data, item, minItem, _heapSize++);
        }

        public T Peek()
        {
            return _data[0];
        }

        public void TrimExcess()
        {
            // trim remove items in _data beyond _heapSize
            while (_heapSize < _data.Count)
            {
                _data.RemoveAt(_data.Count - 1);
            }
        }

        public T[] ToArray()
        {
            return _data.ToArray();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            _data.CopyTo((T[])array, index);
        }

        public int Count
        {
            get { return _heapSize; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return _data; }
        }
    }
}
