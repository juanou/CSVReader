using IBM.Data.DB2.iSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clissold.DAL
{
   public class BaseDAL
    {
        public iDB2Connection _Cn = new iDB2Connection("datasource=servidor;User ID=usuaer;Password=paswww;");

    }
}
