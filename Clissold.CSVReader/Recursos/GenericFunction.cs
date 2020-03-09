using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clissold.CSVReader.Recursos
{
    public static class GenericFunction
    {
        public static bool NextStep()
        {
            Console.WriteLine("Desea agregar la info a la bd Si/No");
            if (string.Equals(Console.ReadLine(), "SI", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Agregando a la bd");
                return true;
            }
            else
            {
                Console.WriteLine("Cerrando Programa");
                Thread.Sleep(1500);
                return false;
            }
        }
    }
}
