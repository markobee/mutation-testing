using System.Collections;

namespace LinkedList
{
    public class LinkedListLight<T> : ICollection<T> where T : IComparable<T>
    {
        public class LinkedListNode<T>
        {
            public T info;
            public LinkedListNode<T> next;
            public LinkedListNode(T data, LinkedListNode<T> next = null)
            {
                info = data;
                this.next = next;
            }
        }

        public LinkedListNode<T> _first;
        public LinkedListNode<T> _last;

        private class Enumerator : IEnumerator<T>
        {
            private readonly LinkedListNode<T> _first;
            private LinkedListNode<T> _current;
            private bool atBegin;

            public Enumerator(LinkedListNode<T> first)
            {
                _first = first;
                _current = null;
                atBegin = true;
            }
            public void Dispose() { }

            public bool MoveNext()
            {
                if (atBegin)
                {
                    atBegin = false;
                    _current = _first;
                    return true;
                }
                else
                {
                    _current = _current.next;
                    return _current != null;
                }
            }

            public void Reset()
            {
                atBegin = true;
                _current = null;
            }

            public T Current
            {
                get { return _current.info; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void ICollection<T>.Add(T item)
        {
            LinkedListNode<T> tmp = new(item, null);
            if (Count == 0)
                _first = tmp;
            else
                _last.next = tmp;
            _last = tmp;
            ++Count;
        }

        public void AddLast(T item)
        {
            ((ICollection<T>)this).Add(item);
        }

        public void Clear()
        {
            _first = null;
            _last = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var x in this)
                if (x.Equals(item))
                    return true;
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int i = arrayIndex;
            foreach (var item in this)
            {
                array[i] = item;
                ++i;
            }
        }

        public bool Remove(T item)
        {
            if (_first != null && _first.info.Equals(item))
            {
                _first = _first.next;
                Count = Count - 1;
                return true;
            }
            else
            {
                LinkedListNode<T> before = FindPrev(item);
                if (before == null)
                    return false;
                before.next = before.next?.next;
                Count = Count - 1;
                return true;
            }
        }

        private LinkedListNode<T> FindPrev(T item)
        {
            var prev = _first;
            var cur = _first?.next;
            while (cur != null)
            {
                if (cur.info.Equals(item))
                    return prev;
                prev = cur;
                cur = cur.next;
            }
            return null;
        }

        public int Count { get; private set; }

        public bool IsReadOnly {get {return false;}}

        public void InsertionSort()
        {
            LinkedListNode<T> old = _first;
            _first = null;
            while (old != null)
            {
                LinkedListNode<T> tmp = old;
                old = old.next;
                tmp.next = null;
                Insert(tmp);
            }
        }

// Stryker disable once Equality
        private void Insert(LinkedListNode<T> tmp)
        {
            if (_first == null)
            {
                _first = tmp;
                _last = tmp;
            }
            else if (_first.info.CompareTo(tmp.info) >= 0)
            {
                tmp.next = _first;
                _first = tmp;
            }
            else if (_last.info.CompareTo(tmp.info) <= 0)
            {
                _last.next = tmp;
                _last = tmp;
            }
            else
            {
                LinkedListNode<T> prev = _first;
                LinkedListNode<T> cur = _first.next;

                while (cur != null && cur.info.CompareTo(tmp.info) < 0)
                {
                    prev = cur;
                    cur = cur.next;
                }
                tmp.next = cur;
                prev.next = tmp;
            }
        }
// Stryker restore Equality


    }
}