using ContactManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Data
{
    public class ContactManagerDBContext : DbContext
    {
        public ContactManagerDBContext(DbContextOptions<ContactManagerDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact { 
                    Id = 1, 
                    FirstName = "John", 
                    LastName = "Doe", 
                    Email = "john.doe@example.com", 
                    PhoneNumber = "123-456-7890", 
                    Address = "123 Main St" 
                }
            );
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
