using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpFinalPorg
{
    public partial class ABMClientes : UserControl
    {
        Datos oDatos = new Datos();
        List<Clientes> LC = new List<Clientes>();
        enum Accion
        {
            Nuevo,
            Editado,
        }

        Accion MiAccion = Accion.Editado;
        
        public ABMClientes()
        {
            InitializeComponent();
            for (int i = 0; i < LC.Count; i++)
            {
                LC[i] = null;
            }
        }

        private void ABMClientes_Load(object sender, EventArgs e)
        {
            Habilitar(false);
            cargarListas("Clientes");
            CargarCombo(cmbBarrio, "Barrios", "id_barrio", "barrio");
            CargarCombo(cmbTipoCliente, "Tipo_Clientes", "id_tipo_cliente", "tipo_cliente");
            CargarCombo(cmbTipoDoc, "Tipos_Documento", "id_tipo_doc", "tipo_doc");
        }

        //Metodos

            //Habilitar 
        private void Habilitar(bool x)
        {
            txtNombre.Enabled = x;
            txtApellido.Enabled = x;
            cmbBarrio.Enabled = x;
            cmbTipoCliente.Enabled = x;
            cmbTipoDoc.Enabled = x;
            txtNumeroDoc.Enabled = x;
            txtCalle.Enabled = x;
            txtEmail.Enabled = x;
            txtAltura.Enabled = x;
            txtTelefono.Enabled = x;
            lstClientes.Enabled = !x;
            btnCancelar.Enabled = x;
            btnEditar.Enabled = !x;
            btnGrabar.Enabled = x;
            btnEliminar.Enabled = !x;
            btnGrabar.Enabled = x;
            btnNuevo.Enabled = !x;
        }
        
            //Limpiar
        private void Limpiar()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtAltura.Text = "";
            txtCalle.Text = "";
            txtEmail.Text = "";
            txtNumeroDoc.Text = "";
            txtTelefono.Text = "";
            cmbBarrio.SelectedIndex = -1;
            cmbTipoCliente.SelectedIndex = -1;
            cmbTipoDoc.SelectedIndex = -1;
        }

            //Cargar Combo
        private void CargarCombo(ComboBox combo, string nombreTabla, string pk, string nombreCampo)
        {
            Clientes oClientes = new Clientes();
            DataTable tabla = new DataTable();
            tabla = oClientes.GetClientes(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = nombreCampo;
            combo.ValueMember = pk;
        }

            //Validar Datos
        private bool ValidarDatos()
        {
            if (txtApellido.Text == "")
            {
                txtApellido.Focus();
                MessageBox.Show("Ingrese Apellido!");
                return false;
            }
            if (txtNombre.Text == "")
            {
                txtNombre.Focus();
                MessageBox.Show("Ingrese Nombre!");
                return false;
            }
            if (txtNumeroDoc.Text == "")
            {
                txtNumeroDoc.Focus();
                MessageBox.Show("Ingrese Numero de Documento!");
                return false;
            }
            if (txtCalle.Text == "")
            {
                txtCalle.Focus();
                MessageBox.Show("Ingrese Calle!");
                return false;
            }
            if (txtAltura.Text == "")
            {
                txtAltura.Focus();
                MessageBox.Show("Ingrese Altura!");
                return false;
            }
            if (txtEmail.Text == "")
            {
                txtEmail.Focus();
                MessageBox.Show("Ingrese E-Mail!");
                return false;
            }
            if (txtTelefono.Text == "")
            {
                txtTelefono.Focus();
                MessageBox.Show("Ingrese Telefono!");
                return false;
            }
            if (cmbBarrio.SelectedIndex == -1)
            {
                cmbBarrio.Focus();
                MessageBox.Show("Seleccione Barrio!");
                return false;
            }
            if (cmbTipoCliente.SelectedIndex == -1)
            {
                cmbTipoCliente.Focus();
                MessageBox.Show("Seleccione Tipo de Cliente!");
                return false;
            }
            if (cmbTipoDoc.SelectedIndex == -1)
            {
                cmbTipoDoc.Focus();
                MessageBox.Show("Seleccione Tipo de Documento!");
                return false;
            }
            return true;
        }
        //Cargar Listas
        public void cargarListas(string Tabla)
        {
            oDatos.LeerTabla(Tabla);
            LC.Clear();
            while (oDatos.Lector.Read())
            {
                Clientes cl = new Clientes();

                if (!oDatos.Lector.IsDBNull(0))
                {
                    cl.pId_cliente = oDatos.Lector.GetInt32(0);
                }
                if (!oDatos.Lector.IsDBNull(1))
                {
                    cl.pNombre = oDatos.Lector.GetString(1);
                }

                if (!oDatos.Lector.IsDBNull(2))
                {
                    cl.pApellido = oDatos.Lector.GetString(2);
                }
                if (!oDatos.Lector.IsDBNull(3))
                {
                    cl.pNro_doc = oDatos.Lector.GetInt32(3);
                }
                if (!oDatos.Lector.IsDBNull(4))
                {
                    cl.pTelefono = oDatos.Lector.GetString(4);
                }
                if (!oDatos.Lector.IsDBNull(5))
                {
                    cl.pId_barrio = oDatos.Lector.GetInt32(5);
                }
                if (!oDatos.Lector.IsDBNull(10))
                {
                    cl.pId_Tipo_Doc = oDatos.Lector.GetInt32(10);
                }
                if (!oDatos.Lector.IsDBNull(6))
                {
                    cl.pCalle = oDatos.Lector.GetString(6);
                }
                if (!oDatos.Lector.IsDBNull(7))
                {
                    cl.pNro_calle = oDatos.Lector.GetInt32(7);
                }
                if (!oDatos.Lector.IsDBNull(8))
                {
                    cl.pEmail = oDatos.Lector.GetString(8);
                }
                if (!oDatos.Lector.IsDBNull(9))
                {
                    cl.pId_Tipo_Cliente = oDatos.Lector.GetInt32(9);
                }
                
                LC.Add(cl);
            }
            oDatos.Desconectar();
            lstClientes.Items.Clear();
            oDatos.Lector.Close();

            for (int i = 0; i < LC.Count; i++)
            {
                lstClientes.Items.Add(LC[i].ToString());
            }
            lstClientes.SelectedIndex = 0;
        }

        //Cargar Campos
        private void CargarCampos(int posicion)
        {
            
            txtApellido.Text = LC[posicion].pApellido.ToString();
            txtNombre.Text = LC[posicion].pNombre.ToString();
            txtNumeroDoc.Text = LC[posicion].pNro_doc.ToString();
            txtTelefono.Text = LC[posicion].pTelefono.ToString();
            cmbBarrio.SelectedValue = LC[posicion].pId_barrio; 
            cmbTipoDoc.SelectedValue = LC[posicion].pId_Tipo_Doc;
            txtCalle.Text = LC[posicion].pCalle.ToString();
            txtAltura.Text = LC[posicion].pNro_calle.ToString();
            txtEmail.Text = LC[posicion].pEmail.ToString();
            cmbTipoCliente.SelectedValue = LC[posicion].pId_Tipo_Cliente;
        }

        private void lstClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCampos(lstClientes.SelectedIndex);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Habilitar(true);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            Limpiar();
            txtNombre.Focus();
            
        }
    }
}
