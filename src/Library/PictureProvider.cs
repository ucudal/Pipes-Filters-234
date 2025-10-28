using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;

namespace CompAndDel
{
    /// <summary>
    public class PictureProvider
    {
        /// <summary>
        /// Lee una imagen desde un archivo.
        /// </summary>
        /// <param name="path">El path del archivo desde el cual leer la imagen.</param>
        /// <returns>La imagen leída.</returns>
        public IPicture GetPicture(string path)
        {
            Picture picture = new Picture(1, 1);

            
            using (Image<Rgba32> image = Image.Load<Rgba32>(path))
            {
                picture.Resize(image.Width, image.Height);

                for (int h = 0; h < image.Height; h++)
                {
                    for (int w = 0; w < image.Width; w++)
                    {
                        Rgba32 pixel = image[w, h];
                        picture.SetColor(w, h, System.Drawing.Color.FromArgb(pixel.A, pixel.R, pixel.G, pixel.B));
                    }
                }
            }

            return picture;
        }

        /// <summary>
        /// Guarda una imagen en un archivo.
        /// </summary>
        /// <param name="picture">La imagen a guardar.</param>
        /// <param name="path">El path del archivo donde guardar la imagen.</param>
        public void SavePicture(IPicture picture, string path)
        {
            int width = picture.Width;
            int height = picture.Height;

            // Creamos la imagen en memoria
            using (Image<Rgba32> image = new Image<Rgba32>(width, height))
            {
                for (int h = 0; h < height; h++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        var c = picture.GetColor(w, h);
                        image[w, h] = new Rgba32(c.R, c.G, c.B, c.A);
                    }
                }

                image.Save(path); // Guardamos la imagen en disco
            }
        }
    }
}