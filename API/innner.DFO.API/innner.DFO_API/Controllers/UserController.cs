using Microsoft.AspNetCore.Mvc;
using innner.DFO_API.Business;
using System;
using User = innner.DFO_API.Model.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace innner.DFO_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class UserController : Controller
    {
        private readonly IUserManager _user;

        public UserController(IUserManager user)
        {
            _user = user;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var users = _user.GetAll();

                return Ok(users);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ""); 
            }
        }
        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var user = _user.GetById(id);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "");
            }

        }

        [HttpPost("createUser")]

        public IActionResult Create(User User)
        {
            try
            {
                var users = _user.CreateUser(User);

                return Ok("That's GetAll Ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "");
            }
        }

        [HttpPut("updateUser")]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                var users = _user.UpdateUser(user);

                return Ok("That's GetAll Ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "");
            }
        }

        [HttpDelete("deleteUser")]
        public IActionResult DeleteUser(int Id)
        {
            try
            {
                var users = _user.DeleteUser(new User { Id = Id });

                return Ok("That's GetAll Ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "");
            }
        }
    }
}
