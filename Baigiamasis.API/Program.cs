using Baigiamasis.Core.Contracts.IRepository;
using Baigiamasis.Core.Contracts.IServices;
using Baigiamasis.Core.Repository;
using Baigiamasis.Core.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string serverPath = "Server=localhost;Database=Baigiamasis;Trusted_Connection=True;TrustServerCertificate=true;";

builder.Services.AddTransient<IBookRepository, BookRepository>(x => new BookRepository(serverPath));
builder.Services.AddTransient<IBookService, BookService>();

builder.Services.AddTransient<IRentalRepository, RentalRepository>(x => new RentalRepository(serverPath));
builder.Services.AddTransient<IRentalService, RentalService>();

builder.Services.AddTransient<IUserRepository, UserRepository>(x => new UserRepository(serverPath));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var log = new LoggerConfiguration().MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/LibraryOperations.txt", rollingInterval: RollingInterval.Day).CreateLogger();
Log.Logger = log;

app.Run();
