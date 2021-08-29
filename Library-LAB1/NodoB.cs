using System;
using System.Collections.Generic;
using System.Text;

namespace Library_LAB1
{
    public class NodoB<T> where T: IComparable
    {
        public List<T> valores = new List<T>(); //arreglo de valores en el NodoB
        public List<NodoB<T>> hijos = new List<NodoB<T>>(); //arreglo de NodoBs hijo
        public NodoB<T> padre { get; set; }
    }
}
