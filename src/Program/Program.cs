using System;
using CompAndDel;                // Contiene las interfaces y clases base (IPipe, IFilter, etc.)
using CompAndDel.Filters;        // Contiene los filtros como FilterNegative, FilterGreyscale, etc.
using CompAndDel.Pipes;          // Contiene los pipes como PipeSerial, PipeNull


namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cargar imagen
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"C:\repos\PII_Pipes_Filters\luke.jpg"); // Cambiá el path a tu imagen

            // 2️ Crear los filtros que querés aplicar
            IFilter filter1 = new FilterNegative();  // Filtro negativo
            IFilter filter2 = new FilterGreyscale(); // Filtro escala de grises

            // Crear los pipes en orden inverso
            IPipe pipeNull = new PipeNull();                     // Último pipe que no hace nada
            IPipe pipe2 = new PipeSerial(filter2, pipeNull);     // Segundo tramo
            IPipe pipe1 = new PipeSerial(filter1, pipe2);        // Primer tramo

            // Ejecutar la secuencia de Pipes & Filters
            IPicture result = pipe1.Send(picture);

            // Guardar el resultado final
            provider.SavePicture(result, @"C:\repos\PII_Pipes_Filters\resultado.jpg");

            Console.WriteLine("Imagen procesada y guardada correctamente.");
        }
    }
}