﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_LAB1;

namespace API_LAB1.Helpers
{
    public class Data<T> where T : IComparable
    {
        public int grado;
        private static Data<T> _instance = null;
        public string path;
        public Type type;
        public ArbolB<T> temp;

        // Variables de apoyo para la separación de nodos
        //public T[] valoresMayores;
        //public T valorMedio;
        //public int idPadre;
        //public int idNodoActual;
        //public int idNodoNuevo;
        //public int[] hijosMayores;

        // Lista para los recorridos del árbol
        public List<T> ListValuesToShow = new List<T>();

        public static Data<T> Instance
        {
            get { if (_instance == null) { _instance = new Data<T>(); } return _instance; }

        }
    }
}
