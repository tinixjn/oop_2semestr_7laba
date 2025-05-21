using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class DoubList : IEnumerable<long>
    {
        private Node _head;
        private Node _tail;
        private uint _length;

        public DoubList()
        {
            _head = null;
            _tail = null;
            _length = 0;
        }
        public uint Size
        {
            get { return _length; }
        }
        public void isEmpty()
        {
            if (_length == 0)
                throw new InvalidOperationException("The list is empty.");
        }
        public void ValidateIndex(int index)
        {
            if (index < 0 || index >= _length)
                throw new IndexOutOfRangeException("Index out of range.");
        }

        public bool Add(long data)
        {
            Node newNode = new Node(data);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.next = newNode;
                newNode.prev = _tail;
                _tail = newNode;
            }
            _length++;
            return true;
        }

        public long this[int index]
        {
            get
            {
                ValidateIndex(index);

                Node current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current.next;
                }

                return current.data;
            }
        }

        public bool Remove(long data)
        {

            Node current = _head;
            while (current != null)
            {
                if (current.data == data)
                {
                    if (current.prev != null)
                        current.prev.next = current.next;
                    else
                        _head = current.next;
                    if (current.next != null)
                        current.next.prev = current.prev;
                    else
                        _tail = current.prev;
                    _length--;
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            ValidateIndex(index);
            long valueToRemove = this[index];
            return Remove(valueToRemove);
        }

        public (int index, long value) FirstMultipleOfFive()
        {
            Node current = _head;
            int index = 0;
            while (current != null)
            {
                if (current.data % 5 == 0)
                {
                    return (index, current.data);
                }
                current = current.next;
                index++;
            }
            throw new InvalidOperationException("No element is a multiple of five.");
        }

        public long SumElementsOnEvenPositions()
        {
            long sum = 0;
            Node current = _head;
            for (int i = 0; i < _length; i++)
            {
                if (i % 2 != 0)
                {
                    sum += current.data;
                }
                current = current.next;
            }
            return sum;
        }

        public DoubList GetNewListGreaterThan(long data)
        {
            DoubList newList = new DoubList();
            Node current = _head;
            while (current != null)
            {
                if (current.data > data)
                {
                    newList.Add(current.data);
                }
                current = current.next;
            }
            return newList;
        }

        public long Average()
        {
            long sum = 0;
            Node current = _head;
            while (current != null)
            {
                sum += current.data;
                current = current.next;
            }
            return sum / (long)_length;
        }
        public bool RemoveElementsGreaterThanAverage()
        {
            if (_length == 0)
                throw new InvalidOperationException("List is empty.");
            long average = Average();
            Node current = _head;
            while (current != null)
            {
                Node next = current.next;
                if (current.data > average)
                {
                    Remove(current.data);
                }
                current = next;
            }
            return true;
        }

        public IEnumerator<long> GetEnumerator()
        {
            Node current = _head;
            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); 
        }
    }
}
