using System;
using CompAndDel;                
using CompAndDel.Filters;        
using CompAndDel.Pipes;          

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cargar la imagen original
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"C:\repos\PII_Pipes_Filters\luke.jpg"); 

            // Crear los filtros
            IFilter filter1 = new FilterNegative();   // Filtro negativo
            IFilter filter2 = new FilterGreyscale();  // Filtro escala de grises

            // Crear filtros de guardado para los pasos intermedios
            IFilter saveStep1 = new FilterSave(@"C:\repos\PII_Pipes_Filters\paso1.jpg"); // Guarda después de filtro1
            IFilter saveStep2 = new FilterSave(@"C:\repos\PII_Pipes_Filters\paso2.jpg"); // Guarda después de filtro2

            //  pipes en orden inverso
            IPipe pipeNull = new PipeNull();                       // Último pipe
            IPipe pipe2 = new PipeSerial(filter2, pipeNull);       // Segundo filtro
            IPipe pipeSave2 = new PipeSerial(saveStep2, pipe2);    // Guarda después del segundo filtro
            IPipe pipe1 = new PipeSerial(filter1, pipeSave2);      // Primer filtro
            IPipe pipeSave1 = new PipeSerial(saveStep1, pipe1);    // Guarda después del primer filtro

          
            IPicture result = pipeSave1.Send(picture);

            
            provider.SavePicture(result, @"C:\repos\PII_Pipes_Filters\resultado_final.jpg");

            Console.WriteLine("Procesamiento completado. Se guardaron los pasos intermedios y el resultado final.");
        }
    }
}