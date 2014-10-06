using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoLib.Structures;
using System.Collections.Generic;

namespace AlgoLib.UnitTests.Structures
{
    [TestClass]
    public class HeapTests
    {
        /* What a max heap looks like from 45, 25, 4, 88, 96, 18, 101, 7:
         * 
         *                    0
         *                  /   \
         *                 1     2                       
         *                / \   / \
         *               3   4 5   6
         *              /
         *             7
         *                   101
         *            96             45
         *       88        25    18       4
         *    7
         */

        [TestMethod]
        public void MaxHeapifyTest()
        {
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            Heap.MaxHeapify(data, 1, data.Count);
            Assert.IsTrue(data[1] >= data[3]);
            Assert.IsTrue(data[1] >= data[4]);
        }

        [TestMethod]
        public void BuildMaxHeapTest()
        {
            // from 45, 25, 4, 88, 96, 18, 101, 7
            //   to 101, 96, 45, 88, 25, 18, 4, 7
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            Heap.BuildMaxHeap(data);
            Assert.IsTrue(data[0] >= data[1]);
            Assert.IsTrue(data[0] >= data[2]);
            Assert.IsTrue(data[1] >= data[3]);
            Assert.IsTrue(data[1] >= data[4]);
            Assert.IsTrue(data[2] >= data[5]);
            Assert.IsTrue(data[2] >= data[6]);
            Assert.IsTrue(data[3] >= data[7]);
        }

        [TestMethod]
        public void BuildMaxHeapTest_Dupes()
        {
            // from 45, 45, 4, 88, 88, 18, 101, 7
            //   to 101, 88, 45, 45, 88, 18, 4, 7
            IList<int> data = new List<int> { 45, 45, 4, 88, 88, 18, 101, 7 };
            Heap.BuildMaxHeap(data);
            Assert.IsTrue(data[0] >= data[1]);
            Assert.IsTrue(data[0] >= data[2]);
            Assert.IsTrue(data[1] >= data[3]);
            Assert.IsTrue(data[1] >= data[4]);
            Assert.IsTrue(data[2] >= data[5]);
            Assert.IsTrue(data[2] >= data[6]);
            Assert.IsTrue(data[3] >= data[7]);
        }

        /* What a min heap looks like from 45, 25, 4, 88, 96, 18, 101, 7:
         * 
         *                 0
         *               /   \
         *              1     2                       
         *             / \   / \
         *            3   4 5   6
         *           /
         *          7
         *             
         *                 4
         *           7          18
         *       25    96    45    101
         *    88		 
         */

        [TestMethod]
        public void MinHeapifyTest()
        {
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            Heap.MinHeapify(data, 2, data.Count);
            Assert.IsTrue(data[2] <= data[5]);
            Assert.IsTrue(data[2] <= data[6]);
        }

        [TestMethod]
        public void BuildMinHeapTest()
        {
            // from 45, 25, 4, 88, 96, 18, 101, 7
            //   to 4, 7, 18, 25, 96, 45, 101, 88
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            Heap.BuildMinHeap(data);
            Assert.IsTrue(data[0] <= data[1]);
            Assert.IsTrue(data[0] <= data[2]);
            Assert.IsTrue(data[1] <= data[3]);
            Assert.IsTrue(data[1] <= data[4]);
            Assert.IsTrue(data[2] <= data[5]);
            Assert.IsTrue(data[2] <= data[6]);
            Assert.IsTrue(data[3] <= data[7]);
        }

        [TestMethod]
        public void BuildMinHeapTest_Dupes()
        {
            // from 45, 45, 4, 88, 88, 18, 101, 7
            //   to 4, 7, 18, 45, 88, 45, 101, 88
            IList<int> data = new List<int> { 45, 45, 4, 88, 88, 18, 101, 7 };
            Heap.BuildMinHeap(data);
            Assert.IsTrue(data[0] <= data[1]);
            Assert.IsTrue(data[0] <= data[2]);
            Assert.IsTrue(data[1] <= data[3]);
            Assert.IsTrue(data[1] <= data[4]);
            Assert.IsTrue(data[2] <= data[5]);
            Assert.IsTrue(data[2] <= data[6]);
            Assert.IsTrue(data[3] <= data[7]);
        }

        [TestMethod]
        public void HeapContainsTest()
        {
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            Heap.BuildMaxHeap(data);
            Assert.IsTrue(Heap.MaxContains(data, 88, 0, data.Count));
            Assert.IsFalse(Heap.MaxContains(data, 62, 0, data.Count));
            Assert.IsFalse(Heap.MaxContains(data, -62, 0, data.Count));
            Heap.BuildMinHeap(data);
            Assert.IsTrue(Heap.MinContains(data, 88, 0, data.Count));
            Assert.IsFalse(Heap.MinContains(data, 62, 0, data.Count));
            Assert.IsFalse(Heap.MinContains(data, -62, 0, data.Count));
        }

