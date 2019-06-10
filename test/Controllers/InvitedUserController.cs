using EventInviter.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.Controllers
{
    public class InvitedUserController:Controller
    {
        private readonly EventInviterDbContext context;
        public InvitedUserController(EventInviterDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public ActionResult<int> AddUserToEvent([FromBody]InvitedUser IU)
        {
            if (ModelState.IsValid)
            {
                context.InvitedUsers.Add(IU);
                context.SaveChanges();
                return IU.User.Id;
            }
            return BadRequest();
        }
        [HttpGet]
        public ActionResult<ICollection<InvitedUser>> GetInvitedUsersByEventName(string Name)
        {
            return context.InvitedUsers.Where(x => x.Event.Name == Name).ToList();
        }
        [HttpGet]
        public ActionResult<ICollection<InvitedUser>> GetUserInvitedEventsByUserId(int Id)
        {
            return context.InvitedUsers.Where(x => x.User.Id == Id).ToList();
        }
    }
}
