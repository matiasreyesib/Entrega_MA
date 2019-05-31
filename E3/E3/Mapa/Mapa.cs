﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3
{
    class Mapa
    {
        public int filas_mapa;
        public int columnas_mapa;
        public Celda[,] mapa;
        public List<Bitmon> bitmons_mapa = new List<Bitmon>();
        Random random = new Random();
        Random rnd_creabit = new Random();
        public int n_taplan=0;
        public int n_wetar=0;
        public int n_gofue=0;
        public int n_dorvalo=0;
        public int n_doti=0;
        public int n_ent=0;

        public Mapa(int filas_mapa, int columnas_mapa)
        {
            this.filas_mapa = filas_mapa;
            this.columnas_mapa = columnas_mapa;
            mapa = new Celda[filas_mapa, columnas_mapa];
            CreacionMapa();

            
            // en su constructor hago que se inicie el mapa
            // al iniciarce el mapa se crea un mapa de celdas, las cuales tienen un tipo de terreno asociado
            // hago que se creen los bitmons
        }

        public void CreacionMapa()
        {
            for (int fila = 0; fila < filas_mapa; fila++)
            {
                for (int columna = 0; columna < columnas_mapa; columna++)
                {
                    int al = random.Next(0, 5);
                    mapa[fila, columna] = new Celda(al);
                    // lo hice para que me de el tipo de terreno de esa celda
                    // mapa[fila, columna].tipo_terreno.Get_Terreno();

                }
            }
            CrearBitmon();
        }

        public void CrearBitmon()
        {
            int contador = 0;

            while (contador < 4)
            {
                int fila = random.Next(filas_mapa);
                int columna = random.Next(columnas_mapa);
                int al_bit = random.Next(6);
                int tiempoDeVida = random.Next(1,10);

                if (al_bit == 0)
                {
                    if (mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                    {
                        Wetar bitmon = new Wetar(fila, columna, tiempoDeVida);
                        mapa[fila, columna].AgregarBitmon(bitmon);
                        contador += 1;
                        n_wetar += 1;
                    }
                    else
                    {
                        contador += 0;
                    }

                }
                else if (al_bit == 1)
                {
                    Dorvalo bitmon = new Dorvalo(fila, columna, tiempoDeVida);
                    mapa[fila, columna].AgregarBitmon(bitmon);
                    contador +=1;
                }
                else if (al_bit == 2)
                {
                    Doti bitmon = new Doti(fila, columna, tiempoDeVida);
                    mapa[fila, columna].AgregarBitmon(bitmon);
                    contador += 1;
                }
                else if (al_bit == 3)
                {
                    if (mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
                    {
                        Ent bitmon = new Ent(fila, columna, tiempoDeVida);
                        mapa[fila, columna].AgregarBitmon(bitmon);
                        contador += 1;
                        n_ent += 1;
                    }
                    else if (mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
                    {
                        Ent bitmon = new Ent(fila, columna, tiempoDeVida);
                        mapa[fila, columna].AgregarBitmon(bitmon);
                        contador += 1;
                        n_ent += 1;
                    }
                    else if (mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
                    {
                        Ent bitmon = new Ent(fila, columna, tiempoDeVida);
                        mapa[fila, columna].AgregarBitmon(bitmon);
                        contador += 1;
                        n_ent += 1;
                    }
                    else
                    {
                        contador += 0;
                    }
                    
                }
                else if (al_bit == 4)
                {
                    Gofue bitmon = new Gofue(fila, columna, tiempoDeVida);
                    mapa[fila, columna].AgregarBitmon(bitmon);
                    contador += 1;
                }
                else if (al_bit == 5)
                {
                    Taplan bitmon = new Taplan(fila, columna, tiempoDeVida);
                    mapa[fila, columna].AgregarBitmon(bitmon);
                    contador += 1;
                }
                else
                {
                    contador += 0;
                }
            }

        }
    }
}
