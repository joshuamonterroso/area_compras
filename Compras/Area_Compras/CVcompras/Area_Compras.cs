using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCcompras;
using System.Data.Odbc;

namespace CVcompras
{
    public partial class Area_Compras : Form
    {
        clscontrolador cn = new clscontrolador();
        public Area_Compras()
        {
            InitializeComponent();
        }

     
        private void Area_Compras_Load(object sender, EventArgs e)
        {

        }

        // Direccionamiento de formularios Andrea Guerra 0901-18-858
        private void ingresarProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedores formulario = new frmProveedores();
            formulario.MdiParent = this;
            formulario.Show();            
        }

        private void ingresarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompra formulario = new frmCompra();
            formulario.MdiParent = this;
            formulario.Show();
        }

        private void gestionarProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionProveedores formulario = new frmGestionProveedores();
            formulario.MdiParent = this;
            formulario.Show();
        }

        private void gestionarComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionCompras formulario = new frmGestionCompras();
            formulario.MdiParent = this;
            formulario.Show();
        }

        private void agregarMarcaLineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarca_linea formulario = new frmMarca_linea();
            formulario.MdiParent = this;
            formulario.Show();
        }

        private void bodegasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBodegas formulario = new frmBodegas();
            formulario.MdiParent = this;
            formulario.Show();
        }
    }
}
