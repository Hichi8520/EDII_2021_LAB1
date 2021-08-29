using System;

namespace Library_LAB1
{
    class Nodo<T> where T : IComparable
    {
        public T value { get; set; }
        public Nodo<T> Left { get; set; }
        public Nodo<T> Right { get; set; }
    }
}
