using System;

namespace ClassLibrary
{
    public class Node
    {
        public long data { get; set; }
        public Node next { get; set; }
        public Node prev { get; set; }

        public Node(long Data)
        {
            data = Data;
            next = null;
            prev = null;
        }
    }
}
