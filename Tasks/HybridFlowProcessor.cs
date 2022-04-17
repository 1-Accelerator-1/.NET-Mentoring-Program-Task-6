using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoublyLinkedList<T> _doublyLinkedList;

        public HybridFlowProcessor()
        {
            _doublyLinkedList = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            try
            {
                return _doublyLinkedList.RemoveAt(0);
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }

        public void Enqueue(T item)
        {
            _doublyLinkedList.Add(item);
        }

        public T Pop()
        {
            try
            {
                return _doublyLinkedList.RemoveAt(_doublyLinkedList.Length - 1);
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }

        public void Push(T item)
        {
            _doublyLinkedList.Add(item);
        }
    }
}
