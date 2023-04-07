using System.Net;
using ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using HotChocolate.Validation;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam_QGI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnoncesController : ControllerBase
    {
        private readonly DbContext _context;

        private DbSet<Annonces> Recipes => _context.Set<Annonces>();

        public AnnoncesController(DbContext context)
        {
            _context = context;
        }

        // GET api/<RecipeController>/5
        [HttpGet("{id}")]
        public Annonces? Get(int id)
        {
            return _context.Set<Annonces>()
                .FirstOrDefault(x => x.Id == id);
        }


        // GET: api/<ParameterController>
        [HttpGet("")]
        public IEnumerable<Annonces> Get()
        {
            return _context.Set<Annonces>()
   
                .ToList();
        }

        // POST api/<ParameterController>
        [HttpPost]
        public void Post([FromBody] Annonces value)
        {
            _context.Set<Annonces>().Add(value);
            _context.SaveChanges();
        }


        // DELETE api/<RecipeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Recipes.Remove(new Annonces { Id = id });
            _context.SaveChanges();
        }

    }
}
