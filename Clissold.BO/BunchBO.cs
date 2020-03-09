using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clissold.BO
{
    public class BunchBO : PieceBO
    {
        public string Dte { get; set; }
        public string Name { get; set; }
        //numero de bunch
        public string SetNO { get; set; }
        public string REF { get; set; }
        public string Created { get; set; }
        public string Month { get; set; }
    }
}
