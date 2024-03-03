using Teste_NetCore_API.App.Domain.Entities;
using Teste_NetCore_API.App.Domain.Interfaces.Repositories;
using Teste_NetCore_API.App.Domain.Interfaces.Services;

namespace Teste_NetCore_API.App.Domain.Services
{
    public class BookingDomainService : IBookingDomainService
    {
        private readonly IMockBookingRepository _mockbookingRepository;

        public BookingDomainService(IMockBookingRepository mockbookingRepository)
        {
            _mockbookingRepository = mockbookingRepository;
        }

        public List<Booking> GetAll()
        {
            return _mockbookingRepository.GetAll();
        }

        public Booking GetById(int id)
        {
            return _mockbookingRepository.GetAll().FirstOrDefault(b => b.BookingId == id);
        }
    }
}
