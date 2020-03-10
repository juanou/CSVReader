using Clissold.BLL;
using Clissold.BO;
using SpreadsheetLight;
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
        public static bool LeerArchivo()
        {
            Console.WriteLine("Leyendo Archivo ");
            const string path = @"C:\Users\crs80162\Documents\Git\Clissold.CSVReader\Clissold.CSVReader\Archivo\StockUpdater.xlsx";
            List<BunchBO> BunchList = new List<BunchBO>();
            const Decimal StdPieceMeter = 60;
            int CurrentIndex = 0;
            SLDocument sl = new SLDocument(path);

            for (int iRow = 2; !string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)); iRow++)
            {
                string mtrCal = sl.GetCellValueAsString(iRow, 8);
                if (mtrCal.Contains("P/E")) { mtrCal = mtrCal.Replace("P/E", ""); }

                BunchBO Pieza = new BunchBO
                {
                    Dte = sl.GetCellValueAsString(iRow, 1),
                    Name = sl.GetCellValueAsString(iRow, 2),
                    SetNO = sl.GetCellValueAsString(iRow, 4),
                    REF = sl.GetCellValueAsString(iRow, 3),
                    Created = DateTime.Today.ToShortDateString(),
                    Month = DateTime.Now.ToString("MMMM"),
                    Nopces = sl.GetCellValueAsString(iRow, 8),
                    Quality = sl.GetCellValueAsString(iRow, 5),
                    Design = sl.GetCellValueAsString(iRow, 6),
                    Shade = sl.GetCellValueAsString(iRow, 7),                 
                    Meters = Decimal.Parse(mtrCal) * StdPieceMeter
                };

                BunchList.Add(Pieza);
                CurrentIndex++;
                ProgressBar.DrawProgressBar(CurrentIndex, BunchList.Count);
            }

            Console.WriteLine("\n\r");
            Console.WriteLine("Items Agregados:" + BunchList.Count);

            if (NextStep()) {
                Bunch.Delete();// Borrar stock Modificar mas adelante...              
                Bunch.Guardar(BunchList);
                
            }
            Console.WriteLine("\n\r Cerrando consola");
            Thread.Sleep(1500);
            return true;
        }

        public static bool NextStep()
        {
            Console.WriteLine("Desea agregar la info a la bd Si/No");
            if (string.Equals(Console.ReadLine(), "SI", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Borrando Datos de la tabla \n\r");
                Console.Clear();
                return true;

            }
            else
            {                
                return false;
            }
        }
    }
}
