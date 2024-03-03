using Teste_NetCore_API.App.Domain.Interfaces.Repositories;
using Teste_NetCore_API.App.Domain.Interfaces.Services;
using Teste_NetCore_API.App.Domain.Services;
using Teste_NetCore_API.App.InfraData.Repositories;

namespace Teste_NetCore_API.App
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IBookingDomainService, BookingDomainService>();
            services.AddTransient<IMockBookingRepository, MockBookingRepository>();
        }
    }
}
