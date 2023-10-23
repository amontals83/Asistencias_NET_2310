using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Asistencias.Logica;
using Asistencias.Datos;

namespace Asistencias.Presentacion
{
    public partial class Personal : UserControl
    {
        public Personal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PanelCargos.Visible = false;
            PanelPaginado.Visible = false;
            PanelRegistros.Visible = true;
            PanelRegistros.Dock = DockStyle.Fill;
            btnGuardarPersonal.Visible = true;
            btnGuardarCambiosPersonal.Visible = false;
            Limpiar();
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtDNI.Clear();
            txtCargo.Clear();
            txtSueldoHora.Clear();
            Buscar_Cargos();
        }

        private void Insertar_Personal()
        {
            Lpersonal param = new Lpersonal();
            Dpersonal funcion = new Dpersonal();
            param.Nombre = txtNombre.Text;
            param.DNI = txtDNI.Text;
            param.Pais = cbxPais.Text;         
        }

        private void Insertar_Cargos()
        {
            if (!String.IsNullOrEmpty(txtAddCargo.Text))
            {
                if (!String.IsNullOrEmpty(txtAddSueldoHora.Text))
                {
                    Lcargos param = new Lcargos();
                    Dcargos funcion = new Dcargos();
                    param.Cargo = txtAddCargo.Text;
                    param.SueldoPorHora = Convert.ToDouble(txtAddSueldoHora.Text);
                    if (funcion.InsertarCargo(param) == true)
                    {
                        Buscar_Cargos();
                    }
                }
            }
        }

        private void Buscar_Cargos()
        {
            DataTable dt = new DataTable();
            Dcargos funcion = new Dcargos();
            funcion.BuscarCargo(ref dt, txtCargo.Text);
            dataGridCargos.DataSource = dt;
            Bases.DisenoDtv(ref dataGridCargos);
        }

        
        private void btnAgregarCargo_Click(object sender, EventArgs e)
        {
            PanelCargos.Visible = true;
            PanelCargos.Dock = DockStyle.Fill;
            PanelCargos.BringToFront();
            btnGuardarCrg.Visible = true;
            btnGuardarCambiosCrg.Visible = false;
            txtAddCargo.Clear();
            txtAddSueldoHora.Clear();
        }

        private void btnGuardarCrg_Click(object sender, EventArgs e)
        {
            Insertar_Cargos();
        }



        private void txtCargo_TextChanged(object sender, EventArgs e)
        {
            Buscar_Cargos();
        }

        private void btnGuardarPersonal_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