        [TestMethod]
        public void ComplexHeapContainsTest_WithoutNull()
        {
            IList<MergeSortTestData> data = new List<MergeSortTestData> 
            { 
                new MergeSortTestData { Name = "Robert", Age = 43.5 },
                new MergeSortTestData { Name = "Miller", Age = 13.5 },
                new MergeSortTestData { Name = "Robert", Age = 44.5 },
                new MergeSortTestData { Name = "Andrew", Age = 23.5 }
            };
            Heap.BuildMaxHeap(data);
            Assert.IsTrue(Heap.MaxContains(data,
                new MergeSortTestData { Name = "Miller", Age = 13.5 }, 0, data.Count));
            Assert.IsFalse(Heap.MaxContains(data,
                new MergeSortTestData { Name = "Smith", Age = 3.5 }, 0, data.Count));
            Assert.IsFalse(Heap.MaxContains(data, null, 0, data.Count));
            Heap.BuildMinHeap(data);
            Assert.IsTrue(Heap.MinContains(data,
                new MergeSortTestData { Name = "Miller", Age = 13.5 }, 0, data.Count));
            Assert.IsFalse(Heap.MinContains(data,
                new MergeSortTestData { Name = "Smith", Age = 3.5 }, 0, data.Count));
            Assert.IsFalse(Heap.MinContains(data, null, 0, data.Count));
        }

        [TestMethod]
        public void ComplexHeapContainsTest_WithNull()
        {
            IList<MergeSortTestData> data = new List<MergeSortTestData> 
            { 
                new MergeSortTestData { Name = "Robert", Age = 43.5 },
                new MergeSortTestData { Name = "Miller", Age = 13.5 },
                null,
                new MergeSortTestData { Name = "Robert", Age = 44.5 },
                new MergeSortTestData { Name = "Andrew", Age = 23.5 }
            };
            Heap.BuildMaxHeap(data);
            Assert.IsTrue(Heap.MaxContains(data, 
                new MergeSortTestData { Name = "Miller", Age = 13.5 }, 0, data.Count));
            Assert.IsFalse(Heap.MaxContains(data, 
                new MergeSortTestData { Name = "Smith", Age = 3.5 }, 0, data.Count));
            Assert.IsTrue(Heap.MaxContains(data, null, 0, data.Count));
            Heap.BuildMinHeap(data);
            Assert.IsTrue(Heap.MinContains(data,
                new MergeSortTestData { Name = "Miller", Age = 13.5 }, 0, data.Count));
            Assert.IsFalse(Heap.MinContains(data,
                new MergeSortTestData { Name = "Smith", Age = 3.5 }, 0, data.Count));
            Assert.IsTrue(Heap.MinContains(data, null, 0, data.Count));
        }

        /* What a max heap looks like from 45, 25, 4, 88, 96, 18, 101, 7:
         * 
         *                    0
         *                  /   \
         *                 1     2                       
         *                / \   / \
         *               3   4 5   6
         *              / \
         *             7   8
         *                   101
         *            96             45
         *       88        25    18       4
         *    7
         */

        [TestMethod]
        public void MaxInsertTest()
        {
            // from 45, 25, 4, 88, 96, 18, 101, 7
            //   to 101, 96, 45, 88, 25, 18, 4, 7
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            Heap.BuildMaxHeap(data);
            Heap.MaxInsert(data, 32, int.MinValue, data.Count);
            Assert.IsTrue(data[0] >= data[1]);
            Assert.IsTrue(data[0] >= data[2]);
            Assert.IsTrue(data[1] >= data[3]);
            Assert.IsTrue(data[1] >= data[4]);
            Assert.IsTrue(data[2] >= data[5]);
            Assert.IsTrue(data[2] >= data[6]);
            Assert.IsTrue(data[3] >= data[7]);
            Assert.IsTrue(data[3] >= data[8]);
        }

        [TestMethod]
        public void MinInsertTest()
        {
            // from 45, 25, 4, 88, 96, 18, 101, 7
            //   to 4, 7, 18, 25, 96, 45, 101, 88
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            Heap.BuildMinHeap(data);
            Heap.MinInsert(data, 32, int.MaxValue, data.Count);
            Assert.IsTrue(data[0] <= data[1]);
            Assert.IsTrue(data[0] <= data[2]);
            Assert.IsTrue(data[1] <= data[3]);
            Assert.IsTrue(data[1] <= data[4]);
            Assert.IsTrue(data[2] <= data[5]);
            Assert.IsTrue(data[2] <= data[6]);
            Assert.IsTrue(data[3] <= data[7]);
            Assert.IsTrue(data[3] <= data[8]);
        }

        [TestMethod]
        public void ExtractTest()
        {
            // from 45, 25, 4, 88, 96, 18, 101, 7
            //   to 101, 96, 45, 88, 25, 18, 4, 7
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            Heap.BuildMaxHeap(data);
            var heapSize = data.Count;
            int max = Heap.ExtractMax(data, heapSize--);
            Assert.IsTrue(max == 101);
            max = Heap.ExtractMax(data, heapSize--);
            Assert.IsTrue(max == 96);

            data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            Heap.BuildMinHeap(data);
            heapSize = data.Count;
            int min = Heap.ExtractMin(data, heapSize--);
            Assert.IsTrue(min == 4);
            min = Heap.ExtractMin(data, heapSize--);
            Assert.IsTrue(min == 7);
        }
    }
}
