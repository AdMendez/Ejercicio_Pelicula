using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MoviesWebApi.Models
{
    public class Pelicula
    {
        [Key]
        public int id_pelicula { get; set; }
        public string titulo { get; set; }
        public string director { get; set; }
        public int id_genero { get; set; }
        public int puntuacion { get; set; }
        public int rating { get; set; }
        public int anio_publicacion { get; set; }

        public Genero Genero { get; set; }
    }
}
