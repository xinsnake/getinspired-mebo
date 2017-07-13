using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using mebo_meetingroom_api.Database;

namespace mebo_meetingroom_api.Controllers
{
    public class MeetingRoomsController : ApiController
    {
        private MeetingRoomEntities db = new MeetingRoomEntities();

        // GET: api/MeetingRooms
        public IQueryable<MeetingRoom> GetMeetingRooms()
        {
            return db.MeetingRooms;
        }

        // GET: api/MeetingRooms/5
        [ResponseType(typeof(MeetingRoom))]
        public IHttpActionResult GetMeetingRoom(string id)
        {
            MeetingRoom meetingRoom = db.MeetingRooms.Find(id);
            if (meetingRoom == null)
            {
                return NotFound();
            }

            return Ok(meetingRoom);
        }

        /*// PUT: api/MeetingRooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMeetingRoom(string id, MeetingRoom meetingRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meetingRoom.Id)
            {
                return BadRequest();
            }

            db.Entry(meetingRoom).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingRoomExists(id))
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

        // POST: api/MeetingRooms
        [ResponseType(typeof(MeetingRoom))]
        public IHttpActionResult PostMeetingRoom(MeetingRoom meetingRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MeetingRooms.Add(meetingRoom);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MeetingRoomExists(meetingRoom.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = meetingRoom.Id }, meetingRoom);
        }

        // DELETE: api/MeetingRooms/5
        [ResponseType(typeof(MeetingRoom))]
        public IHttpActionResult DeleteMeetingRoom(string id)
        {
            MeetingRoom meetingRoom = db.MeetingRooms.Find(id);
            if (meetingRoom == null)
            {
                return NotFound();
            }

            db.MeetingRooms.Remove(meetingRoom);
            db.SaveChanges();

            return Ok(meetingRoom);
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeetingRoomExists(string id)
        {
            return db.MeetingRooms.Count(e => e.Id == id) > 0;
        }
    }
}
 