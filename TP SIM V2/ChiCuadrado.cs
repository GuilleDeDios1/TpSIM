using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;
using System.Diagnostics.Contracts;
using System.Windows.Forms;
using TP_SIM_V2.Grafico;

namespace TP_SIM_V2
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

        private float[][] armarTablaDeFrecuencia()
        {

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

            // Llenar tabla de frecuencias. Columnas [desde][hasta][Fo][Pe][Fe(Pe.N)]
            Boolean primeraVez = false; // Bandera para confirmar que paso por matriz[0][0].
            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    // Consulta que sea columna desde y que ya paso por [0][0] y lo llena con el valor hasta de la fila anterior.
                    if (j == 0 && primeraVez)
                    {
                        matriz[i][j] = matriz[i - 1][1];
                    }
                    // Consulta si es el primer valor y lo setea con el minimo.
                    if (i == 0 && j == 0)
                    {
                        matriz[i][j] = minimo;
                        primeraVez = true;
                    }
                    if (j == 1) // j = 1 => hasta
                    {
                        matriz[i][j] = (matriz[i][j - 1]) + tamañoIntervalo;
                    }
                    // Pregunta si es la columna (fo) y recorre los datos preguntando si esta en el intervalo.
                    if (j == 2)
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
                    if (j == 3) // j = 3 => Probabilidad Esperada (P()).
                    {
                        if (distribucion == 0)  // Probabilidad de distribucion uniforme.
                        {
                            matriz[i][j] = (1f / k);
                        }
                        if (distribucion == 1) // Probabilidad de distribucion exponencial.
                        {
                            float media = (float)Statistics.Mean(datos);
                            float lambda = 1f / media;
                            matriz[i][j] = (float)(Exponential.CDF(lambda, matriz[i][1]) - Exponential.CDF(lambda, matriz[i][0])); // por probabilidades acumuladas.
                        }
                        if (distribucion == 2) // Probabilidad de distribucion normal.
                        {
                            float media = (float)Statistics.Mean(datos); 
                            float desviacion = (float)Statistics.StandardDeviation(datos);

                            var distribucion = new Normal(media, desviacion); // Creamos una nueva distribucion con la media y la desviacion calculada para poder utilizar las funciones de la libreria.

                            matriz[i][j] = (float)(distribucion.CumulativeDistribution(matriz[i][1]) - distribucion.CumulativeDistribution(matriz[i][0])); // por probabilidades acumuladas.
                        }
                    }
                    if (j == 4) // j = 4 => Frecuencia Esperada (fe).
                    {
                        matriz[i][j] = matriz[i][j - 1] * tamañoMuesta; // Calculo de la frecuencia esperada. Probabilidad*tamaño.
                    }
                }
            }
            return matriz;
        }

        public void calcularChi()
        {
            float[][] matriz = armarTablaDeFrecuencia();
            List<List<float>> agrupada = new List<List<float>>();
            List<float> lineaAcumulada = new List<float>();
            Boolean estaSumando = false;
            List<float> lineaActual = new List<float>();
            float desde = 0;
            float hasta = 0;

            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    //recolecta los elementos de la fila completa
                    if (j != 4)
                    {
                        lineaActual.Add(matriz[i][j]);
                        continue;
                    }
                    lineaActual.Add(matriz[i][j]);
                    //pregunta si la columna 4(frecuencia esperada) es mayor o igual a 5 y si el vector no esta sumando.
                    if (lineaActual[j] >= 5 && !estaSumando)
                    {
                        //calculamos el estadistico
                        float estadistico = (float)Math.Pow((lineaActual[2] - lineaActual[4]), 2) / lineaActual[4];
                        lineaActual.Add(estadistico);

                        //metemos la linea actual en la matiz acumulada
                        agrupada.Add(lineaActual);
                        lineaActual = new List<float>();
                    }
                    //entra si la frecuencia esperada es menor a 5 o si el vector esta sumando
                    else
                    {
                        //entra si no tiene linea anterior sumando para guardar linea acumulada y empezar a sumar
                        if (lineaAcumulada.Count == 0)
                        {
                            lineaAcumulada = lineaActual;
                            lineaActual = new List<float>();
                            estaSumando = true;
                            desde = lineaAcumulada[0];
                        }
                        //entra si tiene lineaAntrior
                        else
                        {
                            //Suma las dos lineas completas y pregunta si la suma es mayor o igual a 5, si lo es lo guarda en acumulada y setea los valores a 0
                            lineaAcumulada = lineaAcumulada.Zip(lineaActual, (x, y) => x + y).ToList();
                            if (lineaAcumulada[j] >= 5)
                            {
                                //setea el desde y hasta
                                lineaAcumulada[1] = matriz[i][1];
                                lineaAcumulada[0] = desde;

                                //Calculamos el estadistico
                                float estadistico = (float)Math.Pow((lineaAcumulada[2] - lineaAcumulada[4]), 2) / lineaAcumulada[4];
                                lineaAcumulada.Add(estadistico);
                                //agrega la linea acumulada a la matriz de acumulacion
                                agrupada.Add(lineaAcumulada);

                                estaSumando = false;
                                lineaAcumulada = new List<float>();
                                lineaActual = new List<float>();
                            }
                            lineaActual = new List<float>();
                        }
                    }
                }
                hasta = matriz[i][1];
            }
            //pregunta si el vector de acumulacion quedo con valores y lo suma a la ultima linea de la matriz acumulada
            if (lineaAcumulada.Count != 0)
            {

                int indiceUltimaFila = agrupada.Count - 1;
                desde = agrupada[indiceUltimaFila][0];

                agrupada[indiceUltimaFila] = agrupada[indiceUltimaFila].Zip(lineaAcumulada, (x, y) => x + y).ToList();

                float estadistico = (float)Math.Pow((agrupada[indiceUltimaFila][2] - agrupada[indiceUltimaFila][4]), 2) / agrupada[indiceUltimaFila][4];
                agrupada[indiceUltimaFila].Add(estadistico);

                //seteamos el desde y hasta
                agrupada[indiceUltimaFila][0] = desde;
                agrupada[indiceUltimaFila][1] = hasta;
            }

            //calcular chi
            float count = 0;
            double gradosLibertad = 0;

            for (int i = 0; i < agrupada.Count; i++) // suma de estadisticos. chi calculado.
            {
                count += agrupada[i][5]; 
            }

            if (distribucion == 0) { gradosLibertad = k - 1; }
            if (distribucion == 1) { gradosLibertad = k - 1 - 1; }
            if (distribucion == 2) { gradosLibertad = k - 1 - 2; }

            double valorCritico = ChiSquared.InvCDF(gradosLibertad, 1 - alfa);

            if (count < valorCritico) // Si chi calculado es menor al chi tabulado
            {
                graficar(matriz,agrupada,count,(float)valorCritico);
            }
            else
            {
                MessageBox.Show("Chi Calculado = " + count.ToString() + "\nChi Tabulado = " + valorCritico.ToString(), "Chi calculado > Chi Tabulado");
            }
        }

        private void graficar(float[][] matriz,List<List<float>> agrupada, float count, float valorCritico)
        {
            FrmHistograma histo = new FrmHistograma(matriz, agrupada, count, valorCritico);
            histo.ShowDialog();
        }
    }
}

