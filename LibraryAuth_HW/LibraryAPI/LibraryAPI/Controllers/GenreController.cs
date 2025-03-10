using LibraryAPI.DTO.Requests;
using LibraryAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;
    
    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }
    
    [HttpPost("add-genre")]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> AddGenre([FromBody] AddGenreRequest request)
    {
        await _genreService.AddGenreAsync(request);
        await _genreService.AddGenreToAuthorAsync(request);
        await _genreService.AddGenreToBookAsync(request);
        await _genreService.AddBookToAuthorAsync(request);
        
        return Ok("Genre added");
    }

    [HttpPost("delete-genre")]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> DeleteGenre([FromBody] FindDeleteGenreRequest request)
    {
        if (_genreService.CheckGenreExists(request))
        {
            await _genreService.DeleteGenreAsync(request);
            return Ok("Genre deleted");
        }
        return NotFound("No genre was found");  // Используем 404 Not Found
    }

    [HttpPost("update-genre")]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> UpdateGenre([FromBody] UpdateGenreRequest request, [FromQuery] FindDeleteGenreRequest FindRequest)
    {
        if (_genreService.CheckGenreExists(FindRequest))
        {
            await _genreService.UpdateGenreAsync(request);
            return Ok("Genre updated");
        }
        return NotFound("No genre was found");  // Используем 404 Not Found
    }

    [HttpGet("find-genre")]
    [Authorize(Policy = "UserPolicy")]
    public async Task<IActionResult> FindGenre([FromQuery] FindDeleteGenreRequest request)
    {
        if (_genreService.CheckGenreExists(request))
        {
            var genre = await _genreService.FindGenreAsync(request);
            return Ok(genre);
        }
        return NotFound("No Genre was found");  // Используем 404 Not Found
    }
}