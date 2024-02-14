using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
RegisterServices(builder);
var app = builder.Build();

// Configure the HTTP request pipeline.
ConfigureRequestPipeline(app);

//pre-populate data
DataInitializer.Prepopulate(app);

app.Run();

#region local methods
static void RegisterServices(WebApplicationBuilder builder)
{
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMemoryPlatformDb"));
    builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddSwaggerGen();
}
static void ConfigureRequestPipeline(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    //app.UseHttpsRedirection(); //https://localhost:7196/
    app.UseAuthorization();
    app.MapControllers().WithOpenApi();
}
#endregion
