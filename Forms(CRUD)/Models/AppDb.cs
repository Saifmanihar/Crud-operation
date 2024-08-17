using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forms_CRUD_.Models
{
    public class AppDb : IdentityDbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {

        }


        public DbSet<StudentModel> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentModel>().HasData(
                new StudentModel
                {
                    Id = 1,
                    Name="salam",
                    Email="salder22@gmail.com",
                    Description="I am salam"
                },
                new StudentModel
                {
                    Id = 2,
                    Name = "salamander",
                    Email = "salder22@gmail.com",
                    Description = "I am salamander"
                }
                );
        }
    }
}
