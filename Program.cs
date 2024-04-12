using Microsoft.EntityFrameworkCore;
using saudesuicidio.Context;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigin = "_myAllowSpecificOrigin";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.
UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options => {
    options.AddPolicy(MyAllowSpecificOrigin, policy=>{
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors(MyAllowSpecificOrigin);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
