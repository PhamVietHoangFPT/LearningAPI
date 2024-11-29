using LearningAPI.Models.Entities.Account;
using Microsoft.EntityFrameworkCore;

namespace LearningAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
