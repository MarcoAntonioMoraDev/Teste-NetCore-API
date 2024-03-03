using Teste_NetCore_API.App.Domain.Entities;

namespace Teste_NetCore_API.App.Domain.Interfaces.Services
{
    public interface IBookingDomainService
    {
        List<Booking> GetAll();
        Booking GetById(int id);
    }
}
