using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EventInviter.EF;
using EventInviter.Models;

namespace EventInviter.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController:Controller
    {
        private readonly EventInviterDbContext context;

        public UserController(EventInviterDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public ActionResult<int> AddUser([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return user.Id;
            }
            return BadRequest();
        }
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            return context.Users.ToList();
        }
        [HttpGet]
        public ActionResult<User> GetUserById(int Id)
        {
            return (User)context.Users.FirstOrDefault(x => x.Id == Id);
        }
    }
}
