using Microsoft.EntityFrameworkCore;
namespace Student_Mng_Marks.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<Users> Users { get; set; }
    }
}
