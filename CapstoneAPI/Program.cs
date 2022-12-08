global using CapstoneAPI.Data;
global using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var CORSPolicy = "CORSPolicy";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORSPolicy,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyMethod().SetIsOriginAllowed(origin => true).AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(CORSPolicy);

app.MapControllers();

app.Run();
