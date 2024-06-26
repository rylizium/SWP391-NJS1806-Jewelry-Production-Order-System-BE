﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories.Dto;
using Repositories.Models;
using Services;

namespace JewelryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class UsersController : ControllerBase
    {
        private readonly UserService iUserService;

        public UsersController()
        {
            iUserService = new UserService();
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult GetUsers()
        {
            if (iUserService.GetAllUsers() == null)
            {
                return NotFound();
            }
            var list = iUserService.GetAllUsers().ToList();
            return Ok(list);
        }
        [HttpGet("GetRole{roleId}")]

        public IActionResult GetAllUsersByRole(int roleId, int pageNumber, int pageSize)
        {
            if (iUserService.GetAllUsers() == null)
            {
                return NotFound();
            }
            return Ok(iUserService.GetAllUsersByRole(roleId, pageNumber, pageSize));
        }
        [HttpGet("Customers")]
        public IActionResult GetCustomers()
        {
            if (iUserService.GetCustomers() == null)
            {
                return NotFound();
            }
            var list = iUserService.GetCustomers().ToList();
            return Ok(list);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            if (iUserService.GetUsers() == null)
            {
                return NotFound();
            }
            var user = iUserService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutUser(string id, UserDto user)
        {
            if (!user.Uid.Equals(id))
            {
                return BadRequest();
            }

            iUserService.UpdateUser(id, user);

            return NoContent();
            
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostUser(User user)
        {
            if(iUserService.GetUsers() == null)
            {
                return NotFound();
            }
            iUserService.AddUser(user);

            return Ok(user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            
            if (iUserService.GetUsers() == null)
            {
                return NotFound();
            }
            if(iUserService.GetUser(id) == null)
            {
                return NotFound();
            }

            iUserService.DeleteUser(id);
            return NoContent();
        }

        //private bool UserExists(string id)
        //{
        //    return iUserService.Users.Any(e => e.Uid == id);
        //}
    }
}
