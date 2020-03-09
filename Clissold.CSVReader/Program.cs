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
            Console.WriteLine("Leyendo Archivo ");
            const string path = @"C:\Users\crs80162\Documents\Git\Clissold.CSVReader\Clissold.CSVReader\Archivo\StockUpdater.xlsx";
            List<BunchBO> BunchList = new List<BunchBO>();
            const Decimal StdPieceMeter = 60;
            int CurrentIndex = 0;

            try
            {
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
                
                if (GenericFunction.NextStep()) { Bunch.Guardar(BunchList);  }
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
