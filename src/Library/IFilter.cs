using System;

namespace CompAndDel
{
    /// <summary>
    /// </remarks>
    public interface IFilter
    {
        /// <summary>
        /// Procesa la imagen pasada por parametro y retorna la misma imagen o una nueva.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La misma imagen o una nueva imagen creada por el filtro.</returns>
        IPicture Filter(IPicture image);
    }
}