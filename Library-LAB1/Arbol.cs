using System;
using System.Collections.Generic;
using System.Text;

namespace Library_LAB1
{
    public class Arbol<T>
    {
        Nodo<int> Raiz = new Nodo<int>();
        public void Insertar(int a)
        {
            if (Raiz.value == 0)
            {
                Raiz.value = a;
                Raiz.Left = null;
                Raiz.Right = null;
            }
            else
            {
                Nodo<int> Temporal = Raiz;
                Nodo<int> Temporal_insercion = new Nodo<int>();

                while (Temporal != null)
                {
                    if(Temporal.value < a)
                    {
                        if(Temporal.Right != null)
                        {
                            Temporal = Temporal.Right;
                        }
                        else
                        {
                            Temporal_insercion.value = a;
                            Temporal_insercion.Right = null;
                            Temporal_insercion.Left = null;
                            Temporal.Right = Temporal_insercion;
                            break;
                        }
                    }
                    else
                    {
                        if (Temporal.Left != null)
                        {
                            Temporal = Temporal.Left;
                        }
                        else
                        {
                            Temporal_insercion.value = a;
                            Temporal_insercion.Right = null;
                            Temporal_insercion.Left = null;
                            Temporal.Left = Temporal_insercion;
                            break;
                        }

                    }
                }
            }
        }
    }
}
