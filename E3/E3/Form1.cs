﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace E3
{
    public partial class Form1 : Form
    {
        List<Button> listaBotones;
        Button[,] matrizBotones;
        public static int Fila;
        public static int Columna;
        public int nada = 0;
        public static int meses;
        int contador = 0;

        public Form1(int Fila1, int Columna1, int meses1)
        {
            Mapa mapa = new Mapa(Fila1, Columna1);
            Fila = Fila1;
            Columna = Columna1;
            meses = meses1;
            
            InitializeComponent();
            tableLayoutPanel1.Hide();
            matrizBotones = new Button[mapa.filas_mapa, mapa.columnas_mapa];
            listaBotones = new List<Button>();

            for (int fila = 0; fila < mapa.filas_mapa; fila++)
            {
                for (int columna = 0; columna < mapa.columnas_mapa; columna++)
                {
                    Random random = new Random(); 
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0, 0, 0, 0);
                    button.Padding = new Padding(0, 0, 0, 0);
                    button.FlatStyle = FlatStyle.Popup;
                    button.FlatAppearance.BorderSize = 0;
                    button.Enabled = false;
                    tableLayoutPanel1.Controls.Add(button, columna, fila);
                    matrizBotones[fila, columna] = button;
                    listaBotones.Add(button);

                    
                }
            }
        }



        /*
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */

        

        // El tiempo del timer medira los meses de vida.
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void boton_reiniciar_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        

        private void boton_salir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hasta luego!");
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mapa mapa = new Mapa(Fila, Columna);

            for (int i = 0; i < meses; i++)
            {
                contador++;

                tableLayoutPanel1.Show();
                tableLayoutPanel1.Refresh();
                // Recorremos cada celda para lograr el movimiento del bitmon, su reproduccion, las peleas, etc.
                for (int fila = 0; fila < mapa.filas_mapa; fila++)
                {
                    for (int columna = 0; columna < mapa.columnas_mapa; columna++)
                    {

                        Celda celda = mapa.mapa[fila, columna];
                        Terreno terreno = celda.tipo_terreno;
                        cant_taplan.Text = Convert.ToString(mapa.n_taplan);

                        // Terrenos en el mapa
                        if (terreno.Get_Terreno() == "acuatico")
                        {
                            matrizBotones[fila, columna].BackColor = Color.Blue;
                            matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotoagua;
                            matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

                        }
                        else if (terreno.Get_Terreno() == "desierto")
                        {
                            matrizBotones[fila, columna].BackColor = Color.SandyBrown;
                            matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotodesierto;
                            matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        }
                        else if (terreno.Get_Terreno() == "vegetacion")
                        {
                            matrizBotones[fila, columna].BackColor = Color.GreenYellow;
                            matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fototierra;
                            matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        }
                        else if (terreno.Get_Terreno() == "nieve")
                        {
                            matrizBotones[fila, columna].BackColor = Color.White;
                            matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotonieve;
                            matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        }
                        else if (terreno.Get_Terreno() == "volcan")
                        {
                            matrizBotones[fila, columna].BackColor = Color.DarkRed;
                            matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotolava;
                            matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        }
                        else
                        {
                            matrizBotones[fila, columna].BackColor = Color.Black;
                        }

                        // Bitmons en el mapa
                        if ((celda.bitmons_celda.Count > 0) && (celda.bitmons_celda.Count < 2))
                        {
                            if (celda.bitmons_celda[0].Get_Especie() == "wetar")
                            {
                                // matrizBotones[fila, columna].BackgroundImage = foto_1;
                                //matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].Text = "wetar";
                                matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = Properties.Resources.fotowetar;
                                matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            }
                            else if (celda.bitmons_celda[0].Get_Especie() == "dorvalo")
                            {
                                matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = Properties.Resources.fotodorvalo;
                                matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            }
                            else if (celda.bitmons_celda[0].Get_Especie() == "doti")
                            {
                                matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = Properties.Resources.fotodoti;
                                matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            }
                            else if (celda.bitmons_celda[0].Get_Especie() == "ent")
                            {
                                matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = Properties.Resources.fotoent;
                                matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            }
                            else if (celda.bitmons_celda[0].Get_Especie() == "gofue")
                            {
                                matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = Properties.Resources.fotogofue;
                                matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            }
                            else if (celda.bitmons_celda[0].Get_Especie() == "taplan")
                            {
                                matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = Properties.Resources.fototaplan;
                                matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            }
                            else
                            {
                                nada += 0;
                            }
                        }
                        ///////////////////////
                        ///////////////////////
                        ///////////////////////
                        else if ((celda.bitmons_celda.Count > 1) && (celda.bitmons_celda.Count < 3))
                        {
                            if ((celda.bitmons_celda[0].Get_Especie() == "wetar" && celda.bitmons_celda[1].Get_Especie() == "dorvalo"))
                            {
                                if (celda.bitmons_celda[0].Get_Especie() == "taplan")
                                {
                                    mapa.n_taplan -= 1;
                                }
                                else if (celda.bitmons_celda[0].Get_Especie() == "wetar")
                                {
                                    mapa.n_wetar -= 1;
                                }
                                else if (celda.bitmons_celda[0].Get_Especie() == "gofue")
                                {
                                    mapa.n_gofue -= 1;
                                }
                                else if (celda.bitmons_celda[0].Get_Especie() == "dorvalo")
                                {
                                    mapa.n_dorvalo -= 1;
                                }
                                else if (celda.bitmons_celda[0].Get_Especie() == "doti")
                                {
                                    mapa.n_doti -= 1;
                                }
                                else if (celda.bitmons_celda[0].Get_Especie() == "ent")
                                {
                                    mapa.n_ent -= 1;
                                }
                                else
                                {
                                    nada += 0;
                                }
                                celda.bitmons_celda.RemoveAt(0);
                            }
                            else if ((mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "dorvalo" && mapa.mapa[fila, columna].bitmons_celda[1].Get_Especie() == "wetar"))
                            {
                                if (celda.bitmons_celda[1].Get_Especie() == "taplan")
                                {
                                    mapa.n_taplan -= 1;
                                }
                                else if (celda.bitmons_celda[1].Get_Especie() == "wetar")
                                {
                                    mapa.n_wetar -= 1;
                                }
                                else if (celda.bitmons_celda[1].Get_Especie() == "gofue")
                                {
                                    mapa.n_gofue -= 1;
                                }
                                else if (celda.bitmons_celda[1].Get_Especie() == "dorvalo")
                                {
                                    mapa.n_dorvalo -= 1;
                                }
                                else if (celda.bitmons_celda[1].Get_Especie() == "doti")
                                {
                                    mapa.n_doti -= 1;
                                }
                                else if (celda.bitmons_celda[1].Get_Especie() == "ent")
                                {
                                    mapa.n_ent -= 1;
                                }
                                else
                                {
                                    nada += 0;
                                }
                                celda.bitmons_celda.RemoveAt(1);
                            }
                            else
                            {
                                celda.bitmons_celda.RemoveAt(0);
                            }
                        }













                        // Utilizamos el borrador para facilitar la accion de moverse del bitmon
                        List<Bitmon> Borrador_Bitmons_Celda = new List<Bitmon>();


                        // Para cuando hay un Bitmon en la lista de bitmons de la celda
                        if (mapa.mapa[fila, columna].bitmons_celda.Count > 0 && mapa.mapa[fila, columna].bitmons_celda.Count < 2)
                        {
                            ////////////////////////////////////////////////////////////////////////
                            ///////////////////////////////////////////////////////////////////////////
                            /// Aca el movimiento del wetar queda resringido solamente a a las celdas contiguas que tienen Agua
                            if (mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "wetar")
                            {
                                mapa.mapa[fila, columna].bitmons_celda[0].Moverse(mapa);
                                int posx_sig = mapa.mapa[fila, columna].bitmons_celda[0].Get_Posx();
                                int posy_sig = mapa.mapa[fila, columna].bitmons_celda[0].Get_Posy();

                                if (mapa.mapa[posx_sig, posy_sig].tipo_terreno.Get_Terreno() == "acuatico")
                                {
                                    Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                                    // matrizBotones[fila, columna].Text = "";
                                    matrizBotones[fila, columna].BackgroundImage = null;
                                    if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                                    {
                                        matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotoagua; //foto_agua;
                                        matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                    }
                                    else
                                    {
                                        nada += 0;
                                    }
                                    mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                                    /*
                                    Borrador_Bitmons_Celda[0].Moverse(mapa);
                                    int posx = Borrador_Bitmons_Celda[0].Get_Posx();
                                    int posy = Borrador_Bitmons_Celda[0].Get_Posy();
                                    */
                                    mapa.mapa[posx_sig, posy_sig].AgregarBitmon(Borrador_Bitmons_Celda[0]);
                                    matrizBotones[posx_sig, posy_sig].BackgroundImage = Properties.Resources.fotowetar; //foto_wetar;
                                    matrizBotones[posx_sig, posy_sig].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                                    Borrador_Bitmons_Celda.RemoveAt(0);
                                    //matrizBotones[posx, posy].Text = "wetar";
                                }
                                else
                                {
                                    nada += 0;
                                }
                            }
                            ////////////////////////////////////////////////////////////////////////
                            ///////////////////////////////////////////////////////////////////////////
                            else if (mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "dorvalo")
                            {
                                Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                                matrizBotones[fila, columna].BackgroundImage = null;
                                // Esto se utiliza para dejar la imagen del terreno que estaba antes de que se moviera el bitmon de ese lugar
                                if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotoagua; //foto_agua;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotodesierto; //foto_desierto;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotonieve; //foto_nieve;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fototierra; //foto_tierra;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "volcan")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotolava; //foto_lava;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else
                                {
                                    nada += 0;
                                }
                                mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                                Borrador_Bitmons_Celda[0].Moverse(mapa);
                                int posx = Borrador_Bitmons_Celda[0].Get_Posx();
                                int posy = Borrador_Bitmons_Celda[0].Get_Posy();
                                mapa.mapa[posx, posy].AgregarBitmon(Borrador_Bitmons_Celda[0]);
                                matrizBotones[posx, posy].BackgroundImage = Properties.Resources.fotodorvalo;//foto_dorvalo;
                                matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                                Borrador_Bitmons_Celda.RemoveAt(0);
                            }
                            ////////////////////////////////////////////////////////////////////////
                            ///////////////////////////////////////////////////////////////////////////
                            else if (mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "doti")
                            {
                                Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                                matrizBotones[fila, columna].BackgroundImage = null;
                                // Esto se utiliza para dejar la imagen del terreno que estaba antes de que se moviera el bitmon de ese lugar
                                if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotoagua; //foto_agua;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotodesierto; //foto_desierto;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotonieve; //foto_nieve;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fototierra; //foto_tierra;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "volcan")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotolava; //foto_lava;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else
                                {
                                    nada += 0;
                                }
                                mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                                Borrador_Bitmons_Celda[0].Moverse(mapa);
                                int posx = Borrador_Bitmons_Celda[0].Get_Posx();
                                int posy = Borrador_Bitmons_Celda[0].Get_Posy();
                                mapa.mapa[posx, posy].AgregarBitmon(Borrador_Bitmons_Celda[0]);
                                matrizBotones[posx, posy].BackgroundImage = Properties.Resources.fotodoti; //foto_doti;
                                matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                                Borrador_Bitmons_Celda.RemoveAt(0);
                            }
                            ////////////////////////////////////////////////////////////////////////
                            ///////////////////////////////////////////////////////////////////////////
                            else if (mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "ent")
                            {
                                Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                                matrizBotones[fila, columna].BackgroundImage = null;
                                // Como los Ents no son capaces de moverse, no nos preocupamos de hacer lo que hicimos antes
                                mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                                Borrador_Bitmons_Celda[0].Moverse(mapa);
                                int posx = Borrador_Bitmons_Celda[0].Get_Posx();
                                int posy = Borrador_Bitmons_Celda[0].Get_Posy();
                                mapa.mapa[posx, posy].AgregarBitmon(Borrador_Bitmons_Celda[0]);
                                matrizBotones[posx, posy].BackgroundImage = Properties.Resources.fotoent; //foto_ent;
                                matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                                Borrador_Bitmons_Celda.RemoveAt(0);
                            }
                            ////////////////////////////////////////////////////////////////////////
                            ///////////////////////////////////////////////////////////////////////////
                            else if (mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "gofue")
                            {
                                Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                                matrizBotones[fila, columna].BackgroundImage = null;
                                // Esto se utiliza para dejar la imagen del terreno que estaba antes de que se moviera el bitmon de ese lugar
                                // Ademas aca se cambia de terreno, si es vegetacion a desertico y si es nieve a agua
                                if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotoagua; //foto_agua;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotodesierto; //foto_desierto;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
                                {
                                    mapa.mapa[fila, columna].tipo_terreno = mapa.mapa[fila, columna].bitmons_celda[0].CambioTerreno(2);
                                    matrizBotones[fila, columna].BackColor = Color.Blue;
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotoagua; //foto_agua;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
                                {
                                    mapa.mapa[fila, columna].tipo_terreno = mapa.mapa[fila, columna].bitmons_celda[0].CambioTerreno(1);
                                    matrizBotones[fila, columna].BackColor = Color.SandyBrown;
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotodesierto; //foto_desierto;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "volcan")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotolava; //foto_lava;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else
                                {
                                    nada += 0;
                                }
                                mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                                Borrador_Bitmons_Celda[0].Moverse(mapa);
                                int posx = Borrador_Bitmons_Celda[0].Get_Posx();
                                int posy = Borrador_Bitmons_Celda[0].Get_Posy();
                                mapa.mapa[posx, posy].AgregarBitmon(Borrador_Bitmons_Celda[0]);
                                matrizBotones[posx, posy].BackgroundImage = Properties.Resources.fotogofue; //foto_gofue;
                                matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                                Borrador_Bitmons_Celda.RemoveAt(0);
                            }
                            ////////////////////////////////////////////////////////////////////////
                            ///////////////////////////////////////////////////////////////////////////
                            else if (mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "taplan")
                            {
                                Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                                matrizBotones[fila, columna].BackgroundImage = null;
                                // Esto se utiliza para dejar la imagen del terreno que estaba antes de que se moviera el bitmon de ese lugar
                                // Ademas aca se cambia de terreno, se ies desertico a vegetacion
                                if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotoagua; //foto_agua;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
                                {
                                    mapa.mapa[fila, columna].tipo_terreno = mapa.mapa[fila, columna].bitmons_celda[0].CambioTerreno(1);
                                    matrizBotones[fila, columna].BackColor = Color.GreenYellow;
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fototierra; //foto_tierra;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotonieve; //foto_nieve;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fototierra; //foto_tierra;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "volcan")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotolava; //foto_lava;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else
                                {
                                    nada += 0;
                                }
                                mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                                Borrador_Bitmons_Celda[0].Moverse(mapa);
                                int posx = Borrador_Bitmons_Celda[0].Get_Posx();
                                int posy = Borrador_Bitmons_Celda[0].Get_Posy();
                                mapa.mapa[posx, posy].AgregarBitmon(Borrador_Bitmons_Celda[0]);
                                matrizBotones[posx, posy].BackgroundImage = Properties.Resources.fototaplan; //foto_taplan;
                                matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                                Borrador_Bitmons_Celda.RemoveAt(0);
                            }
                            else
                            {
                                nada += 0;
                            }
                        }
                        else if (mapa.mapa[fila, columna].bitmons_celda.Count > 1 && mapa.mapa[fila, columna].bitmons_celda.Count < 2)
                        {
                            if (celda.bitmons_celda[0].Get_Especie() == "taplan")
                            {
                                mapa.n_taplan -= 1;
                            }
                            else if (celda.bitmons_celda[0].Get_Especie() == "wetar")
                            {
                                mapa.n_wetar -= 1;
                            }
                            else if (celda.bitmons_celda[0].Get_Especie() == "gofue")
                            {
                                mapa.n_gofue -= 1;
                            }
                            else if (celda.bitmons_celda[0].Get_Especie() == "dorvalo")
                            {
                                mapa.n_dorvalo -= 1;
                            }
                            else if (celda.bitmons_celda[0].Get_Especie() == "doti")
                            {
                                mapa.n_doti -= 1;
                            }
                            else if (celda.bitmons_celda[0].Get_Especie() == "ent")
                            {
                                mapa.n_ent -= 1;
                            }
                            else
                            {
                                nada += 0;
                            }
                            mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                        }
                        else if (mapa.mapa[fila, columna].bitmons_celda.Count > 2)
                        {
                            if (celda.bitmons_celda[0].Get_Especie() == "taplan")
                            {
                                mapa.n_taplan -= 1;
                            }
                            else if (celda.bitmons_celda[0].Get_Especie() == "wetar")
                            {
                                mapa.n_wetar -= 1;
                            }
                            else if (celda.bitmons_celda[0].Get_Especie() == "gofue")
                            {
                                mapa.n_gofue -= 1;
                            }
                            else if (celda.bitmons_celda[0].Get_Especie() == "dorvalo")
                            {
                                mapa.n_dorvalo -= 1;
                            }
                            else if (celda.bitmons_celda[0].Get_Especie() == "doti")
                            {
                                mapa.n_doti -= 1;
                            }
                            else if (celda.bitmons_celda[0].Get_Especie() == "ent")
                            {
                                mapa.n_ent -= 1;
                            }
                            else
                            {
                                nada += 0;
                            }
                            if (celda.bitmons_celda[1].Get_Especie() == "taplan")
                            {
                                mapa.n_taplan -= 1;
                            }
                            else if (celda.bitmons_celda[1].Get_Especie() == "wetar")
                            {
                                mapa.n_wetar -= 1;
                            }
                            else if (celda.bitmons_celda[1].Get_Especie() == "gofue")
                            {
                                mapa.n_gofue -= 1;
                            }
                            else if (celda.bitmons_celda[1].Get_Especie() == "dorvalo")
                            {
                                mapa.n_dorvalo -= 1;
                            }
                            else if (celda.bitmons_celda[1].Get_Especie() == "doti")
                            {
                                mapa.n_doti -= 1;
                            }
                            else if (celda.bitmons_celda[1].Get_Especie() == "ent")
                            {
                                mapa.n_ent -= 1;
                            }
                            else
                            {
                                nada += 0;
                            }
                            mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                            mapa.mapa[fila, columna].bitmons_celda.RemoveAt(1);
                            mapa.CrearBitmon();
                        }

                        //////////
                        //////////
                        /////////
                        /////////
                        //////
                        ///
                        //

                        else
                        {
                            nada += 0;
                        }
                    }
                }
                int tiempo = 0;
                for (int j = 0; j < 500000000; j++)
                {
                    tiempo++;
                }


            }
            cant_wetar.Text = Convert.ToString(mapa.n_wetar);
            cant_gofue.Text = Convert.ToString(mapa.n_gofue);
            cant_dorvalo.Text = Convert.ToString(mapa.n_dorvalo);
            cant_doti.Text = Convert.ToString(mapa.n_doti);
            cant_ent.Text = Convert.ToString(mapa.n_ent);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
