using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalPorg
{
    class Vendedor
    {
        public int pCodigo { get; set; }
        public string pNombre { get; set; }
        public string pApellido { get; set; }
        public string pCalle { get; set; }
        public int pAltura { get; set; }
        public string  pEmail { get; set; }
        public DateTime pFecha_ingreso { get; set; }
        public int pId_barrio { get; set; }

        override public string ToString()
        {
            return pCodigo + " - " + pApellido + " " +pNombre;
        }
    }
}
