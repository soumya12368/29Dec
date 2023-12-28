using Student_Mng_Marks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student_Mng_Marks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext userContext;

        public UsersController(UserContext userContext)
        {
            this.userContext = userContext;
        }

        [HttpGet]
        [Route("GetUsers")]
        public List<Users> GetUsers()
        {
            return userContext.Users.ToList();
        }

        [HttpGet]
        [Route("GetUser")]
        public Users GetUser(int id)
        {
            return userContext.Users.Where(x => x.ID == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("AddUser")]
        public string AddUser(Users users)
        {
            string response = string.Empty;
            userContext.Users.Add(users);
            userContext.SaveChanges();
            return "User added";
        }

        [HttpPut]
        [Route("UpdateUser")]
        public string UpdateUser(Users users)
        {
            userContext.Entry(users).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            userContext.SaveChanges();
            return "User Updated";
        }

        [HttpDelete]
        [Route("DeleteUsers")]
        public string DeleteUser(int id)
        {
            Users user = userContext.Users.Where(x => x.ID == id).FirstOrDefault();
            if(user != null)
            {
                userContext.Users.Remove(user);
                userContext.SaveChanges();
                return "User deleted";
            } else
            {
                return "No User found";
            }
            
        }
    }
}
