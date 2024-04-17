
using cacheImplementation.Controllers;
using cacheImplementation.Models;
using cacheImplementation.Repository.InterfaceRepository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace OnlineShopAPI.Test
{
    public class CustomerControllerTest
    {
        [Fact]
        public async Task GetCustomer_ReturnsExpectedResult()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var customer = new Customer
            {
                customer_id = customerId,
                customer_name = "John Doe",
                email = "johndoe@example.com",
                phone = "1234567890",
                gender = "Male",
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };

            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository.Setup(r => r.GetCustomer(customerId))
                .ReturnsAsync(customer);

            var controller = new CustomerController(mockRepository.Object);

            // Act
            var result = await controller.GetCustomer(customerId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var returnedCustomer = Assert.IsAssignableFrom<Customer>(((OkObjectResult)result.Result).Value);
            Assert.Equal(customer, returnedCustomer);
        }

        [Fact]
        public async Task GetCustomer_WhenNotFound_ReturnsNotFound()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository.Setup(r => r.GetCustomer(customerId))
                .ReturnsAsync((Customer)null);

            var controller = new CustomerController(mockRepository.Object);

            // Act
            var result = await controller.GetCustomer(customerId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostCustomer_ShouldReturnCreatedAtActionResult()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var customer = new Customer
            {
                customer_name = "John Doe",
                email = "john.doe@example.com",
                phone = "1234567890",
                gender = "Male"
            };

            mockRepository.Setup(r => r.CreateCustomer(It.IsAny<Customer>()))
                .ReturnsAsync(customer);

            var controller = new CustomerController(mockRepository.Object);
            var result = await controller.PostCustomer(customer);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(customer, createdAtActionResult.Value);
        }
    }
}