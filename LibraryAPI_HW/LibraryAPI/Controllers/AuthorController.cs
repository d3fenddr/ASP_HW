﻿using LibraryAPI.Data.Models;
using LibraryAPI.DTO.Requests;
using LibraryAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpPost("add-author")]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> AddAuthor([FromBody] AuthorAddRequest request)
    {
        try
        {
            await _authorService.AddAuthorAsync(request);
            await _authorService.AddBookToAuthorAsync(request);
            await _authorService.AddGenreToAuthorAsync(request);
            await _authorService.AddGenreToBookAsync(request);
            return Ok("Author added");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error occurred while adding author");
        }
    }

    [HttpPost("delete-author")]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> DeleteAuthor([FromBody] AuthorFindDeleteRequest request)
    {
        if (_authorService.CheckAuthorExists(request))
        {
            await _authorService.DeleteAuthorAsync(request);
            return Ok("Author deleted");
        }
        return NotFound("No author was found");  // Changed 500 to 404
    }

    [HttpPost("update-author")]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> UpdateAuthor([FromBody] AuthorUpdateRequest request, [FromQuery] AuthorFindDeleteRequest FindRequest)
    {
        if (_authorService.CheckAuthorExists(FindRequest))
        {
            await _authorService.UpdateAuthorAsync(request);
            return Ok("Author updated");
        }
        return NotFound("No author was found");  // Changed 500 to 404
    }

    [HttpGet("find-author")]
    [Authorize(Policy = "UserPolicy")]
    public async Task<IActionResult> FindAuthor([FromQuery] AuthorFindDeleteRequest request)
    {
        if (_authorService.CheckAuthorExists(request))
        {
            var author = await _authorService.FindAuthorAsync(request);
            return Ok(author);
        }
        return NotFound("No author was found");  // Changed 500 to 404
    }
}
