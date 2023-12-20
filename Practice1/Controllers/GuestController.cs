using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice1.Models;

namespace Practice1.Controllers
{
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {
        private DataContext db;
        public GuestController(DataContext ctx)
        {
            db = ctx;
        }
        [HttpGet]
        public IEnumerable<Guest> GetGuest()
        {
            return db.Guests.ToList();
        }
        [HttpGet("{id}")]
        public Guest GetGuest(int id)
        {
            return db.Guests.Where(p => p.IdGuest == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SaveGuest([FromBody] Guest guest)
        {
            db.Guests.Add(guest);
            db.SaveChanges();
        }
        [HttpPut]
        public void UpdateGuest([FromBody] Guest guest)
        {
            db.Guests.Update(guest);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteGuest(long id)
        {
            db.Guests.Remove(db.Guests.Where(p => p.IdGuest == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
