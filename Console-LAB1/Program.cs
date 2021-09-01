using System;
using Library_LAB1;

namespace Console_LAB1
{
    class Program
    {
        static void Main(string[] args)
        {
            int valor = 0;
            Console.WriteLine("Ingrese el grado del Árbol B -- Debe de ser un número impar mayor o igual a 3");
            valor = Convert.ToInt32(Console.ReadLine());
            if (valor >= 3)
            {
                ArbolB<int> Pruebas = new ArbolB<int>(valor);
                valor = 1;
                while (valor != 3)
                {
                    Console.Clear();
                    Console.WriteLine("Selecciones una opción");
                    Console.WriteLine("1.- Ingresar valores");
                    Console.WriteLine("2.- Eliminar valores");
                    Console.WriteLine("3.- Salir");
                    switch (valor = Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            while (valor != 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Ingrese un valor para agregarlo al Árbol B");
                                valor = Convert.ToInt32(Console.ReadLine());
                                if (valor != 0)
                                    Pruebas.insertar(valor);
                            }
                            break;
                        case 2:
                            while (valor != 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Ingrese un valor para eliminarlo del Árbol B");
                                valor = Convert.ToInt32(Console.ReadLine());
                                Pruebas.eliminar(valor);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("En número ingresado es incorrecto -- CHAO");
            }
        }
    }
}
