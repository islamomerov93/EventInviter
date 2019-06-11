using EventInviter.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var events = context.Events.ToList();
            if (events.Count > 0) return events; 
            return NotFound("There is not any event");
        }
        [HttpGet]
        public ActionResult<List<Event>> GetAllUpcomingEvents()
        {
            var events = (context.Events.Where(x => x.StartDate > DateTime.Now)).ToList();
            if (events.Count > 0) return events; 
            return NotFound("There is not any upcoming event");
        }
        [HttpGet]
        public ActionResult<List<Event>> GetAllEventsCreatedByUser(int UserId)
        {
            var events = (context.Events.Where(x => x.User.Id == UserId)).ToList();
            if (events.Count > 0) return events; 
            return NotFound("There is not any event created by this user id");
        }
        [HttpGet]
        public ActionResult<Event> GetEventById(int Id)
        {
            var e = (Event)context.Events.FirstOrDefault(x => x.Id == Id);
            if (e != null) return e;
            return NotFound("There is not any event in this id");
        }
        [HttpPut]
        public ActionResult<string> EditEventName(int Id, string ChangedName)
        {
            Event e = context.Events.FirstOrDefault(x => x.Id == Id);
            if (e != null)
            {
                e.Name = ChangedName;
                context.Entry(e).State = EntityState.Modified;
                context.SaveChanges();
                return e.Name;
            }
            return NotFound("There is not any event in this id");
        }
        [HttpPut]
        public ActionResult<string> EditEventDescription(int Id, string ChangedDescription)
        {
            Event e = context.Events.FirstOrDefault(x => x.Id == Id);
            if (e != null)
            {
                e.Name = ChangedDescription;
                context.Entry(e).State = EntityState.Modified;
                context.SaveChanges();
                return e.Name;
            }
            return NotFound("There is not any event in this id");
        }
    }
}
