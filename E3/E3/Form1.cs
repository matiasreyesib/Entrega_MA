using System;
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
        public static int FILA;
        public static int COLUMNA;
        Mapa mapa = new Mapa(8,8);
        public int nada = 0;

        FileStream fotowetar = new FileStream("C:/Users/matia/Desktop/Proyecto_Final/Imagenes/fotowetar.png", FileMode.Open);
        FileStream fotodorvalo = new FileStream("C:/Users/matia/Desktop/Proyecto_Final/Imagenes/fotodorvalo.png", FileMode.Open);
        FileStream fotogofue = new FileStream("C:/Users/matia/Desktop/Proyecto_Final/Imagenes/fotogofue.png", FileMode.Open);
        FileStream fotoent = new FileStream("C:/Users/matia/Desktop/Proyecto_Final/Imagenes/fotoent.png", FileMode.Open);
        FileStream fototaplan = new FileStream("C:/Users/matia/Desktop/Proyecto_Final/Imagenes/fototaplan.png", FileMode.Open);
        FileStream fotodoti = new FileStream("C:/Users/matia/Desktop/Proyecto_Final/Imagenes/fotodoti.png", FileMode.Open);

        FileStream fotoagua = new FileStream("C:/Users/matia/Desktop/Proyecto_Final/Imagenes/fotoagua.jpg", FileMode.Open);
        FileStream fotodesierto = new FileStream("C:/Users/matia/Desktop/Proyecto_Final/Imagenes/fotodesierto.jpg", FileMode.Open);
        FileStream fotonieve = new FileStream("C:/Users/matia/Desktop/Proyecto_Final/Imagenes/fotonieve.jpg", FileMode.Open);
        FileStream fototierra = new FileStream("C:/Users/matia/Desktop/Proyecto_Final/Imagenes/fototierra.png", FileMode.Open);
        FileStream fotolava = new FileStream("C:/Users/matia/Desktop/Proyecto_Final/Imagenes/fotolava.png", FileMode.Open);

        FileStream fotopelea = new FileStream("C:/Users/matia/Desktop/Proyecto_Final/Imagenes/pelea.png", FileMode.Open);

        public Form1()
        {
            InitializeComponent();
            matrizBotones = new Button[mapa.filas_mapa, mapa.columnas_mapa];
            listaBotones = new List<Button>();

            for (int fila = 0; fila < mapa.filas_mapa; fila++)
            {
                for (int columna = 0; columna < mapa.columnas_mapa; columna++)
                {
                    Random random = new Random(); // filas de color completo
                    //int variable;
                    //string nombre_terreno ="0";
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

                    Celda celda = mapa.mapa[fila, columna];
                    Terreno terreno = celda.tipo_terreno;

                    // Terrenos en el mapa
                    Image foto_agua = Image.FromStream(fotoagua);
                    Image foto_desierto = Image.FromStream(fotodesierto);
                    Image foto_nieve = Image.FromStream(fotonieve);
                    Image foto_tierra = Image.FromStream(fototierra);
                    Image foto_lava = Image.FromStream(fotolava);

                    if (terreno.Get_Terreno() == "acuatico")
                    {
                        button.BackColor = Color.Blue;
                        button.BackgroundImage = foto_agua;
                        button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

                    }
                    else if (terreno.Get_Terreno() == "desierto")
                    {
                        button.BackColor = Color.SandyBrown;
                        button.BackgroundImage = foto_desierto;
                        button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    }
                    else if (terreno.Get_Terreno() == "vegetacion")
                    {
                        button.BackColor = Color.GreenYellow;
                        button.BackgroundImage = foto_tierra;
                        button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    }
                    else if (terreno.Get_Terreno() == "nieve")
                    {
                        button.BackColor = Color.White;
                        button.BackgroundImage = foto_nieve;
                        button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    }
                    else if (terreno.Get_Terreno() == "volcan")
                    {
                        button.BackColor = Color.DarkRed;
                        button.BackgroundImage = foto_lava;
                        button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    }
                    else
                    {
                        button.BackColor = Color.Black;
                    }

                    // Bitmons en el mapa
                    Image foto_wetar = Image.FromStream(fotowetar);
                    Image foto_dorvalo = Image.FromStream(fotodorvalo);
                    Image foto_gofue = Image.FromStream(fotogofue);
                    Image foto_ent = Image.FromStream(fotoent);
                    Image foto_doti = Image.FromStream(fotodoti);
                    Image foto_taplan = Image.FromStream(fototaplan);


                    if ((celda.bitmons_celda.Count > 0) && (celda.bitmons_celda.Count < 2))
                    {
                        if (celda.bitmons_celda[0].Get_Especie() == "wetar")
                        {
                            // matrizBotones[fila, columna].BackgroundImage = foto_1;
                            //matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].Text = "wetar";
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = foto_wetar;
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        }
                        else if (celda.bitmons_celda[0].Get_Especie() == "dorvalo")
                        {
                            // matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].Text = "dorvalo";
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = foto_dorvalo;
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        }
                        else if (celda.bitmons_celda[0].Get_Especie() == "doti")
                        {
                            //matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].Text = "doti";
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = foto_doti;
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        }
                        else if (celda.bitmons_celda[0].Get_Especie() == "ent")
                        {
                            // matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].Text = "ent";
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = foto_ent;
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        }
                        else if (celda.bitmons_celda[0].Get_Especie() == "gofue")
                        {
                            // matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].Text = "gofue";
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = foto_gofue;
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        }
                        else if (celda.bitmons_celda[0].Get_Especie() == "taplan")
                        {
                            //matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].Text = "taplan";
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = foto_taplan;
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        }
                        else
                        {
                            nada += 0;
                        }

                    }
                    else if ((celda.bitmons_celda.Count > 1) && (celda.bitmons_celda.Count < 3))
                    {
                        if ((celda.bitmons_celda[0].Get_Especie() == "wetar" && celda.bitmons_celda[1].Get_Especie() == "dorvalo"))
                        {
                            celda.bitmons_celda.RemoveAt(0);
                        }
                        else if ((mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "dorvalo" && mapa.mapa[fila, columna].bitmons_celda[1].Get_Especie() == "wetar"))
                        {
                            celda.bitmons_celda.RemoveAt(1);
                        }
                        else
                        {
                            button.Text = "mas u";
                        }
                        
                    }
                }
            }

        }
































































        private void timer1_Tick(object sender, EventArgs e)
        {
            Image foto_wetar = Image.FromStream(fotowetar);
            Image foto_dorvalo = Image.FromStream(fotodorvalo);
            Image foto_gofue = Image.FromStream(fotogofue);
            Image foto_ent = Image.FromStream(fotoent);
            Image foto_doti = Image.FromStream(fotodoti);
            Image foto_taplan = Image.FromStream(fototaplan);

            Image foto_pelea = Image.FromStream(fotopelea);

            Image foto_agua = Image.FromStream(fotoagua);
            Image foto_desierto = Image.FromStream(fotodesierto);
            Image foto_nieve = Image.FromStream(fotonieve);
            Image foto_tierra = Image.FromStream(fototierra);
            Image foto_lava = Image.FromStream(fotolava);

            for (int fila = 0; fila < mapa.filas_mapa; fila++)
            {
                for (int columna = 0; columna < mapa.columnas_mapa; columna++)
                {
                    List<Bitmon> Borrador_Bitmons_Celda = new List<Bitmon>();

                    if (mapa.mapa[fila, columna].bitmons_celda.Count > 0 && mapa.mapa[fila, columna].bitmons_celda.Count < 2)
                    {
                        ////////////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////////////
                        /// Aca el movimiento del wetar queda resringido solamente a a las celdas contiguas que tienen agua
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
                                    matrizBotones[fila, columna].BackgroundImage = foto_agua;
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
                                matrizBotones[posx, posy].BackgroundImage = foto_wetar;
                                matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
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
                            // matrizBotones[fila, columna].Text = "";
                            matrizBotones[fila, columna].BackgroundImage = null;
                            // Esto se utiliza para dejar la imagen del terreno que estaba antes de que se moviera el bitmon de ese lugar
                            if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_agua;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_desierto;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_nieve;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_tierra;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "volcan")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_lava;
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
                            matrizBotones[posx, posy].BackgroundImage = foto_dorvalo;
                            matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            Borrador_Bitmons_Celda.RemoveAt(0);
                            // matrizBotones[posx, posy].Text = "dorvalo";
                        }
                        ////////////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////////////
                        else if (mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "doti")
                        {
                            Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                            //matrizBotones[fila, columna].Text = "";
                            matrizBotones[fila, columna].BackgroundImage = null;
                            // Esto se utiliza para dejar la imagen del terreno que estaba antes de que se moviera el bitmon de ese lugar
                            if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_agua;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_desierto;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_nieve;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_tierra;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "volcan")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_lava;
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
                            matrizBotones[posx, posy].BackgroundImage = foto_doti;
                            matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            Borrador_Bitmons_Celda.RemoveAt(0);
                            // matrizBotones[posx, posy].Text = "doti";
                        }
                        ////////////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////////////
                        else if (mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "ent")
                        {
                            Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                            // matrizBotones[fila, columna].Text = "";
                            matrizBotones[fila, columna].BackgroundImage = null;
                            // Como los Ents no son capaces de moverse, no nos preocupamos de hacer lo hicimos antes
                            mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                            Borrador_Bitmons_Celda[0].Moverse(mapa);
                            int posx = Borrador_Bitmons_Celda[0].Get_Posx();
                            int posy = Borrador_Bitmons_Celda[0].Get_Posy();
                            mapa.mapa[posx, posy].AgregarBitmon(Borrador_Bitmons_Celda[0]);
                            matrizBotones[posx, posy].BackgroundImage = foto_ent;
                            matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            Borrador_Bitmons_Celda.RemoveAt(0);
                            //matrizBotones[posx, posy].Text = "ent";
                        }
                        ////////////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////////////
                        else if (mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "gofue")
                        {
                            Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                            // matrizBotones[fila, columna].Text = "";
                            matrizBotones[fila, columna].BackgroundImage = null;
                            // Esto se utiliza para dejar la imagen del terreno que estaba antes de que se moviera el bitmon de ese lugar
                            // Ademas aca se cambia de terreno, si es vegetacion a desertico y si es nieve a agua
                            if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_agua;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_desierto;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
                            {
                                mapa.mapa[fila, columna].tipo_terreno = mapa.mapa[fila, columna].bitmons_celda[0].CambioTerreno(2);
                                matrizBotones[fila, columna].BackColor = Color.Blue;
                                matrizBotones[fila, columna].BackgroundImage = foto_agua;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
                            {
                                mapa.mapa[fila, columna].tipo_terreno = mapa.mapa[fila, columna].bitmons_celda[0].CambioTerreno(1);
                                matrizBotones[fila, columna].BackColor = Color.SandyBrown;
                                matrizBotones[fila, columna].BackgroundImage = foto_desierto;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "volcan")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_lava;
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
                            matrizBotones[posx, posy].BackgroundImage = foto_gofue;
                            matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            Borrador_Bitmons_Celda.RemoveAt(0);
                            // matrizBotones[posx, posy].Text = "gofue";
                        }
                        ////////////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////////////
                        else if (mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "taplan")
                        {
                            Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                            // matrizBotones[fila, columna].Text = "";
                            matrizBotones[fila, columna].BackgroundImage = null;
                            // Esto se utiliza para dejar la imagen del terreno que estaba antes de que se moviera el bitmon de ese lugar
                            // Ademas aca se cambia de terreno, se ies desertico a vegetacion
                            if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_agua;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
                            {
                                mapa.mapa[fila, columna].tipo_terreno = mapa.mapa[fila, columna].bitmons_celda[0].CambioTerreno(1);
                                matrizBotones[fila, columna].BackColor = Color.GreenYellow;
                                matrizBotones[fila, columna].BackgroundImage = foto_tierra;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_nieve;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_tierra;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "volcan")
                            {
                                matrizBotones[fila, columna].BackgroundImage = foto_lava;
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
                            matrizBotones[posx, posy].BackgroundImage = foto_taplan;
                            matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            Borrador_Bitmons_Celda.RemoveAt(0);
                            //matrizBotones[posx, posy].Text = "taplan";
                        }
                        else
                        {
                            nada += 0;
                        }




                        /*
                         * borrador_bit_mov[0].Moverse();
                                    int posx = borrador_bit_mov[0].Get_Posx();
                                    int posy = borrador_bit_mov[0].Get_Posy();
                                    mapa.mapa[posx, posy].AgregarBitmon(borrador_bit_mov[0]);
                                    matrizBotones[fila, columna].Text = "wetar";
                                    borrador_bit_mov.RemoveAt(0);
                         */


                    }

                    else if (mapa.mapa[fila, columna].bitmons_celda.Count > 1)
                    {
                        if ((mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "wetar" && mapa.mapa[fila, columna].bitmons_celda[1].Get_Especie() == "dorvalo") || (mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "dorvalo" && mapa.mapa[fila, columna].bitmons_celda[1].Get_Especie() == "wetar"))
                        {
                            matrizBotones[fila, columna].BackgroundImage = foto_pelea;
                            matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            //matrizBotones[fila, columna].Text = "BUM";
                            mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                            matrizBotones[fila, columna].BackgroundImage = null;

                        }
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void boton_reiniciar_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void boton_mostrar_bitmons_Click(object sender, EventArgs e)
        {

        }

        private void boton_salir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hasta luego!");
            Application.Exit();
        }
    }
}
