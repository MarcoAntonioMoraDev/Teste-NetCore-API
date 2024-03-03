using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste_NetCore_API.App.Controllers;
using Teste_NetCore_API.App.Domain.Entities;
using Teste_NetCore_API.App.Domain.Interfaces.Services;
using Xunit;

namespace Teste_NetCore_API.App.Tests.Controller
{
    public class BookingControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfBookings()
        {
            // Arrange
            var mockService = new Mock<IBookingDomainService>();
            var expectedBookings = new List<Booking> { new Booking { BookingId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7), Customer = new Customer { CustomerId = 1, Name = "Customer 1", CPF = "123456789", Email = "customer1@example.com" }, Vehicle = new Vehicle { VehicleId = 1, Brand = "Brand 1", Model = "Model 1", Year = 2022 }, RatingStatus = true, CommentStatus = false }, new Booking { BookingId = 2, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7), Customer = new Customer { CustomerId = 2, Name = "Customer 2", CPF = "987654321", Email = "customer2@example.com" }, Vehicle = new Vehicle { VehicleId = 2, Brand = "Brand 2", Model = "Model 2", Year = 2023 }, RatingStatus = false, CommentStatus = true } };
            mockService.Setup(service => service.GetAllAsync()).Returns(Task.FromResult(expectedBookings));
            var controller = new BookingController(mockService.Object);

            // Act
            var result = await controller.GetAll() as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            result.Value.Should().BeOfType<List<Booking>>().Subject.Should().BeEquivalentTo(expectedBookings);
        }

        [Fact]
        public async Task GetById_WithValidId_ReturnsOkResult_WithBooking()
        {
            // Arrange
            int id = 1;
            var expectedBooking = new Booking { BookingId = id, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7), Customer = new Customer { CustomerId = 1, Name = "Customer 1", CPF = "123456789", Email = "customer1@example.com" }, Vehicle = new Vehicle { VehicleId = 1, Brand = "Brand 1", Model = "Model 1", Year = 2022 }, RatingStatus = true, CommentStatus = false };
            var mockService = new Mock<IBookingDomainService>();
            mockService.Setup(service => service.GetByIdAsync(id)).Returns(Task.FromResult(expectedBooking));
            var controller = new BookingController(mockService.Object);

            // Act
            var result = await controller.GetById(id) as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            result.Value.Should().BeOfType<Booking>().Subject.Should().BeEquivalentTo(expectedBooking);
        }

        [Fact]
        public async Task GetById_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            int id = 1;
            var mockService = new Mock<IBookingDomainService>();
            mockService.Setup(service => service.GetByIdAsync(id)).Returns(Task.FromResult<Booking>(null));
            var controller = new BookingController(mockService.Object);

            // Act
            var result = await controller.GetById(id) as NotFoundObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
            result.Value.Should().Be("Booking not found");
        }
    }
}
