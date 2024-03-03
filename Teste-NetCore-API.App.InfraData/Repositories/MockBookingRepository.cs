using Teste_NetCore_API.App.Domain.Entities;
using Teste_NetCore_API.App.Domain.Interfaces.Repositories;
using AutoFixture;

namespace Teste_NetCore_API.App.InfraData.Repositories
{
    public class MockBookingRepository : IMockBookingRepository
    {
        private readonly Fixture _fixture;
        private readonly Random _random;

        public MockBookingRepository()
        {
            _fixture = new Fixture();
            _random = new Random();
        }

        public List<Booking> GetAll()
        {
            var bookings = new List<Booking>();

            var customerIds = new HashSet<int>();
            var vehicleIds = new HashSet<int>();

            for (int i = 0; i < 10; i++)
            {
                var customerId = _fixture.Create<int>();
                while (!customerIds.Add(customerId))
                {
                    customerId = _fixture.Create<int>();
                }

                var vehicleId = _fixture.Create<int>();
                while (!vehicleIds.Add(vehicleId))
                {
                    vehicleId = _fixture.Create<int>();
                }

                var startYear = 2020;
                var endYear = DateTime.Now.Year;
                var startDate = new DateTime(startYear, 1, 1).AddDays(_random.Next(0, (endYear - startYear) * 365));

                var endDate = startDate.AddDays(_random.Next(30, 90));

                var booking = _fixture.Build<Booking>()
                                      .With(b => b.BookingId, i + 1)
                                      .With(b => b.CustomerId, customerId)
                                      .With(b => b.VehicleId, vehicleId)
                                      .With(b => b.StartDate, startDate)
                                      .With(b => b.EndDate, endDate)
                                      .With(b => b.Customer, new Customer
                                      {
                                          CustomerId = customerId,
                                          Name = $"Name{_fixture.Create<string>()}", // Concatenando a string "Name"
                                          CPF = $"CPF{_fixture.Create<string>()}", // Concatenando a string "CPF"
                                          Email = $"Email{_fixture.Create<string>()}", // Concatenando a string "Email"
                                      })
                                      .With(b => b.Vehicle, new Vehicle
                                      {
                                          VehicleId = vehicleId,
                                          Brand = $"Brand{_fixture.Create<string>()}", // Concatenando a string "Brand"
                                          Model = $"Model{_fixture.Create<string>()}", // Concatenando a string "Model"
                                          Year = _random.Next(2020, endYear + 1)
                                      })
                                      .Create();

                bookings.Add(booking);
            }

            return bookings;
        }
    }
}


























//using Teste_NetCore_API.App.Domain.Entities;
//using Teste_NetCore_API.App.Domain.Interfaces.Repositories;
//using AutoFixture;

//namespace Teste_NetCore_API.App.InfraData.Repositories
//{
//    public class MockBookingRepository : IMockBookingRepository
//    {
//        private readonly Fixture _fixture;
//        private readonly Random _random;

//        public MockBookingRepository()
//        {
//            _fixture = new Fixture();
//            _random = new Random();
//        }

//        public List<Booking> GetAll()
//        {
//            var bookings = new List<Booking>();

//            var customerIds = new HashSet<int>(); 
//            var vehicleIds = new HashSet<int>();

//            for (int i = 0; i < 10; i++)
//            {
//                var customerId = _fixture.Create<int>();
//                while (!customerIds.Add(customerId))
//                {
//                    customerId = _fixture.Create<int>();
//                }

//                var vehicleId = _fixture.Create<int>();
//                while (!vehicleIds.Add(vehicleId))
//                {
//                    vehicleId = _fixture.Create<int>();
//                }

//                var startYear = 2020;
//                var endYear = DateTime.Now.Year;
//                var startDate = new DateTime(startYear, 1, 1).AddDays(_random.Next(0, (endYear - startYear) * 365));

//                var endDate = startDate.AddDays(_random.Next(30, 90));

//                var booking = _fixture.Build<Booking>()
//                                      .With(b => b.BookingId, i + 1)
//                                      .With(b => b.CustomerId, customerId)
//                                      .With(b => b.VehicleId, vehicleId)
//                                      .With(b => b.StartDate, startDate)
//                                      .With(b => b.EndDate, endDate)
//                                      .With(b => b.Customer, new Customer
//                                      {
//                                          CustomerId = customerId,
//                                          Name = _fixture.Create<string>(), 
//                                          CPF = _fixture.Create<string>(), 
//                                          Email = _fixture.Create<string>(),
//                                      })
//                                      .With(b => b.Vehicle, new Vehicle
//                                      {
//                                          VehicleId = vehicleId,
//                                          Brand = _fixture.Create<string>(),
//                                          Model = _fixture.Create<string>(),
//                                          Year = _random.Next(2020, endYear + 1)
//                                      })
//                                      .Create();

//                bookings.Add(booking);
//            }

//            return bookings;
//        }
//    }
//}