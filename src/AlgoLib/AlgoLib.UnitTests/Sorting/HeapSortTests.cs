using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoLib.Sorting;
using System.Collections.Generic;

namespace AlgoLib.UnitTests.Sorting
{
    [TestClass]
    public class HeapSortTests
    {
        [TestMethod]
        public void SimpleIntArrayHeapSortTest()
        {
            int[] data = { 45, 25, 4, 88, 96, 18, 101, 7 };
            Sorter.HeapSort(data);
            for (int i = 1; i < data.Length; i++)
            {
                Assert.IsTrue(data[i - 1] <= data[i]);
            }
            Sorter.HeapSort(data, SortOrder.Descending);
            for (int i = 1; i < data.Length; i++)
            {
                Assert.IsTrue(data[i - 1] >= data[i]);
            }
        }

        [TestMethod]
        public void SimpleListHeapSortTest()
        {
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            Sorter.HeapSort(data);
            for (int i = 1; i < data.Count; i++)
            {
                Assert.IsTrue(data[i - 1] <= data[i]);
            }
            Sorter.HeapSort(data, SortOrder.Descending);
            for (int i = 1; i < data.Count; i++)
            {
                Assert.IsTrue(data[i - 1] >= data[i]);
            }
        }

        [TestMethod]
        public void ComplexListHeapSortTest()
        {
            IList<MergeSortTestData> data = new List<MergeSortTestData> 
            { 
                new MergeSortTestData { Name = "Robert", Age = 43.5 },
                new MergeSortTestData { Name = "Miller", Age = 13.5 },
                new MergeSortTestData { Name = "Robert", Age = 44.5 },
                new MergeSortTestData { Name = "Andrew", Age = 23.5 }
            };
            Sorter.HeapSort(data);
            Assert.AreEqual(data[0].Name, "Andrew");
            Assert.AreEqual(data[1].Name, "Miller");
            Assert.AreEqual(data[2].Age, 43.5);
            Assert.AreEqual(data[3].Age, 44.5);
        }

        [TestMethod]
        public void ComplexWithNullsListHeapSortTest()
        {
            IList<MergeSortTestData> data = new List<MergeSortTestData> 
            { 
                new MergeSortTestData { Name = "Robert", Age = 43.5 },
                null,
                new MergeSortTestData { Name = "Andrew", Age = 23.5 },
                null
            };
            Sorter.HeapSort(data);
            Assert.IsNull(data[0]);
            Assert.IsNull(data[1]);
            Assert.AreEqual(data[2].Name, "Andrew");
            Assert.AreEqual(data[3].Name, "Robert");
        }
    }
}
