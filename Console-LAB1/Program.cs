using System;
using Library_LAB1;

namespace Console_LAB1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbolB<int> Pruebas = new ArbolB<int>(5);
            int valor = 1;
            while (valor != 0)
            {
                Console.WriteLine("ingrese un valor");
                valor = Convert.ToInt32(Console.ReadLine());
                Pruebas.insertar(valor);
            }
        }
    }
}
