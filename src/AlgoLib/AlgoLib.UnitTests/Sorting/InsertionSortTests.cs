using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoLib.Sorting;
using System.Collections.Generic;

namespace AlgoLib.UnitTests.Sorting
{
    [TestClass]
    public class InsertionSortTests
    {
        [TestMethod]
        public void SimpleIntArrayInsertionSortTest()
        {
            int[] data = { 45, 25, 4, 88, 96, 18, 101, 7 };
            Sorter.InsertionSort(data);
            Assert.AreEqual(data[0], 4);
            Assert.AreEqual(data[1], 7);
            Assert.AreEqual(data[2], 18);
            Assert.AreEqual(data[3], 25);
            Assert.AreEqual(data[4], 45);
            Assert.AreEqual(data[5], 88);
            Assert.AreEqual(data[6], 96);
            Assert.AreEqual(data[7], 101);
        }

        [TestMethod]
        public void SimpleListInsertionSortTest()
        {
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            Sorter.InsertionSort(data);
            Assert.AreEqual(data[0], 4);
            Assert.AreEqual(data[1], 7);
            Assert.AreEqual(data[2], 18);
            Assert.AreEqual(data[3], 25);
            Assert.AreEqual(data[4], 45);
            Assert.AreEqual(data[5], 88);
            Assert.AreEqual(data[6], 96);
            Assert.AreEqual(data[7], 101);
        }

        [TestMethod]
        public void ComplexListInsertionSortTest()
        {
            IList<MergeSortTestData> data = new List<MergeSortTestData> 
            { 
                new MergeSortTestData { Name = "Robert", Age = 43.5 },
                new MergeSortTestData { Name = "Miller", Age = 13.5 },
                new MergeSortTestData { Name = "Robert", Age = 44.5 },
                new MergeSortTestData { Name = "Andrew", Age = 23.5 }
            };
            Sorter.InsertionSort(data);
            Assert.AreEqual(data[0].Name, "Andrew");
            Assert.AreEqual(data[1].Name, "Miller");
            Assert.AreEqual(data[2].Age, 43.5);
            Assert.AreEqual(data[3].Age, 44.5);
        }

        [TestMethod]
        public void ComplexWithNullsListInsertionSortTest()
        {
            IList<MergeSortTestData> data = new List<MergeSortTestData> 
            { 
                new MergeSortTestData { Name = "Robert", Age = 43.5 },
                null,
                new MergeSortTestData { Name = "Andrew", Age = 23.5 },
                null
            };
            Sorter.InsertionSort(data);
            Assert.IsNull(data[0]);
            Assert.IsNull(data[1]);
            Assert.AreEqual(data[2].Name, "Andrew");
            Assert.AreEqual(data[3].Name, "Robert");
        }
    }
}
