using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Event_Manager.Data_Access;
using Event_Manager.Models;
using System.Collections.Generic;

namespace Event_Manager.Controllers
{
    [RoutePrefix("api/events")]
    public class EventsController : ApiController
    {
        private EventManagerDbContext db = new EventManagerDbContext();
        EventRepository<Event> repository = new EventRepository<Event>();

        // GET: api/Events
        [Route("get-all")]
        public List<Event> GetEvents()
        {
            return repository.GetAll();
        }

        // GET: api/Events/5
        [Route("get")]
        [ResponseType(typeof(Event))]
        public IHttpActionResult GetEvent(int id)
        {
            Event @event = repository.GetById(id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // POST: api/Events
        [Route("post")]
        [ResponseType(typeof(Event))]
        public IHttpActionResult PostEvent(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Insert(@event);
            
            return Ok(@event);
        }

        // PUT: api/Events/5
        [Route("put")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvent(int id, Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.Id)
            {
                return BadRequest();
            }

            

            try
            {
                repository.Update(@event);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        

        // DELETE: api/Events/5
        [Route("delete")]
        [ResponseType(typeof(Event))]
        public IHttpActionResult DeleteEvent(int id)
        {
            Event @event = repository.GetById(id);
            if (@event == null)
            {
                return NotFound();
            }

            repository.Delete(@event);

            return Ok(@event);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(int id)
        {
            return db.Events.Count(e => e.Id == id) > 0;
        }
    }
}