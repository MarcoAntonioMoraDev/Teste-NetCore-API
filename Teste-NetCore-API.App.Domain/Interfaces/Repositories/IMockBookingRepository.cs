using Teste_NetCore_API.App.Domain.Entities;

namespace Teste_NetCore_API.App.Domain.Interfaces.Repositories
{
    public interface IMockBookingRepository
    {
        Task<List<Booking>> GetAllAsync();
        Task<Booking> GetByIdAsync(int id);
    }
}
