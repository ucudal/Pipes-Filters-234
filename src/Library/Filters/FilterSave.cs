using System;

namespace CompAndDel.Filters
{
    public class FilterSave : IFilter
    {
        private readonly string path;
        private readonly PictureProvider provider = new PictureProvider();

        public FilterSave(string path)
        {
            this.path = path;
        }

        public IPicture Filter(IPicture image)
        {
            provider.SavePicture(image, path);
            Console.WriteLine($" Imagen guardada en: {path}");
            return image; // devuelve la misma imagen para que continúe la secuencia
        }
    }
}