namespace ContactManagement.Tests
{
    using Xunit;
    using Moq;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using ContactManagement.Controllers;
    using ContactManagement.Models;
    using NuGet.ContentModel;
    using ContactManagement.Data;
    using Microsoft.AspNetCore.Mvc;

    public class ContactControllerTests
    {
        [Fact]
        public async Task Update_ValidContact_ReturnsSuccess()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ContactManagerDBContext>()
                .UseInMemoryDatabase(databaseName: "ContactTestDatabase")
                .Options;

            using (var context = new ContactManagerDBContext(options))
            {
                var contact = new Contact
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "1234567890",
                    Address = "123 Main St"
                };

                context.Contacts.Add(contact);
                context.SaveChanges();
            }

            var mockContext = new Mock<ContactManagerDBContext>(options);
            var controller = new ContactsController(mockContext.Object);

            // Act
            var result = await controller.Update(new Contact
            {
                Id = 1,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                PhoneNumber = "9876543210",
                Address = "456 Elm St"
            }) as JsonResult;

            // Assert
            Assert.NotNull(result);
            dynamic data = result.Value;
            Assert.True(data.success);
        }

        [Fact]
        public async Task Create_ValidContact_ReturnsSuccess()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ContactManagerDBContext>()
                .UseInMemoryDatabase(databaseName: "ContactTestDatabase")
                .Options;

            using (var context = new ContactManagerDBContext(options))
            {
                var controller = new ContactsController(context);
                var contact = new Contact
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "1234567890",
                    Address = "123 Main St"
                };

                // Act
                var result = await controller.Create(contact) as JsonResult;

                // Assert
                Assert.NotNull(result);
                dynamic data = result.Value;
                Assert.True(data.success);
            }
        }
    }
}
