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
    public class GeneroService : IGeneroService
    {
        private readonly PeliculasDbContext _context;

        public GeneroService(PeliculasDbContext context)
        {
            _context = context;
        }

        public async Task<List<Genero>> ObtenerTodosGeneros()
        {
            try
            {
                var query = await _context.Generos.ToListAsync();
                return query;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Genero> ObtenerGeneroId(int id)
        {
            try
            {
                var query = await _context.Generos.Where(x => x.id_genero == id).FirstOrDefaultAsync();
                return query;
            }
            catch
            {
                throw;
            }
        }
    }
}
