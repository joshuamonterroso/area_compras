using ControladorReporteador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms.ComponentModel;

namespace VistaReporteador
{
    public partial class Reporteador : Form
    {
        public Reporteador()
        {
            InitializeComponent();
            dataGrid();            
            actualizardatagriew();
            cbxIdAplic.Enabled = false;
            cbxAplicacion.Enabled = false;
            llenarcbxAplicacion();
        }
                
        ControladorQ sn = new ControladorQ();

        String tabla = "reportes";
        //Francisco 0901-17-16694
        public void actualizardatagriew()//Funcion de actualizar 
        {
            DataTable dt = sn.llenarTbl(tabla);
            dataGridView1.DataSource = dt;
        }

        //Angel Chacón 9959-18-5201 
        //funcion para mostrar id en el combobox de las apliaciones existentes
        public void llenarcbxIdAplic()
        {
            try
            {
                cbxIdAplic.Items.Clear();
                OdbcDataReader datareader = sn.IdAplici(cbxAplicacion.Text);
                while (datareader.Read())
                {
                    cbxIdAplic.Items.Add(datareader[0].ToString());
                }
                cbxIdAplic.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }
    
        //Angel Chacón 9959-18-5201 
        //funcion para mostrar los nombres en el combobox de las apliaciones existentes
        public void llenarcbxAplicacion()
        {
            try
            {
                cbxAplicacion.Items.Clear();
                OdbcDataReader datareader = sn.llenarcbxAplic();
                while (datareader.Read())
                {
                    cbxAplicacion.Items.Add(datareader[0].ToString());
                }
                cbxAplicacion.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        //Carol Monterroso 0901-17-5961
        //Funciones
        public void activarTextBox()
        {
            textBoxID.Enabled = true;
            textBoxNombre.Enabled = true;
            textBoxRuta.Enabled = true;
            cbxIdAplic.Enabled = true;
            cbxAplicacion.Enabled = true;
        }
        //Carol Monterroso 0901-17-5961
        public void desactivarTextBox()
        {
            textBoxID.Enabled = false;
            textBoxNombre.Enabled = false;
            textBoxRuta.Enabled = false;
            cbxIdAplic.Enabled = false;
            cbxAplicacion.Enabled = false;          
        }
        //Carol Monterroso 0901-17-5961
        public void cleanTextBox()
        {
            textBoxID.Text = "";
            textBoxNombre.Text = "";
            textBoxRuta.Text = "";
            txtEstado.Text = "";
            cbxIdAplic.Text = "";
            cbxAplicacion.Text = "";
        }
        //Carol Monterroso 0901-17-5961
        public void dataGrid()
        {
            ControladorQ c = new ControladorQ();
            c.data(Convert.ToString(dataGridView1.DataSource));           
        }

        //Angel Chacón 9959-18-5201 
        //llamada a la funcion para modificar datos en la tabla de roportes
        private void button1_Click(object sender, EventArgs e)
        {
            ControladorQ cq = new ControladorQ();
            cq.Actualizar(textBoxNombre.Text, textBoxRuta.Text, cbxIdAplic.Text, txtEstado.Text, textBoxID.Text);            
            cleanTextBox();
            desactivarTextBox();
            dataGrid();
        }

        //Carol Monterroso 0901-17-5961
        private void button2_Click(object sender, EventArgs e)
        {
            ControladorQ cq = new ControladorQ();
            cq.Actualizar(textBoxNombre.Text, textBoxRuta.Text, cbxIdAplic.Text, txtEstado.Text, textBoxID.Text);
            cleanTextBox();
            desactivarTextBox();
            dataGrid();
        }
        //Carol Monterroso 0901-17-5961
        private void button3_Click(object sender, EventArgs e)
        {
            activarTextBox();
        }

        // Luis Reyes 0901-15-3121
        private void button4_Click(object sender, EventArgs e)
        {          
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxRuta.Text = openFileDialog.FileName;
            }            
        }
        //Francisco 0901-17-16694
        private void button5_Click(object sender, EventArgs e)//Llama y actualiza datagrid
        {
            actualizardatagriew();
        }

        //Francisco 0901-17-16694
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)// Muestra los datos en los texbox al seleccionarlos en el data grid por medio del evento mouse
        {
            textBoxID.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();            
            textBoxNombre.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxRuta.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbxIdAplic.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtEstado.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();            
        }

        //Angel Chacón 9959-18-5201 
        //obtenicion de valor para el estado al seleccionar el radio button de activo
        private void rbVisible_CheckedChanged(object sender, EventArgs e)
        {
            String est;
            if (rbVisible.Checked)
            {
                est = "1";
                txtEstado.Text = est;
            }            
        }

        //Angel Chacón 9959-18-5201 
        //obtenicion de valor para el estado al seleccionar el radio button de inactivo
        private void rbNovisible_CheckedChanged(object sender, EventArgs e)
        {
            String est;
            if (rbNovisible.Checked)
            {
                est = "0";
                txtEstado.Text = est;
            }
        }

        //Angel Chacón 9959-18-5201 
        //Funcion para visalizar los reportes asociados a los modulos de trabajo
        public void abrir_Click(object sender, EventArgs e)
        {
            int est;
            est = int.Parse(txtEstado.Text);
            if (est == 1)
            {
                string r = textBoxRuta.Text;
                frmReporteAdm b = new frmReporteAdm(r);
                b.Show();
            }
            else
            {
                MessageBox.Show("Reporte Desabilitado");
            }
        }

      
        public void textBoxRuta_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtIDRep_TextChanged(object sender, EventArgs e)
        {           
                        
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Angel Chacón 9959-18-5201 
        //obtencion de datos de la funcion de controlador
        private void cbxAplicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarcbxIdAplic();
        }

        // Angel Chacón 9959-18-5201
        //llamada a la funcion de controlador para guardar reporte
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ControladorQ cq = new ControladorQ();
            cq.GuardarD(textBoxID.Text,textBoxNombre.Text, textBoxRuta.Text, cbxIdAplic.Text, txtEstado.Text);
            cleanTextBox();
            desactivarTextBox();
            dataGrid();
        }

        private void cbxIdAplic_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
