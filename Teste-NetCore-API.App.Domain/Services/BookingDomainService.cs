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

        public async Task<List<Booking>> GetAllAsync()
        {
            return await _mockbookingRepository.GetAllAsync();
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            var bookings = await _mockbookingRepository.GetAllAsync();
            return bookings.FirstOrDefault(b => b.BookingId == id);
        }
    }
}
