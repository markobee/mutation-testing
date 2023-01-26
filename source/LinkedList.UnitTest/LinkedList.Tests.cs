namespace LinkedList.UnitTest
{
    
    public class Tests
    {
        internal const int TestListCount = 10;

        internal LinkedListLight<int> GetSampleSortedList()
        {
            LinkedListLight<int> list = new ();
            Assert.IsFalse(list.IsReadOnly);
            for (int i = 0; i < TestListCount; i++)
                list.AddLast(i + 1);

            return list;
        }
        internal LinkedListLight<int> GetSampleReverseSortedList()
        {
            LinkedListLight<int> list = new();
            Assert.IsFalse(list.IsReadOnly);
            for (int i = TestListCount; i >= 0; i--)
                list.AddLast(i + 1);

            return list;
        }

        internal LinkedListLight<int> GetSampleSameValueList()
        {
            var list = new LinkedListLight<int>();
            Assert.IsFalse(list.IsReadOnly);
            for (int i = 0; i < TestListCount; i++)
                list.AddLast(4);

            return list;
        }

        internal LinkedListLight<int> GetSampleUnsortedList()
        {
            var list = new LinkedListLight<int>();
            Assert.IsFalse(list.IsReadOnly);
            list.AddLast(5);
            list.AddLast(4);
            list.AddLast(6);
            list.AddLast(7);
            list.AddLast(3);
            list.AddLast(9);
            list.AddLast(8);
            list.AddLast(2);
            list.AddLast(10);
            list.AddLast(1);

            return list;
        }

        [Test]
        public void TestAddElements()
        {
            // GetSample will already add elements
            // we will only check if the result is corrrect
            var list = GetSampleSortedList();
            for (int i = 0; i < list.Count; i++)
                Assert.IsTrue(list.ElementAt(i) == i + 1);
        }

        private bool CheckAndRemove(LinkedListLight<int> list, int element)
        {
            return list.Contains(element) 
            && list.Remove(element);
        }

        [Test]
        public void TestRemoveElement()
        {
            var elment = 5;
            var list = GetSampleSortedList();
            Assert.IsTrue(CheckAndRemove(list, elment));
            Assert.IsFalse(list.Contains(elment));
            Assert.IsFalse(list.Contains(5));
        }
        [Test]
        public void TestRemoveFirstElement()
        {
            int element = 1;
            var list = GetSampleSortedList();
            Assert.IsTrue(CheckAndRemove(list, element));
            Assert.IsFalse(list.Contains(element));
            Assert.IsFalse(list.Contains(1));
        }
        [Test]
        public void TestRemoveUnknownElement()
        {
            int unknowElement = 12;
            var list = GetSampleSortedList();
            Assert.IsFalse(CheckAndRemove(list, unknowElement));
        }

        [Test]
        public void TestCopyElements()
        {
            var list = GetSampleSortedList();
            var copies = new int[list.Count];
            list.CopyTo(copies, 0);
            for (int i = 0; i < copies.Length; i++)
                Assert.IsTrue(copies[i] == list.ElementAt(i));
        }
        [Test]
        public void TestClearElements()
        {
            var list = GetSampleSortedList();
            list.Clear();
        }

        [Test]
        public void TestCopyElementsToSmallArray()
        {
            var list = GetSampleSortedList();
            var copies = new int[list.Count / 2];
            //Assert.Throws<IndexOutOfRangeException>(() => list.CopyTo(copies, 0));
        }

        
        private void SortList(Func<LinkedListLight<int>> getListFunc, Action<LinkedListLight<int>> sortAction)
        {
            var list = getListFunc();
            sortAction(list);
            for (int i = 0; i < list.Count; i++)
                Assert.IsTrue(list.ElementAt(i) == i + 1);
        }
        
        private void SortListSameValueList(Func<LinkedListLight<int>> getListFunc, Action<LinkedListLight<int>> sortAction)
        {
            var list = getListFunc();
            sortAction(list);
            for (int i = 1; i < list.Count; i++)
                Assert.IsTrue(list.ElementAt(i-1) == list.ElementAt(i));
        }
        
        [Test]
        public void TestInsertionReverseSortList()
        {
            SortList(GetSampleReverseSortedList, l => l.InsertionSort());
        }

        [Test]
        public void TestInsertionSortList()
        {
            SortList(GetSampleUnsortedList, l => l.InsertionSort());
        }
        [Test]
        public void TestInsertionSortSameValueList()
        {
            SortListSameValueList(GetSampleSameValueList, l => l.InsertionSort());
        }

    }
}