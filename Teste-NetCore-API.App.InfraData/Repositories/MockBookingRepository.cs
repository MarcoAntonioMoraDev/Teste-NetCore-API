using Teste_NetCore_API.App.Domain.Entities;
using Teste_NetCore_API.App.Domain.Interfaces.Repositories;
using AutoFixture;

namespace Teste_NetCore_API.App.InfraData.Repositories
{
    public class MockBookingRepository : IMockBookingRepository
    {
        private readonly Fixture _fixture;
        private readonly List<Booking> _bookings;

        public MockBookingRepository()
        {
            _fixture = new Fixture();
            _bookings = GenerateBookings();
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            await Task.Delay(100); // Simulação de operação assíncrona
            return _bookings;
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            await Task.Delay(100); // Simulação de operação assíncrona
            return _bookings.FirstOrDefault(b => b.BookingId == id);
        }

        private List<Booking> GenerateBookings()
        {
            var bookings = new List<Booking>();

            for (int i = 1; i <= 10; i++)
            {
                var booking = new Booking
                {
                    BookingId = i,
                    StartDate = new DateTime(2023, 4, 10).AddDays(i),
                    EndDate = new DateTime(2023, 6, 26).AddDays(i),
                    CustomerId = i + 80,
                    VehicleId = i + 120,
                    RatingStatus = true,
                    CommentStatus = false,
                    Customer = new Customer
                    {
                        CustomerId = i + 80,
                        Name = "Name" + i.ToString(),
                        CPF = "CPF" + i.ToString(),
                        Email = "Email" + i.ToString() + "@example.com"
                    },
                    Vehicle = new Vehicle
                    {
                        VehicleId = i + 120,
                        Brand = "Brand" + i.ToString(),
                        Model = "Model" + i.ToString(),
                        Year = 2021 + i
                    }
                };

                bookings.Add(booking);
            }

            return bookings;
        }
    }
}
