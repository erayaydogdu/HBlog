﻿using Microsoft.AspNetCore.Mvc;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;

namespace API.Controllers
{
    [Authorize]
    public class PostsController : BaseApiController
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            this._postRepository = postRepository;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return Ok(await _postRepository.GetPostsAsync());
        }


        [HttpGet("{username}")]
        public async Task<ActionResult<Post>> GetPostByUsername(string username)
        {
            return await _postRepository.GetPostByUsername(username);
        }
        // PUT: api/AppUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Post post)
        {
            // if (id != appUser.Id)
            // {
            //     return BadRequest();
            // }
            // try
            // {
            //     await _context.SaveChangesAsync();
            // }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!AppUserExists(id))
            //     {
            //         return NotFound();
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }

            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<User>> Post(Post post)
        {
            // _context.Users.Add(appUser);
            // await _context.SaveChangesAsync();
            // return CreatedAtAction("GetAppUser", new { id = appUser.Id }, appUser);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // var appUser = await _context.Users.FindAsync(id);
            // if (appUser == null)
            // {
            //     return NotFound();
            // }

            // _context.Users.Remove(appUser);
            // await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppUserExists(int id)
        {
            // return _context.Users.Any(e => e.Id == id);
            return true;
        }
    }
}
