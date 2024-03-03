using Teste_NetCore_API.App;
using Teste_NetCore_API.App.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

SwaggerConfiguration.Config(builder.Services);

DependencyInjection.Register(builder.Services);

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("DefaultPolicy");
app.MapControllers();
app.Run();
