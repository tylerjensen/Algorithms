using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AlgoLib.Merging;
using AlgoLib.Sorting;

namespace AlgoLib.UnitTests
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void CombinedMergeSortTest()
        {
            IList<MergeSortTestData> a = new List<MergeSortTestData> 
            { 
                new MergeSortTestData { Name = "Robert", Age = 43.5 },
                null,
            };
            IList<MergeSortTestData> b = new List<MergeSortTestData> 
            { 
                new MergeSortTestData { Name = "Robert", Age = 23.5 },
                null,
            };

            Sorter.InsertionSort(a);
            Sorter.InsertionSort(b);

            MergeSortTestData prev = null;
            int count = 0;
            foreach (var val in Merger.SortedMerge<MergeSortTestData>(a, b))
            {
                if (null != val) Assert.IsTrue(val.CompareTo(prev) > 0);
                prev = val;
                count++;
            }
            Assert.AreEqual(count, 4);
        }

        [TestMethod]
        public void CombinedMergeSortFailTest()
        {
            IList<MergeSortTestData> a = new List<MergeSortTestData> 
            { 
                new MergeSortTestData { Name = "Robert", Age = 43.5 },
                null,
            };
            IList<MergeSortTestData> b = new List<MergeSortTestData> 
            { 
                null,
                new MergeSortTestData { Name = "Robert", Age = 23.5 },
            };

            //null is lower value in compareto
            //Sorter.InsertionSort(a);
            //Sorter.InsertionSort(b);

            //merge will not sort
            MergeSortTestData prev = null;
            int count = 0;
            bool passed = true;
            foreach (var val in Merger.SortedMerge<MergeSortTestData>(a, b))
            {
                if (null != val && val.CompareTo(prev) > 0) passed = false;
                prev = val;
                count++;
            }
            Assert.AreEqual(count, 4);
            Assert.AreEqual(passed, false);
        }
    }
}
