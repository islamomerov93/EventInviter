using EventInviter.EF;
using EventInviter.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<ICollection<User>> GetInvitedUsersByEventId(int Id)
        {
            var iu = context.InvitedUsers.Where(x => x.Event.Id == Id).ToList();
            if (iu.Count > 0)
            {
                var users = from invitedUser in iu
                            join User in context.Users on invitedUser.UserId equals User.Id
                            select User;
                if (users.Count() > 0) return users.ToList(); 
                return NotFound("There is not any user invited to this event");
            }
            return NotFound("There is not any event in this event id");
        }
        [HttpGet]
        public ActionResult<ICollection<User>> GetInvitedAndRejectedUsersByEventId(int Id)
        {
            var iu = context.InvitedUsers.Where(x => x.Event.Id == Id & x.UserAcceptOrReject == false).ToList();
            if (iu.Count > 0)
            {
                var users = from invitedUser in iu
                            join User in context.Users on invitedUser.UserId equals User.Id
                            select User;
                if (users.Count() > 0) return users.ToList();
                return NotFound("There is not any rejected user for this event");
            }
            return NotFound("There is not any event for this event id");
        }
        [HttpGet]
        public ActionResult<ICollection<User>> GetInvitedAndAcceptedUsersByEventId(int id)
        {
            var iu = context.InvitedUsers.Where(x => x.Event.Id == id & x.UserAcceptOrReject == true).ToList();
            if (iu.Count > 0)
            {
                var users = from invitedUser in iu
                            join User in context.Users on invitedUser.UserId equals User.Id
                            select User;
                if (users.Count() > 0) return users.ToList();
                return NotFound("There is not any rejected user for this event");
            }
            return NotFound("There is not any event for this event id");
        }
        [HttpGet]
        public ActionResult<ICollection<EventInvitedUser>> GetUserInvitedEventsByUserId(int Id)
        {
            var iu = context.InvitedUsers.Where(x => x.User.Id == Id).ToList();
            if (iu.Count > 0) return iu; 
            return NotFound("There is not any event for user id");
        }
    }
}
