using Microsoft.EntityFrameworkCore;
using Serilog;
using Subscriber.Data;
using Subscriber.WebWpi.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.ConfigurationService();
builder.Host.UseSerilog((context, configuration) =>
{

    configuration.ReadFrom.Configuration(context.Configuration);

});

builder.Services.AddDbContext<WeightWatchersContext>(option =>
{
   
    option.UseSqlServer(configuration.GetConnectionString("ConnectionStringSql"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt => opt.AddPolicy("MyPolicy", policy => { 
policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();})
);


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();
app.UseAuthorization();
app.UseCors("MyPolicy");
app.MapControllers();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.Run();
