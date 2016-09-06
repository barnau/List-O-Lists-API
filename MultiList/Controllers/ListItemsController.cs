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
using MultiList.Infrastructure;
using MultiList.Models;

namespace MultiList.Controllers
{
    public class ListItemsController : ApiController
    {
        private MultiListDataContext db = new MultiListDataContext();

        // GET: api/ListItems
        public IQueryable<ListItem> GetListItems()
        {
            return db.ListItems;
        }

        // GET: api/ListItems/5
        [ResponseType(typeof(ListItem))]
        public IHttpActionResult GetListItem(int id)
        {
            ListItem listItem = db.ListItems.Find(id);
            if (listItem == null)
            {
                return NotFound();
            }

            return Ok(listItem);
        }

        // PUT: api/ListItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutListItem(int id, ListItem listItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listItem.ListItemId)
            {
                return BadRequest();
            }

            db.Entry(listItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListItemExists(id))
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

        // POST: api/ListItems
        [ResponseType(typeof(ListItem))]
        public IHttpActionResult PostListItem(ListItem listItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ListItems.Add(listItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = listItem.ListItemId }, listItem);
        }

        // DELETE: api/ListItems/5
        [ResponseType(typeof(ListItem))]
        public IHttpActionResult DeleteListItem(int id)
        {
            ListItem listItem = db.ListItems.Find(id);
            if (listItem == null)
            {
                return NotFound();
            }

            db.ListItems.Remove(listItem);
            db.SaveChanges();

            return Ok(listItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListItemExists(int id)
        {
            return db.ListItems.Count(e => e.ListItemId == id) > 0;
        }
    }
}