using Teste_NetCore_API.App.Domain.Entities;

namespace Teste_NetCore_API.App.Domain.Interfaces.Services
{
    public interface IBookingDomainService
    {
        Task<List<Booking>> GetAllAsync();
        Task<Booking> GetByIdAsync(int id);
    }
}
