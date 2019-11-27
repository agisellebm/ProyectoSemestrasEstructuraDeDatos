using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Series : Datos
    {
        public Series (string titulo, string genero, string sinopsis, string director, int año, int temporadas, int calificacion)
        {
            Titulo = titulo;
            Genero = genero;
            Sinopsis = sinopsis;
            Director = director;
            Año = año;
            Temporadas = Temporadas;
            Calificacion = calificacion;
        }

    }
}
