using MoviesWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi.Services.Contracts
{
    public interface IGeneroService
    {
        Task<List<Genero>> ObtenerTodosGeneros();
        Task<Genero> ObtenerGeneroId(int id);
    }
}
