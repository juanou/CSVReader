using Clissold.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clissold.DAL;
namespace Clissold.BLL
{
    public static class Bunch
    {
        public static void Guardar(List<BunchBO> bunchList)
        {
             new BunchDAL().Guardar(bunchList);
        }
    }
}
