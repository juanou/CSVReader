using System;
using System.Collections.Generic;
using Clissold.BO;
using Dapper;
namespace Clissold.DAL
{
    public class BunchDAL : BaseDAL
    {
        public void Guardar(List<BunchBO> bunchList)
        {
            int CurrentIndex = 0;            
            Console.WriteLine("\n Guardando información \n");
            //Recorrer lsita para agregar al as400 no funciona bien haciendo el bulk insert pasando directo la lista
            foreach (var item in bunchList)
            {
                string query = @"INSERT INTO CRSFILE.CLSWEBSTK(DTE, NAME, SETNO, REF, CREATED, MONTH, NOPCES, QUALITY, DESIGN, SHADE, METERS) 
                                                        VALUES (@_Dte, @_Name, @_SetNO, @_REF, @_Created, @_Month, @_Nopces, @_Quality, @_Design, @_Shade, @_Meters)";
                base._Cn.Execute(query, new
                { 
                    _Dte = item.Dte,
                    _Name = item.Name,
                    _SetNO = item.SetNO,
                    _REF = item.REF,
                    _Created = item.Created,
                    _Month = item.Month,
                    _Nopces = item.Nopces,
                    _Quality = item.Quality,
                    _Design = item.Design,
                    _Shade = item.Shade,
                    _Meters = item.Meters
                
                });

                ProgressBar.DrawProgressBar(CurrentIndex++, bunchList.Count);
            }


           

        }

        public void Delete()
        {
            string query = @"DELETE FROM CRSFILE.CLSWEBSTK";
            base._Cn.Execute(query);
        }

        public static class ProgressBar
        {
            public static void DrawProgressBar(int progress, int total)
            {
                //draw empty progress bar
                Console.CursorLeft = 0;
                Console.Write(" "); //start
                Console.CursorLeft = 32;
                Console.Write(" "); //end
                Console.CursorLeft = 1;
                float onechunk = 30.0f / total;

                //draw filled part
                int position = 1;
                for (int i = 0; i < onechunk * progress; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.CursorLeft = position++;
                    Console.Write(" ");
                }

                //draw unfilled part
                for (int i = position; i <= 31; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.CursorLeft = position++;
                    Console.Write(" ");
                }

                //draw totals
                Console.CursorLeft = 35;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(progress.ToString() + " of " + total.ToString() + "    "); //blanks at the end remove any excess
            }
        }
    }
}
