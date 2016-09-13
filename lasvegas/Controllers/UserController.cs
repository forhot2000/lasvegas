using Lasvegas.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Lasvegas.Controllers
{
    public class UserController : ApiController
    {
        public IEnumerable<User> GetAllUsers()
        {
            return new User[] {
                new User() {Id=1, Name="wang" },
                new User() {Id=2, Name="li" }
            };
        }

        public IHttpActionResult GetUserById(int id)
        {
            switch (id)
            {
                case 1:
                    return Ok(new User() { Id = 1, Name = "wang" });
                case 2:
                    return Ok(new User() { Id = 2, Name = "li" });
                default:
                    return NotFound();
            }
        }
    }
}
