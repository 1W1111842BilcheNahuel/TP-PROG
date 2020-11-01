using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TpFinalPorg
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

   

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (ValidarUsuario())
            {
                MessageBox.Show("Se ingreso correctamente");
                frmPrincipal ventana = new frmPrincipal();
                ventana.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("El Nombre de usuario y o Contraseña son incorrectos");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarUsuario()
        {
            bool resultado = false;
            
            string cadena = "Data Source = 25.87.37.19; Initial Catalog = tplab6; User ID = augusto; Password = augusto1";
            SqlConnection con = new SqlConnection(cadena);
            SqlCommand comando = new SqlCommand("validarusuarios", con);
            comando.Parameters.Clear();
            comando.Parameters.Add(new SqlParameter("@usuario", txtUsuario.Text));
            comando.Parameters.Add(new SqlParameter("@contraseña", txtContraseña.Text));           
            comando.CommandType = CommandType.StoredProcedure;         
            con.Open();
            comando.Connection = con;
            


            DataTable tabla = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(comando);
            adp.Fill(tabla);
            con.Close();

            if (tabla.Rows.Count == 1)
            {
                resultado = true;
            }
            return resultado;
        }
    }
}
