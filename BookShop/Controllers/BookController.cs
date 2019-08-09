using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private  Db _context;


        public BookController(Db context)
        {
            _context = context;
        }
        // GET api/book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        // GET api/book/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Object>> Get(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // POST api/book
        [HttpPost]
        public async Task<ActionResult<Object>> Post(Book item)
        {

            if (ModelState.IsValid)
            {
                _context.Books.Add(item);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
            }
            else
            {
                return BadRequest();
            }
            
        }

        // PUT api/book/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Book item)
        {
           
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/book/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
