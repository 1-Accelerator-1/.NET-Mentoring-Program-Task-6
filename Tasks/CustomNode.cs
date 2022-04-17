namespace Tasks
{
    public class CustomNode<T>
    {
        public CustomNode(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }

        public T Data { get; set; }

        public CustomNode<T> Next { get; set; }

        public CustomNode<T> Prev { get; set; }
    }
}
