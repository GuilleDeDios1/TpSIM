using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;


namespace TpSIM
{
    internal class ChiCuadrado
    {
        private int distribucion;
        private float[] datos;
        private float alfa;
        private int k;
        private int tamañoMuesta;

        public ChiCuadrado(int distribucion, float[] datos, float alfa, int k, int tamañoMuesta)
        {
            this.distribucion = distribucion;
            this.datos = datos;
            this.alfa = alfa;
            this.k = k;
            this.tamañoMuesta = tamañoMuesta;
        }

        public bool calcular() {

            // Calculo de datos necesarios
            float maximo = datos.Max();
            float minimo = datos.Min();

            float rango = maximo - minimo;
            float tamañoIntervalo = rango / k;

            // Crador de matriz.
            float[][] matriz = new float[k][];
           
            for (int i = 0; i < k; i++)
            {
                matriz[i] = new float[5];
            }

            // Llenar tabla. Columnas [desde][hasta][Fo][Pe][Fe(Pe.N)]
            Boolean primeraVez = false; // Bandera para confirmar que paso por matriz[0][0].
            for (int i = 0; i < matriz.Length; i++) // recorre filas
            {
                for (int j = 0; j < matriz[i].Length; j++) // recorre columnas
                {
                    // Consulta que sea desde y que ya paso por [0][0] y lo llena con el valor hasta de la fila anterior.
                    if (j == 0 && primeraVez) // j = 0 => desde
                    {
                        matriz[i][j] = matriz[i - 1][1];
                    }
                    // Consulta si es el primer valor y lo setea con el minimo.
                    if (i == 0 && j == 0) // j = 0 => desde
                    {
                        matriz[i][j] = minimo;
                        primeraVez = true;
                    }
                    // Pregunta si es la segunda columna (hasta)
                    if (j == 1) // j = 1 => hasta
                    {
                        matriz[i][j] = (matriz[i][j - 1]) + tamañoIntervalo;
                    }
                    // Pregunta si es la columna (fo) y recorre los datos reguntando si esta en el intervalo.
                    if (j == 2) // j = 2 => Frecuencia Observada (fo).
                    {
                        int fo = 0;
                        for (int d = 0; d < this.datos.Length; d++)
                        {
                            if (datos[d] >= matriz[i][0] && datos[d] < matriz[i][1])
                            {
                                fo++;
                            }
                        }
                        matriz[i][2] = fo;
                    }
                    // Pregunta si es la columna de P()
                    if (j == 3) // j = 3 => Probabilidad Esperada (P()).
                    {
                        if (distribucion == 0)
                        {
                            matriz[i][j] = (1 / k); // Probabilidad de distribucion uniforme.
                        }
                        if (distribucion == 1)
                        {
                            float media = (float)Statistics.Mean(datos); // Calcula la media de los datos.
                            float lambda = 1 / media;
                            matriz[i][j] = (float)(Exponential.CDF(lambda, matriz[i][1]) - Exponential.CDF(lambda, matriz[i][0])); // Probabilidad de distribucion exponencial.
                        }
                        if (distribucion == 2)
                        {
                            float media = (float)Statistics.Mean(datos); // Calcula la media de los datos.
                            float desviacion = (float)Statistics.StandardDeviation(datos); // Calcula la desviacion de los datos.

                            var distribucion = new Normal(media, desviacion); // Creamos una nueva distribucion con la media y la desviacion calculada para poder utilizar las funciones de la libreria.

                            matriz[i][j] = (float)(distribucion.CumulativeDistribution(matriz[i][1]) - distribucion.CumulativeDistribution(matriz[i][0])); // Probabilidad de distribucion normal.
                        }
                    }
                    if (j == 4) // j = 4 => Frecuencia Esperada (fe).
                    {
                        matriz[i][j] = matriz[i][j - 1] * tamañoMuesta; // Calculo de la frecuencia esperada. Probabilidad*tamaño.
                    }
                }
            }
            
            for (int i = 0; i < matriz.Length; i++)
            {
                for(int j = 0; j < matriz[i].Length; j++)
                {
                    Console.WriteLine(matriz[i][j]);
                }
            }

            return true;
        }

    }

}
