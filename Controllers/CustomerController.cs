using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_API.Data;
using Test_API.Models;

namespace Test_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public CustomerController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            var data = _context.Customers.ToList();
            if (data.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }
        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var data = _context.Customers.Where(e => e.Id == id).SingleOrDefault();
                if (data == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(data);
                }
            }
        }

        [HttpPost]
        [Route("AddCustomer")]
        public IActionResult AddCustomer([FromBody] Customer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var data = new Customer
                {
                    Name = model.Name,
                    Gender = model.Gender,
                    IsActive = model.IsActive
                };
                _context.Customers.Add(data);
                _context.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public IActionResult UpdateCustomer([FromBody] Customer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var data = _context.Customers.Where(e => e.Id == model.Id).SingleOrDefault();
                if (data == null)
                {
                    return BadRequest();
                }
                else
                {
                    data.Name = model.Name;
                    data.Gender = model.Gender;
                    data.IsActive = model.IsActive;
                    //var newdata = new Customer
                    //{
                    //    Id = model.Id,
                    //    Name = model.Name,
                    //    Gender = model.Gender,
                    //    IsActive = model.IsActive
                    //};
                    _context.Customers.Update(data);
                    _context.SaveChanges();
                    return Ok();
                }
            }
        }

        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            if (id != 0)
            {
                var data = _context.Customers.Where(e => e.Id == id).SingleOrDefault();
                if (data == null)
                {
                    return BadRequest();
                }
                else
                {
                    _context.Customers.Remove(data);
                    _context.SaveChanges();
                }
            }
            else
            {
                return BadRequest();

            }
            return Ok();
        }
    }
}
