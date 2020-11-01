using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalPorg
{
    class Clientes
    {
        Datos oDatos = new Datos();   
        int id_cliente;
        string nombre;
        string apellido;
        int nro_doc;
        string telefono;
        int id_barrio;
        int Id_Tipo_Doc;
        string calle;
        int nro_calle;
        string email;
        int Id_Tipo_Cliente;


        public int pId_cliente { get => id_cliente; set => id_cliente = value; }
        public string pNombre { get => nombre; set => nombre = value; }
        public string pApellido { get => apellido; set => apellido = value; }
        public int pNro_doc { get => nro_doc; set => nro_doc = value; }
        public string pTelefono { get => telefono; set => telefono = value; }
        public int pId_barrio { get => id_barrio; set => id_barrio = value; }
        public int pId_Tipo_Doc { get => Id_Tipo_Doc; set => Id_Tipo_Doc = value; }
        public string pCalle { get => calle; set => calle = value; }
        public int pNro_calle { get => nro_calle; set => nro_calle = value; }
        public string pEmail { get => email; set => email = value; }
        public int pId_Tipo_Cliente { get => Id_Tipo_Cliente; set => Id_Tipo_Cliente = value; }

        public override string ToString()
        {
            return id_cliente + " - " + nombre + " " + apellido;
        }

        public DataTable GetClientes(string nombreTabla)
        {
            return oDatos.ConsultarTabla(nombreTabla);
        }
    }
}
