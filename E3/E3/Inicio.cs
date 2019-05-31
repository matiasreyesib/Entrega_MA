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
            ComboBox comboBox1 = new ComboBox();
            ComboBox comboBox2 = new ComboBox();
            if (comboBox1.SelectedIndex != null && comboBox2.SelectedIndex != null)
            {
                Form1 Form1 = new Form1();
                Form1.FILA = Convert.ToInt32(comboBox1.SelectedItem);
                Form1.COLUMNA = Convert.ToInt32(comboBox2.SelectedItem);
                Form1.Show();

            }
        }
    }
}
