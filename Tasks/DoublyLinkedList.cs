using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private int _length;

        private CustomNode<T> _head;

        public DoublyLinkedList()
        {
            _length = 0;
        }

        public int Length => _length;

        public void Add(T e)
        {
            var newNode = new CustomNode<T>(e);

            if (_head != null)
            {
                CustomNode<T> lastNode = GetLastNode();
                lastNode.Next = newNode;
                newNode.Prev = lastNode;
            }
            else
            {
                _head = newNode;
            }

            _length++;
        }

        public void AddAt(int index, T e)
        {
            var newNode = new CustomNode<T>(e);

            if (index == 0)
            {
                newNode.Next = _head;
                _head = newNode;

                return;
            }

            if (_head != null)
            {
                var nodeByIndex = GetNodeByIndex(index);

                if (nodeByIndex == null && index == _length)
                {
                    Add(e);
                    return;
                }

                newNode.Next = nodeByIndex;
                nodeByIndex.Prev.Next = newNode;
                newNode.Prev = nodeByIndex.Prev;
            }
            else
            {
                _head = newNode;
            }

            _length++;
        }

        public T ElementAt(int index)
        {
            var node = GetNodeByIndex(index);

            if (node == null)
            {
                throw new IndexOutOfRangeException();
            }

            return node.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = _head;
            var list = new List<T>();

            while (node != null)
            {
                list.Add(node.Data);
                node = node.Next;
            }

            return list.GetEnumerator();
        }

        public void Remove(T item)
        {
            var temp = _head;
            CustomNode<T> prev = null;

            if (temp != null && temp.Data.Equals(item))
            {
                _head = temp.Next;

                _length--;
                return;
            }

            while (temp != null && !temp.Data.Equals(item))
            {
                prev = temp;
                temp = temp.Next;
            }

            if (temp == null)
            {
                return;
            }

            prev.Next = temp.Next;
            _length--;
        }

        public T RemoveAt(int index)
        {
            var temp = _head;
            CustomNode<T> prev = null;
            int i = 0;

            if (temp != null && i == index)
            {
                _head = temp.Next;

                _length--;
                return temp.Data;
            }

            while (temp != null && i != index)
            {
                prev = temp;
                temp = temp.Next;
                i++;
            }

            if (temp == null)
            {
                throw new IndexOutOfRangeException();
            }

            prev.Next = temp.Next;
            _length--;

            return temp.Data;
        }

        private CustomNode<T> GetLastNode()
        {
            var node = _head;

            while (node.Next != null)
            {
                node = node.Next;
            }

            return node;
        }

        private CustomNode<T> GetNodeByIndex(int index)
        {
            var node = _head;
            int i = 0;

            while (node != null)
            {
                if (i == index)
                {
                    return node;
                }

                node = node.Next;
                i++;
            }

            return node;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
