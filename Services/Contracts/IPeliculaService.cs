using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesWebApi.Models;

namespace MoviesWebApi.Services.Contracts
{
    public interface IPeliculaService
    {
        Task<List<Pelicula>> ObtenerTodasPeliculas();
        Task<List<Pelicula>> ObtenerPeliculasPorGenero(int genero);
        Task<Pelicula> ObtenerPorIdPelicula(int idpelicula);
        Task<Pelicula> AgregarPelicula(Pelicula pelicula);
        Task BorrarPelicula(int idpelicula);
        Task<bool> Guardar();
        Task<List<Pelicula>> ObtenerPorDirector(string director);
    }
}