using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TpFinalPorg
{
    class Datos
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        string conectionstring = @"Data Source = 25.87.37.19; Initial Catalog = tplab6; User ID = augusto; Password = augusto1";


        //Properties
        public string Conectionstring { get => conectionstring; set => conectionstring = value; }
        public SqlDataReader Lector { get => lector; set => lector = value; }


        //Constructores

        public Datos()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = conectionstring;
            comando = new SqlCommand();

        }
        public Datos(string conectionstring)
        {
            conexion = new SqlConnection(conectionstring);
            comando = new SqlCommand();
        }

        //Metodos

        public void Conectar()
        {
            conexion.ConnectionString = conectionstring;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }

        public void Desconectar()
        {
            conexion.Close();
        }

        public void LeerTabla(string nombreTabla)
        {
            Conectar();
            comando.CommandText = "Select * from " + nombreTabla;
            Lector = comando.ExecuteReader();
        }

        public DataTable ConsultarTabla(string nombreTabla)
        {
            Conectar();
            comando.CommandText = "select * from " + nombreTabla;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            Desconectar();
            return tabla;
        }
        public void Actualizar(string consultaSQL)
        {
            Conectar();
            comando.CommandText = consultaSQL;
            comando.ExecuteNonQuery();
            Desconectar();

        }
    }
}
