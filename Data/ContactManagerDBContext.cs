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
                },
                new Contact { 
                    Id = 2, 
                    FirstName = "Jane", 
                    LastName = "Doe", 
                    Email = "jane.doe@example.com", 
                    PhoneNumber = "123-456-7890", 
                    Address = "123 Main St" 
                },
                new Contact { 
                    Id = 3, 
                    FirstName = "Bob", 
                    LastName = "Doe", 
                    Email = "bob.doe@example.com", 
                    PhoneNumber = "123-456-7890", 
                    Address = "123 Main St" 
                },
                new Contact { 
                    Id = 4, 
                    FirstName = "Alice", 
                    LastName = "Doe", 
                    Email = "alice.doe@example.com", 
                    PhoneNumber = "123-456-7890", 
                    Address = "123 Main St" 
                },
                new Contact { 
                    Id = 5, 
                    FirstName = "Charlie", 
                    LastName = "Doe", 
                    Email = "charlie.doe@example.com", 
                    PhoneNumber = "123-456-7890", 
                    Address = "123 Main St" 
                }
            );
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
