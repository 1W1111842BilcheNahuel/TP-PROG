using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TpFinalPorg
{
    public partial class frmPrincipal : Form
    {
        bool activo;
        int m, mx, my;
        public frmPrincipal()
        {
            InitializeComponent();
            abmClientes.Hide();
            abmClientes.Enabled = false;
            btnMinimize.Visible = false;
            contactanos.Hide();
            contactanos.Enabled = false;
            activo = false;
            btnVolver.Hide();
            vehiculos.Hide();
            vehiculos.Enabled = false;
            autopartes.Hide();
            autopartes.Enabled = false;
            reportes.Hide();
            reportes.Enabled = false;
            ventas.Hide();
            ventas.Enabled = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();           
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            if (CerrarUser() == false)
            {
                abmClientes.Show();
                abmClientes.Enabled = true;                
                activo = true;
                btnVolver.Show();
                btnVolver.Location = btnClientes.Location;
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMinimize.Visible = true;
            btnMaximize.Visible = false;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximize.Visible = true;
            btnMinimize.Visible = false;
        }

        private void tHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnContacto_Click(object sender, EventArgs e)
        {
            if (CerrarUser() == false)
            {
                contactanos.Show();
                contactanos.Enabled = true;
                activo = true;
                btnVolver.Show();
                btnVolver.Location = btnContacto.Location;
            }
        }

        private bool CerrarUser()
        {
            if (activo == true)
            {
                if (abmClientes.Enabled == true)
                {
                    abmClientes.Enabled = false;
                    abmClientes.Hide();
                    activo = false;
                }
                if (contactanos.Enabled == true)
                {
                    contactanos.Enabled = false;
                    contactanos.Hide();
                    activo = false;
                }
                if (vehiculos.Enabled == true)
                {
                    vehiculos.Enabled = false;
                    vehiculos.Hide();
                    activo = false;
                }
                if (autopartes.Enabled == true)
                {
                    autopartes.Enabled = false;
                    autopartes.Hide();
                    activo = false;
                }
                if (reportes.Enabled == true)
                {
                    reportes.Enabled = false;
                    reportes.Hide();
                    activo = false;
                }
                if (ventas.Enabled == true)
                {
                    ventas.Enabled = false;
                    ventas.Hide();
                    activo = false;
                }
            }
            return activo;           
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            CerrarUser();
            btnVolver.Hide();
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            if (CerrarUser() == false)
            {
                vehiculos.Enabled = true;
                vehiculos.Show();
                activo = true;
                btnVolver.Show();
                btnVolver.Location = btnVehiculos.Location;
            }

        }

        private void btnAutopartes_Click(object sender, EventArgs e)
        {
            if (CerrarUser() == false)
            {
                autopartes.Show();
                autopartes.Enabled = true;
                activo = true;
                btnVolver.Show();
                btnVolver.Location = btnAutopartes.Location;
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (CerrarUser() == false)
            {
                reportes.Show();
                reportes.Enabled = true;
                activo = true;
                btnVolver.Show();
                btnVolver.Location = btnReportes.Location;
            }
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?", "SALIENDO", MessageBoxButtons.YesNo,
                                                               MessageBoxIcon.Question,
                                                               MessageBoxDefaultButton.Button1)
                                                                               == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;



        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        //Mover Form----------------------
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void reportes_Load(object sender, EventArgs e)
        {

        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            if (CerrarUser() == false)
            {
                ventas.Show();
                ventas.Enabled = true;
                activo = true;
                btnVolver.Show();
                btnVolver.Location = btnVenta.Location;
            }
        }
    

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
        //FIN Mover Form-----------------
    }
}
