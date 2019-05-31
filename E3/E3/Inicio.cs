using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E3
{
    public partial class Inicio : Form
    {
        // public int FILA;
        //public int COLUMNA;

        public Inicio()
        {
            InitializeComponent();
        }

        private void boton_iniciar_Click(object sender, EventArgs e)
        {
            if (comboBox1 != null && comboBox2 != null)
            {
                Form1 Form1 = new Form1();
                Form1.Show();
                this.Hide();

            }
        }

        private void boton_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
