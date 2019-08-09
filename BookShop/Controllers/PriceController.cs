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
    public class PriceController : ControllerBase
    {
        private Db _context;

        public PriceController(Db context)
        {
            _context = context;
        }
        // GET api/price
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Price>>> Get()
        {
            return await _context.Prices.ToListAsync();
        }

        // GET api/price/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Price>> Get(int id)
        {
            var price = await _context.Prices.FindAsync(id);

            if (price == null)
            {
                return NotFound();
            }

            return price;
        }

        // POST api/price
        [HttpPost]
        public async Task<ActionResult<Price>> Post(Price item)
        {
            if (ModelState.IsValid)
            {
                _context.Prices.Add(item);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/price/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Price item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/price/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var price = await _context.Prices.FindAsync(id);

            if (price == null)
            {
                return NotFound();
            }

            _context.Prices.Remove(price);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}