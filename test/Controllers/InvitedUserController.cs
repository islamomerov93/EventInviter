using EventInviter.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EventInvitedUserController:Controller
    {
        private readonly EventInviterDbContext context;
        public EventInvitedUserController(EventInviterDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public ActionResult<int> InviteUserToEvent([FromBody]EventInvitedUser IU)
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
        public ActionResult<ICollection<EventInvitedUser>> GetInvitedUsersByEventName(string Name)
        {
            return context.InvitedUsers.Where(x => x.Event.Name == Name).ToList();
        }
        [HttpGet]
        public ActionResult<ICollection<EventInvitedUser>> GetInvitedAndRejectedUsersByEventName(string Name)
        {
            return context.InvitedUsers.Where(x => x.Event.Name == Name & x.UserAcceptOrReject == false).ToList();
        }
        [HttpGet]
        public ActionResult<ICollection<EventInvitedUser>> GetInvitedAndAcceptedUsersByEventName(string Name)
        {
            return context.InvitedUsers.Where(x => x.Event.Name == Name & x.UserAcceptOrReject == true).ToList();
        }
        [HttpGet]
        public ActionResult<ICollection<EventInvitedUser>> GetUserInvitedEventsByUserId(int Id)
        {
            return context.InvitedUsers.Where(x => x.User.Id == Id).ToList();
        }
    }
}
