using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_SIM_V2
{
    internal class Exportador
    {
        public void Exportar(float[] datos, string rutaArchivo, string nombreArchivo)
        {
            string filePath = Path.Combine(rutaArchivo, nombreArchivo);

            try
            {
                // Abre el archivo para escribir en la ruta especificada
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Escribe cada elemento del vector en una línea separada
                    foreach (float valor in datos)
                    {
                        writer.WriteLine(valor);
                    }
                }

                Console.WriteLine("Vector exportado correctamente a " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al exportar el vector: " + ex.Message);
            }
        }
    }
}
