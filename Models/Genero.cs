using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MoviesWebApi.Models
{
    public class Genero
    {
        [Key]
        public int id_genero { get; set; }
        public string nombre { get; set; }

        public List<Pelicula> Peliculas { get; set; }
    }
}
