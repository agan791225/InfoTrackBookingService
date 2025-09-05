using InfoTrackBookingService.IService;
using InfoTrackBookingService.Middleware;
using InfoTrackBookingService.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// DI
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddSingleton<IBookingRepository, InMemoryBookingRepository>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
