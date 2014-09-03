using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoLib.UnitTests
{
    public class MergeSortTestData : IComparable
    {
        public string Name { get; set; }
        public double Age { get; set; }

        public int CompareTo(object obj)
        {
            var other = obj as MergeSortTestData;
            if (null == other) return 1; //null is always less
            if (this.Name == other.Name)
            {
                return this.Age.CompareTo(other.Age);
            }
            return this.Name.CompareTo(other.Name);
        }
    }
}
