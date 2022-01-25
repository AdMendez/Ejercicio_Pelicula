using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesWebApi.Models;
using MoviesWebApi.Services.Contracts;

namespace MoviesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroService _generoService;

        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genero>>> ObtenerTodosGenero()
        {
            try
            {
                var query = await _generoService.ObtenerTodosGeneros();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{x:int}")]
        public async Task<ActionResult<Genero>> ObtenerGeneroId(int x)
        {
            try
            {
                var query = await _generoService.ObtenerGeneroId(x);

                if (query != null)
                {
                    return Ok(query);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
