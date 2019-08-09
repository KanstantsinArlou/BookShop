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
    public class CategoryController : ControllerBase
    {
        private Db _context;

        public CategoryController(Db context)
        {
            _context = context;
        }
        // GET api/category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET api/category/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // POST api/category
        [HttpPost]
        public async Task<ActionResult<Category>> Post(Category item)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(item);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = item.Id }, item);

            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/category/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Category item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/category/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}