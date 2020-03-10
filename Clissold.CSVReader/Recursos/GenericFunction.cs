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
                    REF = sl.GetCellValueAsString(iRow, 3),
                    SetNO = sl.GetCellValueAsString(iRow, 4),
                    Quality = sl.GetCellValueAsString(iRow, 5),
                    Design = sl.GetCellValueAsString(iRow, 6),
                    Shade = sl.GetCellValueAsString(iRow, 7),
                    Nopces = sl.GetCellValueAsString(iRow, 8),
                    Created = DateTime.Today.ToShortDateString(),
                    Month = DateTime.Now.Month.ToString("MMMM"),
                    Meters = Decimal.Parse(mtrCal) * StdPieceMeter
                };

                BunchList.Add(Pieza);
                CurrentIndex++;
                ProgressBar.DrawProgressBar(CurrentIndex, BunchList.Count);
            }

            Console.WriteLine("\n");
            Console.WriteLine("Items Agregados:" + BunchList.Count);

            if (NextStep()) { Bunch.Guardar(BunchList); }

            return true;
        }

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
