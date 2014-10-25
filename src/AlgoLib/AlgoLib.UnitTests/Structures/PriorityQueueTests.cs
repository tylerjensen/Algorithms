using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AlgoLib.Structures;
using System.Threading;

namespace AlgoLib.UnitTests.Structures
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void PeekTest()
        {
            // from 45, 25, 4, 88, 96, 18, 101, 7
            //   to 101, 96, 45, 88, 25, 18, 4, 7
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            var queue = new PriorityQueue<int>(data, PriorityOrder.Min);
            var val = queue.Peek();
            Assert.IsTrue(val == 4);

            queue = new PriorityQueue<int>(data, PriorityOrder.Max);
            val = queue.Peek();
            Assert.IsTrue(val == 101);
        }

        [TestMethod]
        public void DequeueMinTest()
        {
            // from 45, 25, 4, 88, 96, 18, 101, 7
            //   to 101, 96, 45, 88, 25, 18, 4, 7
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            var queue = new PriorityQueue<int>(data, PriorityOrder.Min);
            var val = queue.Dequeue();
            Assert.IsTrue(val == 4);
            Assert.IsTrue(queue.Count == 7);
            val = queue.Dequeue();
            Assert.IsTrue(val == 7);
            Assert.IsTrue(queue.Count == 6);
        }

        [TestMethod]
        public void DequeueMaxTest()
        {
            // from 45, 25, 4, 88, 96, 18, 101, 7
            //   to 101, 96, 45, 88, 25, 18, 4, 7
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            var queue = new PriorityQueue<int>(data, PriorityOrder.Max);
            var val = queue.Dequeue();
            Assert.IsTrue(val == 101);
            Assert.IsTrue(queue.Count == 7);
            val = queue.Dequeue();
            Assert.IsTrue(val == 96);
            Assert.IsTrue(queue.Count == 6);
        }

        [TestMethod]
        public void EnqueueMinTest()
        {
            // from 45, 25, 4, 88, 96, 18, 101, 7
            //   to 101, 96, 45, 88, 25, 18, 4, 7
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            var queue = new PriorityQueue<int>(data, PriorityOrder.Min);
            queue.Enqueue(2, int.MinValue, int.MaxValue);
            Assert.IsTrue(queue.Count == 9);
            var val = queue.Dequeue();
            Assert.IsTrue(val == 2);
            Assert.IsTrue(queue.Count == 8);
            val = queue.Peek();
            Assert.IsTrue(val == 4);
            Assert.IsTrue(queue.Count == 8);
        }

        [TestMethod]
        public void EnqueueMaxTest()
        {
            // from 45, 25, 4, 88, 96, 18, 101, 7
            //   to 101, 96, 45, 88, 25, 18, 4, 7
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            var queue = new PriorityQueue<int>(data, PriorityOrder.Max);
            queue.Enqueue(232, int.MinValue, int.MaxValue);
            Assert.IsTrue(queue.Count == 9);
            var val = queue.Dequeue();
            Assert.IsTrue(val == 232);
            Assert.IsTrue(queue.Count == 8);
            val = queue.Peek();
            Assert.IsTrue(val == 101);
            Assert.IsTrue(queue.Count == 8);
        }

        [TestMethod]
        public void EnqueueMaxMinTest()
        {
            // from 45, 25, 4, 88, 96, 18, 101, 7
            //   to 101, 96, 45, 88, 25, 18, 4, 7
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            var queue = new PriorityQueue<int>(data, PriorityOrder.Max);
            queue.Enqueue(2, int.MinValue, int.MaxValue);
            Assert.IsTrue(queue.Count == 9);
            var val = queue.Dequeue();
            Assert.IsTrue(val == 101);
            Assert.IsTrue(queue.Count == 8);
            val = queue.Peek();
            Assert.IsTrue(val == 96);
            Assert.IsTrue(queue.Count == 8);
        }

        [TestMethod]
        public void EnqueueMinMaxTest()
        {
            // from 45, 25, 4, 88, 96, 18, 101, 7
            //   to 101, 96, 45, 88, 25, 18, 4, 7
            IList<int> data = new List<int> { 45, 25, 4, 88, 96, 18, 101, 7 };
            var queue = new PriorityQueue<int>(data, PriorityOrder.Min);
            queue.Enqueue(2322, int.MinValue, int.MaxValue);
            Assert.IsTrue(queue.Count == 9);
            var val = queue.Dequeue();
            Assert.IsTrue(val == 4);
            Assert.IsTrue(queue.Count == 8);
            val = queue.Peek();
            Assert.IsTrue(val == 7);
            Assert.IsTrue(queue.Count == 8);
        }


        [TestMethod]
        public void DateTimeTest()
        {
            var rnd = new Random();
            var queue = new PriorityQueue<DateTime>(PriorityOrder.Min);
            for (int i = 0; i < 100; i++)
            {
                var ms = rnd.Next(20, 2000);
                Thread.Sleep(ms);
                var offset = rnd.Next(5, 10) - 10;
                var dt = DateTime.Now.AddSeconds(offset);

                var peek = (queue.Count > 0) ? queue.Peek() : DateTime.MinValue;

                if (dt > peek)
                    queue.Enqueue(dt, DateTime.MinValue, DateTime.MaxValue);

                if (queue.Count > 20)
                {
                    var dq = queue.Dequeue();
                    Assert.IsTrue(dq <= dt);
                }
            }
        }

        [TestMethod]
        public void JobTest()
        {
            IList<Job> jobs = new List<Job> 
            {
                new Job { JobId = "test1", Priority = 45.0 },
                new Job { JobId = "test2", Priority = 25.0 },
                new Job { JobId = "test3", Priority = 4.0 },
                new Job { JobId = "test4", Priority = 88.0 },
                new Job { JobId = "test5", Priority = 96.0 },
                new Job { JobId = "test6", Priority = 18.0 },
                new Job { JobId = "test7", Priority = 101.0 },
                new Job { JobId = "test8", Priority = 7.0 }
            };
            var jobQueue = new PriorityQueue<Job>(jobs, PriorityOrder.Max);
            jobQueue.Enqueue(new Job 
                                 { 
                                     JobId = "test8", 
                                     Priority = 232.0 
                                 },
                                 // min and max needed for MaxInsert or MinInsert
                                 Job.MinValue, Job.MaxValue);
            Assert.IsTrue(jobQueue.Count == 9);
            var val = jobQueue.Dequeue();
            Assert.IsTrue(val.Priority == 232.0);
            Assert.IsTrue(jobQueue.Count == 8);
            Assert.IsTrue(jobQueue.Size == 9); //heapSize not same
            val = jobQueue.Peek();
            Assert.IsTrue(val.Priority == 101.0);
            jobQueue.TrimExcess();
            Assert.IsTrue(jobQueue.Count == jobQueue.Size);
        }

    }

    public class Job : IComparable
    {
        public string JobId { get; set; }
        public double Priority { get; set; }

        public int CompareTo(object obj)
        {
            var other = obj as Job;
            if (null == other) return 1; //null is always less
            return this.Priority.CompareTo(other.Priority);
        }

        private static Job _min;
        private static Job _max;

        public static Job MinValue
        {
            get
            {
                if (_min == null)
                {
                    _min = new Job { JobId = null, Priority = double.MinValue };
                }
                return _min;
            }
        }

        public static Job MaxValue
        {
            get
            {
                if (_max == null)
                {
                    _max = new Job { JobId = null, Priority = double.MaxValue };
                }
                return _max;
            }
        }
    }
}
