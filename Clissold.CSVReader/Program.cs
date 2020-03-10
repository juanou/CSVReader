using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clissold.BO;
using Clissold.BLL;
using Clissold.CSVReader.Recursos;
using System.Threading;

namespace Clissold.CSVReader
{
    static class Program
    {
        private static void Main(string[] args)
        {
            Console.SetWindowSize(110,30);            
            Console.Title = "Soy Nelson v1 app";
            Console.WriteLine("========== Hola Developer ===========");

            try
            {
                GenericFunction.LeerArchivo();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }

    }
}
