using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoLib.Merging;
using System.Collections.Generic;
using AlgoLib.Sorting;

namespace AlgoLib.UnitTests.Merging
{
    [TestClass]
    public class SortedMergeTests
    {
        [TestMethod]
        public void SimpleSortedMergeTest()
        {
            int[] a = { 1, 3, 6, 102, 105, 230 };
            int[] b = { 101, 103, 112, 155, 231 };

            int prev = 0;
            int count = 0;
            foreach (var val in Merger.SortedMerge<int>(a, b))
            {
                Assert.IsTrue(val > prev);
                prev = val;
                count++;
            }
            Assert.AreEqual(count, 11);
        }

        [TestMethod]
        public void ComplexWithNullsListSortedMergeTest()
        {
            IList<MergeSortTestData> a = new List<MergeSortTestData> 
            { 
                null,
                new MergeSortTestData { Name = "Robert", Age = 43.5 },
            };
            IList<MergeSortTestData> b = new List<MergeSortTestData> 
            { 
                null,
                new MergeSortTestData { Name = "Robert", Age = 23.5 },
            };
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
    }
}
