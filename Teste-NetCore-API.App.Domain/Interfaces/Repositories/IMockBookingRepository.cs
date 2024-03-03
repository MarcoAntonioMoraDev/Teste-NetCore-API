using Teste_NetCore_API.App.Domain.Entities;

namespace Teste_NetCore_API.App.Domain.Interfaces.Repositories
{
    public interface IMockBookingRepository
    {
        List<Booking> GetAll();
    }
}