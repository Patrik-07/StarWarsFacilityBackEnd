using WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<JediFullStacAppDbContext>(options => 
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("JediFullStackConnectionString")
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Images")),
    RequestPath = "/images"
});

app.UseHttpsRedirection();

app.UseCors(policy => policy.WithOrigins("http://localhost:4200").AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
