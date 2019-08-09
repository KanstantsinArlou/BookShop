using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private Db db;

        public AuthorController(Db context)
        {
            db = context;

        }

        // GET api/author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> Get()
        {
            return await db.Authors.ToListAsync();
        }

        // GET api/author/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(int id)
        {
            var author = await db.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // POST api/author
        [HttpPost]
        public async Task<ActionResult<Author>> Post(Author item)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(item);
                await db.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = item.Id }, item);

            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/author/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Author item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/book/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await db.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            db.Authors.Remove(author);
            await db.SaveChangesAsync();

            return NoContent();
        }
    }
}