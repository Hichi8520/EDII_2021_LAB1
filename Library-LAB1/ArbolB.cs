using System;
using System.Collections.Generic;
using System.Text;

namespace Library_LAB1
{
    public class ArbolB<T> where T : IComparable
    {
        NodoB<T> raiz = new NodoB<T>();

        List<T> ListValuesToShow = new List<T>();

        int grado = 7;
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
                    if(i < actual.valores.Count - 1)
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

            for(int i = 0; i < grado; i++)
            {
                if(i < divi)
                {
                    dos.valores.Add(uno.valores[i]);
                }

                if(i > divi)
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
                padre.valores.Add(uno.valores[divi]);
                padre.hijos.RemoveAt(padre.hijos.Count - 1);

                dos.padre = padre;
                tres.padre = padre;

                padre.hijos.Add(dos);
                padre.hijos.Add(tres);

                if(padre.valores.Count == grado)
                {
                    return separacion_padre(padre, padre.padre, grado);
                }
                else
                {
                    return padre;
                }
            }
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
            if(value.padre != default)
            {
                regresar_inicio(value.padre);
            }
            return value;
        }
    }
}
