using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSuerte.Data;
using WebSuerte.Models;

namespace WebSuerte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private readonly AppDbContext _context;



        public RandomController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Futuro>> GetFuturo()
        {
            var list = await _context.Futuro.ToListAsync();

            var max = list.Count;
            int index = new Random().Next(0, max);
            var fut = list[index];

            if (fut == null)
            {
                return NoContent();
            }

            return fut;
        }
    }
}
