using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebApi.Models;
using MoviesWebApi.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _peliculaService;

        public PeliculaController(IPeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }

        [HttpGet]
        [Route("films")]
        public async Task<ActionResult<List<Pelicula>>> ObtenerTodas()
        {
            try
            {
                var query = await _peliculaService.ObtenerTodasPeliculas();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("films/{director}")]
        public async Task<ActionResult<List<Pelicula>>> ObtenerPorDirector(string director)
        {
            try
            {
                var query = await _peliculaService.ObtenerPorDirector(director);
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("gender/{genero:int}")]
        public async Task<ActionResult<List<Pelicula>>> ObtenerPorGenero(int genero)
        {
            try
            {
                var query = await _peliculaService.ObtenerPeliculasPorGenero(genero);
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("films/{id:int}", Name = "ObtenerId")]
        public async Task<ActionResult<Pelicula>> ObtenerPorId(int id)
        {
            try
            {
                var pelicula = await _peliculaService.ObtenerPorIdPelicula(id);
                if (pelicula != null) return Ok(pelicula);

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("films")]
        public async Task<ActionResult<Pelicula>> AgregarPelicula(Pelicula pelicula)
        {
            try
            {
                var guardar = await _peliculaService.AgregarPelicula(pelicula);
                return CreatedAtRoute("ObtenerId", new { id = guardar.id_pelicula }, guardar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("films/{id:int}")]
        public async Task<IActionResult>EliminarPelicula(int id)
        {
            try
            {
                await _peliculaService.BorrarPelicula(id);
                return Ok("La pelicula ha sido BORRADA.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("films/{id:int}")]
        public async Task<ActionResult> ActualizarPelicula(int id,Pelicula pelicula)
        {
            var updatefilm = await _peliculaService.ObtenerPorIdPelicula(id);

            updatefilm.titulo = pelicula.titulo;
            updatefilm.director = pelicula.director;
            updatefilm.id_genero = pelicula.id_genero;
            updatefilm.puntuacion = pelicula.puntuacion;
            updatefilm.rating = pelicula.rating;
            updatefilm.anio_publicacion = pelicula.anio_publicacion;

            if(!await _peliculaService.Guardar())
                return NoContent();

            return Ok(updatefilm);

            
        }
    }
}
