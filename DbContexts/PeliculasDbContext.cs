using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Models;

namespace MoviesWebApi.DbContexts
{
    public class PeliculasDbContext : DbContext
    {
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public PeliculasDbContext(DbContextOptions<PeliculasDbContext> options) : base(options)
        {

        }
    }
}
