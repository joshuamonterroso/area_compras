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

namespace CVcompras
{
    public partial class frmMarca_linea : Form
    {
        clscontrolador logi = new clscontrolador();
        public frmMarca_linea()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        //Funcionamiento del Formulario de Marca/linea Andrea Guerra 0901-18-858 

        private void button5_Click(object sender, EventArgs e)
        {
            Area_Compras formulario = new Area_Compras();
            formulario.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] valores = { textBox7.Text ,textBox1.Text, textBox2.Text, textBox5.Text }; //valores a ingresar Andrea Guerra 0901-18-858
            if (logi.insertar_marca(valores) == null)
            {
                MessageBox.Show("Error al ingresar");
            }
            else
            {
                //MessageBox.Show("Modificacion exitosa"); 
                MessageBox.Show("Datos modificados a la base de datos", "Modificacion de datos");
                textBox7.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox5.Enabled = false;
                textBox7.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox5.Text = "";


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox7.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox5.Enabled = true;
            textBox7.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] valores = { textBox8.Text ,textBox4.Text, textBox3.Text, textBox6.Text }; //valores a ingresar
            if (logi.insertar_linea(valores) == null)
            {
                MessageBox.Show("Error al ingresar");
            }
            else
            {
                //MessageBox.Show("Modificacion exitosa");
                MessageBox.Show("Datos modificados a la base de datos", "Modificacion de datos");
                textBox8.Enabled = false;
                textBox4.Enabled = false;
                textBox3.Enabled = false;
                textBox6.Enabled = false;
                textBox8.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
                textBox6.Text = "";


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox8.Enabled = true;
            textBox4.Enabled = true;
            textBox3.Enabled = true;
            textBox6.Enabled = true;
            textBox8.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
        }
    }
}
