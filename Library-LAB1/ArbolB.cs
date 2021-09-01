using System;
using System.Collections.Generic;
using System.Text;

namespace Library_LAB1
{
    public class ArbolB<T> where T : IComparable
    {
        NodoB<T> raiz = new NodoB<T>();

        List<T> ListValuesToShow = new List<T>();

        int grado = 0;

        /*******************Creación del Árbol B ***************************/
        public ArbolB(int grado)
        {
            this.grado = grado;
        }
        /**************Inserción de valores en el Árbol B*******************/
        public void insertar(T valor)
        {
            if (raiz.valores.Count == 0) //si el arbol esta vacio
            {
                NodoB<T> nodo = new NodoB<T>();
                nodo.padre = null;
                nodo.valores.Add(valor);
                raiz = nodo;
            }
            else //si hay otro valor en el arbol
            {
                insercion(valor, raiz, raiz.padre, raiz.valores, grado);
            }
        }

        void insercion(T valor, NodoB<T> actual, NodoB<T> padre, List<T> valores, int grado)
        {
            for (int i = 0; i < actual.valores.Count; i++)
            {
                if (actual.valores[i].CompareTo(valor) == 0)
                {
                    // valor rechazado
                    break;
                }
                else if (actual.valores[i].CompareTo(valor) < 0)
                {
                    // valor mayor
                    if (i < actual.valores.Count - 1)
                    {
                        if (actual.valores[i + 1].CompareTo(valor) > 0)
                        {
                            if (actual.hijos.Count == 0) // sin hijos
                            {
                                if (actual.valores.Count < (grado - 1)) // verificamos si hay espacio en el nodo
                                {
                                    actual.valores.Add(valor);
                                    actual.valores.Sort();
                                    break;
                                }
                                else
                                {
                                    actual.valores.Add(valor);
                                    actual.valores.Sort();
                                    raiz = regresar_inicio(separacion(actual, padre, grado));
                                    break;
                                }
                            }
                            else
                            {
                                insercion(valor, actual.hijos[i + 1], actual, actual.hijos[i + 1].valores, grado);
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (actual.hijos.Count == 0) // sin hijos
                        {
                            if (actual.valores.Count < (grado - 1)) // verificamos si hay espacio en el nodo
                            {
                                actual.valores.Add(valor);
                                actual.valores.Sort();
                                break;
                            }
                            else
                            {
                                actual.valores.Add(valor);
                                actual.valores.Sort();
                                raiz = regresar_inicio(separacion(actual, padre, grado));
                                break;
                            }
                        }
                        else
                        {
                            insercion(valor, actual.hijos[i + 1], actual, actual.hijos[i + 1].valores, grado);
                            break;
                        }
                    }
                }
                else if (actual.valores[i].CompareTo(valor) > 0)
                {
                    // valor menor
                    if (i < actual.valores.Count - 1)
                    {
                        if (actual.valores[i + 1].CompareTo(valor) > 0)
                        {
                            if (actual.hijos.Count == 0) // sin hijos
                            {
                                if (actual.valores.Count < (grado - 1)) // verificamos si hay espacio en el nodo
                                {
                                    actual.valores.Add(valor);
                                    actual.valores.Sort();
                                    break;
                                }
                                else
                                {
                                    actual.valores.Add(valor);
                                    actual.valores.Sort();
                                    raiz = regresar_inicio(separacion(actual, padre, grado));
                                    break;
                                }
                            }
                            else
                            {
                                insercion(valor, actual.hijos[i], actual, actual.hijos[i].valores, grado);
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (actual.hijos.Count == 0) // sin hijos
                        {
                            if (actual.valores.Count < (grado - 1)) // verificamos si hay espacio en el nodo
                            {
                                actual.valores.Add(valor);
                                actual.valores.Sort();
                                break;
                            }
                            else
                            {
                                actual.valores.Add(valor);
                                actual.valores.Sort();
                                raiz = regresar_inicio(separacion(actual, padre, grado));
                                break;
                            }
                        }
                        else
                        {
                            insercion(valor, actual.hijos[i], actual, actual.hijos[i].valores, grado);
                            break;
                        }
                    }
                }
            }
        }

        NodoB<T> separacion(NodoB<T> actual, NodoB<T> padre, int grado)
        {
            NodoB<T> uno = new NodoB<T>();
            NodoB<T> dos = new NodoB<T>();
            NodoB<T> tres = new NodoB<T>();

            uno = actual;

            double posicion_intermedio = grado / 2;
            int divi = (int)Math.Round(posicion_intermedio);

            for (int i = 0; i < grado; i++)
            {
                if (i < divi)
                {
                    dos.valores.Add(uno.valores[i]);
                }

                if (i > divi)
                {
                    tres.valores.Add(uno.valores[i]);
                }
            }

            NodoB<T> cuatro = new NodoB<T>();


            if (padre == default)
            {
                cuatro.valores.Add(uno.valores[divi]);

                dos.padre = cuatro;
                tres.padre = cuatro;

                cuatro.hijos.Add(dos);
                cuatro.hijos.Add(tres);

                return cuatro;
            }
            else
            {
                for (int i = 0; i < uno.valores.Count; i++)
                {
                    if (padre.hijos[i].valores == uno.valores) // removemos el hijo que se está modificando
                    {
                        padre.hijos.RemoveAt(i);
                        break;
                    }
                }
                padre.valores.Add(uno.valores[divi]);
                padre.valores.Sort();

                dos.padre = padre;
                tres.padre = padre;

                padre.hijos.Add(dos);
                padre.hijos.Add(tres);

                padre = ordenar_hijos(padre);

                if (padre.valores.Count == grado)
                {
                    return separacion_padre(padre, padre.padre, grado);
                }
                else
                {
                    return padre;
                }
            }
        }

        public NodoB<T> ordenar_hijos(NodoB<T> data)
        {
            for (int i = 0; i < data.hijos.Count - 1; i++)
            {
                for (int j = i + 1; j < data.hijos.Count; j++)
                {
                    if (!object.Equals(data.hijos[i].valores[0], default(T)) && !object.Equals(data.hijos[j].valores[0], default(T)))
                    {
                        if (data.hijos[i].valores[0].CompareTo(data.hijos[j].valores[0]) > 0)
                        {
                            var aux = data.hijos[i];
                            data.hijos[i] = data.hijos[j];
                            data.hijos[j] = aux;
                        }
                    }
                }
            }
            return data;
        }

        NodoB<T> separacion_padre(NodoB<T> actual, NodoB<T> padre, int grado)
        {
            NodoB<T> uno = new NodoB<T>();
            NodoB<T> dos = new NodoB<T>();
            NodoB<T> tres = new NodoB<T>();

            uno = actual;

            double posicion_intermedio = grado / 2;
            int divi = (int)Math.Round(posicion_intermedio);

            for (int i = 0; i < grado; i++)
            {
                if (i < divi)
                {
                    dos.valores.Add(uno.valores[i]);
                }

                if (i > divi)
                {
                    tres.valores.Add(uno.valores[i]);
                }
            }

            for (int i = 0; i <= grado; i++)
            {
                if (i <= divi)
                {
                    dos.hijos.Add(uno.hijos[i]);
                }

                if (i > divi)
                {
                    tres.hijos.Add(uno.hijos[i]);
                }
            }


            if (padre != default)
            {
                padre.valores.Add(uno.valores[divi]);
                padre.hijos.RemoveAt(padre.hijos.Count - 1);

                dos.padre = padre;
                tres.padre = padre;

                padre.hijos.Add(dos);
                padre.hijos.Add(tres);

                return padre;
            }
            else
            {
                NodoB<T> cuatro = new NodoB<T>();

                cuatro.valores.Add(uno.valores[divi]);

                dos.padre = cuatro;
                tres.padre = cuatro;

                cuatro.hijos.Add(dos);
                cuatro.hijos.Add(tres);

                return cuatro;
            }

        }

        NodoB<T> regresar_inicio(NodoB<T> value)
        {
            if (value.padre != default)
            {
                regresar_inicio(value.padre);
            }
            return value;
        }

        /**************Eliminación de valores en el Árbol B*******************/
        public void eliminar(T valor)
        {
            eliminar(valor, raiz, raiz.padre, raiz.valores, grado, 0);
        }
        void eliminar(T valor, NodoB<T> actual, NodoB<T> padre, List<T> valores, int grado, int posicion_anterior)
        {
            for (int i = 0; i < actual.valores.Count; i++)
            {
                if (actual.valores[i].CompareTo(valor) == 0)
                {
                    // valor igual
                    int valores_min = grado / 2;

                    if (actual.valores.Count > valores_min)
                    {
                        actual.valores.RemoveAt(i);
                    }
                    else
                    {
                        if ((posicion_anterior + 1) == padre.valores.Count) // Esto indica que el valor esta en el ultimo hijo
                        {

                        }
                        else if (posicion_anterior > 0 && posicion_anterior < padre.valores.Count) // Esto indica que el valor tiene hermano izquierdo y derecho
                        {

                        }
                    }
                }
                else if (actual.valores[i].CompareTo(valor) < 0)
                {
                    // valor mayor
                    if (i < actual.valores.Count - 1)
                    {
                        if (actual.valores[i + 1].CompareTo(valor) > 0)
                        {
                            if (actual.hijos.Count == 0) // sin hijos
                            {

                            }
                            else
                            {
                                eliminar(valor, actual.hijos[i + 1], actual, actual.hijos[i + 1].valores, grado, i);
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (actual.hijos.Count == 0) // sin hijos
                        {

                        }
                        else
                        {
                            eliminar(valor, actual.hijos[i + 1], actual, actual.hijos[i + 1].valores, grado, i);
                            break;
                        }
                    }
                }
                else if (actual.valores[i].CompareTo(valor) > 0)
                {
                    // valor menor
                }
            }
        }

        //************* RECORRIDOS *************

        private void InOrder(NodoB<T> nodo_actual, int g)
        {
            for (int i = 0; i <= g; i++)
            {
                if (nodo_actual.hijos.Count > 0 && !object.Equals(nodo_actual.hijos[i], default))
                {
                    InOrder(nodo_actual.hijos[i], nodo_actual.hijos[i].valores.Count);
                }
                if (i < g)
                {
                    if (!object.Equals(nodo_actual.valores[i], default(T)))
                    {
                        ListValuesToShow.Add(nodo_actual.valores[i]);

                    }
                }
            }
        }
        public List<T> InOrder(int g)
        {
            ListValuesToShow.Clear();
            InOrder(raiz, raiz.valores.Count);
            return ListValuesToShow;
        }

        private void PreOrder(NodoB<T> nodo_actual, int g)
        {
            for (int i = 0; i <= g; i++)
            {
                if (i < g)
                {
                    if (!object.Equals(nodo_actual.valores[i], default(T)))
                    {
                        ListValuesToShow.Add(nodo_actual.valores[i]);
                    }
                }
            }

            for (int i = 0; i <= g; i++)
            {
                if (nodo_actual.hijos.Count > 0 && !object.Equals(nodo_actual.hijos[i], default))
                {
                    PreOrder(nodo_actual.hijos[i], nodo_actual.hijos[i].valores.Count);
                }
            }
        }
        public List<T> PreOrder(int g)
        {
            ListValuesToShow.Clear();
            PreOrder(raiz, raiz.valores.Count);
            return ListValuesToShow;
        }

        private void PostOrder(NodoB<T> nodo_actual, int g)
        {
            for (int i = 0; i <= g; i++)
            {
                if (nodo_actual.hijos.Count > 0 && !object.Equals(nodo_actual.hijos[i], default))
                {
                    PostOrder(nodo_actual.hijos[i], nodo_actual.hijos[i].valores.Count);
                }
            }

            for (int i = 0; i <= g; i++)
            {
                if (i < g)
                {
                    if (!object.Equals(nodo_actual.valores[i], default(T)))
                    {
                        ListValuesToShow.Add(nodo_actual.valores[i]);
                    }
                }
            }
        }
        public List<T> PostOrder(int g)
        {
            ListValuesToShow.Clear();
            PostOrder(raiz, raiz.valores.Count);
            return ListValuesToShow;
        }
    }
}
