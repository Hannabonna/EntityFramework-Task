using Microsoft.EntityFrameworkCore;
using EntityTask.Model;

namespace EntityTask
{
    public class MemberContext : DbContext
    {
        public MemberContext(DbContextOptions<MemberContext> options) : base(options){}

        public DbSet<Member> Members { get; set; }
    }
}