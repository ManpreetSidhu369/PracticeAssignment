﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeAssignment.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly NORTHWNDContext _context;
        public ProductsController()
        {
            _context = new NORTHWNDContext();
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
           return _context.Products.Include(p=>p.Supplier).Include(p=>p.Category).ToList();
            
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id:int}")]
        public Product Get(int id)
        {
            return _context.Products.FirstOrDefault(p=>p.ProductId==id)?? new Product();
        }
        // GET api/<ProductsController>/5
        [HttpGet("{name}")]
        public Product Get(string name)
        {
            return _context.Products.FirstOrDefault(p => p.ProductName == name) ?? new Product();
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
