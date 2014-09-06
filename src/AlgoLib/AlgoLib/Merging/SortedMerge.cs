using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoLib.Merging
{
    public static partial class Merger
    {
        public static IEnumerable<T> SortedMerge<T>
            (params IEnumerable<T>[] sortedSources)
            where T : IComparable
        {
            if (sortedSources == null || sortedSources.Length == 0)
                throw new ArgumentNullException("sortedSources");

            //1. fetch enumerators for each sourc
            var enums = (from n in sortedSources
                         select n.GetEnumerator()).ToArray();

            //2. create index list indicating what MoveNext returned for each enumerator
            var enumHasValue = new List<bool>(enums.Length);
            // MoveNext on all and initialize enumHasValue
            for (int i = 0; i < enums.Length; i++)
            {
                enumHasValue.Add(enums[i].MoveNext());
            }

            // if all false, nothing to iterate over
            if (enumHasValue.All(x => !x)) yield break;

            //3. loop through
            while (true)
            {
                //find index with lowest value
                var lowIdx = -1;
                T lowVal = default(T);
                for (int i = 0; i < enums.Length; i++)
                {
                    if (enumHasValue[i])
                    {
                        // must get first before doing any compares
                        if (lowIdx < 0 
                            || null == enums[i].Current //null sorts lowest
                            || enums[i].Current.CompareTo(lowVal) < 0)
                        {
                            lowIdx = i;
                            lowVal = enums[i].Current;
                        }
                    }
                }

                //if none found, we're done
                if (lowIdx < 0) break;

                //get next value for enumerator chosen
                enumHasValue[lowIdx] = enums[lowIdx].MoveNext();

                //yield up the lowest value
                yield return lowVal;
            }
        }
    }
}
