using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesWebApi.DbContexts;
using MoviesWebApi.Models;
using MoviesWebApi.Services.Contracts;
using Microsoft.EntityFrameworkCore;


namespace MoviesWebApi.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly PeliculasDbContext _context;

        public PeliculaService(PeliculasDbContext context)
        {
            _context = context;
        }

        public async Task<Pelicula> AgregarPelicula(Pelicula pelicula)
        {
            try
            {
                await _context.Peliculas.AddAsync(pelicula);
                await _context.SaveChangesAsync();
                return pelicula;

            }
            catch
            {
                throw;
            }
        }

        public async Task BorrarPelicula(int idpelicula)
        {
            try
            {
                var pelicula = await ObtenerPorIdPelicula(idpelicula);

                if (pelicula != null)
                {
                    _context.Peliculas.Remove(pelicula);
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Guardar()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Pelicula>> ObtenerPeliculasPorGenero(int genero)
        {
            try
            {
                var peliculas = await _context.Peliculas.Where(p => p.id_genero == genero).ToListAsync();
                return peliculas;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Pelicula>> ObtenerPorDirector(string director)
        {
            try
            {
                var peliculas = await _context.Peliculas.Where(p => p.director == director).ToListAsync();
                return peliculas;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Pelicula> ObtenerPorIdPelicula(int idpelicula)
        {
            try
            {
                var pelicula = 
                    await _context.Peliculas.Where(p => p.id_pelicula == idpelicula).FirstOrDefaultAsync();
                return pelicula;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Pelicula>> ObtenerTodasPeliculas()
        {
            try
            {
                var peliculas = await _context.Peliculas.ToListAsync();
                return peliculas;
            }
            catch
            {
                throw;
            }
        }
    }
}