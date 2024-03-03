using Microsoft.OpenApi.Models;

namespace Teste_NetCore_API.App.Configurations
{
    public class SwaggerConfiguration
    {
        public static void Config( IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Teste .NetCore API - Localiza",
                Description = "API Rest, Clean Architecture, DDD, SOLID, Clean Code, Mock AutoFixture, TDD XUnit , FluentAssertions e Moq.",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Marco Antônio M.Palacios",
                    Email = "marcoantoniomora.dev@gmail.com",
                    Url = new Uri("http://www.linkedin.com/in/m4rco-4ntonio")
                }

            }));
        }
    }
}
