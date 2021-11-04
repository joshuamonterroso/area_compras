using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVcompras
{
    public partial class frmProveedores : Form
    {

        public frmProveedores()
        {   //Obteniendo los datos de los TextBox      
            InitializeComponent();
            TextBox[] alias = navegador1.funAsignandoTexts(this);
            navegador1.funAsignarAliasVista(alias, "proveedor", "hotelsancarlos");
            //Arreglo con los textbox, nombre tabla, nombre base de datos
            navegador1.funAsignarSalidadVista(this);
            //Inicio de elementos para dar de baja
            navegador1.campoEstado = "stsproveedor";
            //Aqui indicaremos que campo utilizaremos como estado
            //INICIO ID APLICACION USADA PARA REPORTES Y AYUDAS
            navegador1.idAplicacion = "1";
            //Inicio de elementos para ejecutar la ayuda
            navegador1.tablaAyuda = "Aplicacion";
            navegador1.campoAyuda = "pkId";
            //Fin de elementos para ejecutar la ayuda
            //Inicio datos para ejecutar un reporte
            navegador1.funReportesVista("ruta", "idAplicacion", "Reporte");
            //Final datos para ejecutar reportes
            //Pasamos la referencia a la DAtaGridView
            navegador1.pideGrid(dataGridView1);
            //Indicamos que queremos que el datagrid empiece con datos
            navegador1.llenaTabla();
            navegador1.pedirRef(this);
            //llenado de combobox
            navegador1.funLlenarComboControl(comboBox1, "empresa", "idEmpresa", "nombre", "estatus");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rdbActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbActivo.Checked == true)
            {
                txtestado.Text = "A";
            }   
        }

        private void rdbInactivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbInactivo.Checked == true)
            {
                txtestado.Text = "I";
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            navegador1.funComboTextboxVista(comboBox1, textBox6);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            navegador1.funSeleccionarDTVista(dataGridView1);
        }

        private void txtestado_TextChanged(object sender, EventArgs e)
        {
            navegador1.funSetearRBVista(rdbActivo, rdbInactivo, txtestado);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            navegador1.funTextboxComboVista(comboBox1, textBox6);
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {

        }
    }
}
