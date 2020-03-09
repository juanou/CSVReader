using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clissold.BO;
using Dapper;

namespace Clissold.DAL
{
    public class BunchDAL : BaseDAL
    {
        public void Guardar(List<BunchBO> bunchList)
        {
            string query = string.Format(@"INSERT INTO  CRSFILE.CLSWEBSTK() 
                                                        VALUES ()");
            base._Cn.Execute(query, bunchList);
           
        }
    }
}
