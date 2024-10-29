using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Optix.Database.DbContext.Tables;
using Optix.Service.ServiceAPI.Data;

namespace Optix.Service.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : OpControllerBase
    {
        private readonly OptixServiceServiceAPIContext _context;

        public MoviesController(OptixServiceServiceAPIContext context)
        {
            _context = context;
        }

        [HttpGet("GetTheMovie")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Tbl_Movies))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Tbl_Movies>> GetTheMovie([FromQuery] int? id)
        {
            // Check for null or invalid ID
            if (id == null)
            {
                return BadRequest("Movie ID is required.");
            }

            var tbl_Movies = await _context.Tbl_Movies.FindAsync(id);

            if (tbl_Movies == null)
            {
                return NotFound($"No movie found with ID {id}");
            }

            return Ok(tbl_Movies);  // Wrap the result in Ok() for consistency
        }

        [HttpGet("GetMovieByName")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Tbl_Movies))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Tbl_Movies>> GetMovieByName([FromQuery] string? name)
        {
            // Check for null or invalid ID
            if (name == null)
            {
                return BadRequest("Movie ID is required.");
            }

            var tbl_Movies = await _context.Tbl_Movies.FindAsync(name);

            if (tbl_Movies == null)
            {
                return NotFound($"No movie found with ID {name}");
            }

            return Ok(tbl_Movies);  // Wrap the result in Ok() for consistency
        }


        [HttpPost("SearchMovies")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Tbl_Movies))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Tbl_Movies>>> SearchMovies([Required] string searchItem, int pageLimit = 50 , int pageNumber = 1)
        {
            
            if (searchItem == null)
            {
                return BadRequest("searchItem is required.");
            }
            // Basic input validation
            if (pageLimit <= 0) pageLimit = 10; // Set a default limit if the input is invalid
            if (pageNumber <= 0) pageNumber = 1;     // Default to the first page if invalid page number

            // Retrieve data with pagination
            var moviesQuery = _context.Tbl_Movies
                .Where(m => m.Title.Contains(searchItem))
                .Skip((pageNumber - 1) * pageLimit)
                .Take(pageLimit); // Take only the specified number of results

            var movies = await moviesQuery.ToListAsync();
            return Ok(movies);
        }
    }
}
