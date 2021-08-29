using System;

namespace Console_LAB1
{
    class Program
    {
        static void Main(string[] args)
        {
            Library_LAB1.ArbolB<int> Pruebas = new Library_LAB1.ArbolB<int>();
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
