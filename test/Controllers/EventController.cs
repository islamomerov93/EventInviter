using EventInviter.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EventController:Controller
    {
        private readonly EventInviterDbContext context;

        public EventController(EventInviterDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public ActionResult<string> AddEvent([FromBody]Event Event)
        {
            if (ModelState.IsValid)
            {
                context.Events.Add(Event);
                context.SaveChanges();
                return Event.Name;
            }
            return BadRequest();
        }
        [HttpGet]
        public ActionResult<List<Event>> GetAllEvents()
        {
            return context.Events.ToList();
        }
        [HttpGet]
        public ActionResult<List<Event>> GetAllUpcomingEvents()
        {
            return (context.Events.Where(x => x.StartDate > DateTime.Now)).ToList();
        }
        [HttpGet]
        public ActionResult<List<Event>> GetAllEventsCreatedByUser(int UserId)
        {
            return (context.Events.Where(x => x.User.Id == (UserId+1))).ToList();
        }
        [HttpGet]
        public ActionResult<Event> GetEventByName(string EventName)
        {
            return (Event)context.Events.FirstOrDefault(x => x.Name == EventName);
        }
        [HttpPut]
        public ActionResult<string> EditEventName(string EventName, string ChangedName)
        {
            Event e = context.Events.FirstOrDefault(x => x.Name == EventName);
            e.Name = ChangedName;
            context.Entry(e).State = EntityState.Modified;
            context.SaveChanges();
            return e.Name;
        }
        [HttpPut]
        public ActionResult<string> EditEventDescription(string EventDescription, string ChangedDescription)
        {
            Event e = (Event)context.Events.FirstOrDefault(x => x.Description == EventDescription);
            e.Name = ChangedDescription;
            context.SaveChanges();
            return e.Description;
        }
    }
}
