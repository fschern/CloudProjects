using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
  [Route("api/[controller]")]
  public class UserController : Controller
  {
    public IUserManager Manager { get; set; }

    public UserController(IUserManager manager)
    {
      Manager = manager;
    }

    [HttpGet("{id}", Name = "GetUser")]
    public IActionResult GetById(int id)
    {
      User item = null;

      try
      {
        item = Manager.GetUser(id);
      }
      catch (Exception)
      {
        return NotFound();
      }

      if (item == null)
      {
        return NotFound();
      }

      return new ObjectResult(item);
    }

    [HttpGet]
    public IEnumerable<User> GetAll()
    {
      return Manager.GetAllUsers();
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] User item)
    {
      if (item == null)
      {
        return BadRequest();
      }

      Manager.AddUser(item);
      return CreatedAtRoute("GetUser", new { id = item.ID }, item);
    }
  }
}
