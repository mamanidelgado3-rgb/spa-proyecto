using Microsoft.EntityFrameworkCore;
using Spa.Api.Data;
using Spa.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SpaDbContext>(o =>
    o.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.Configure<WhatsAppOptions>(builder.Configuration.GetSection("WhatsApp"));
builder.Services.Configure<AiOptions>(builder.Configuration.GetSection("Ai"));
builder.Services.Configure<PaymentOptions>(builder.Configuration.GetSection("Payment"));
builder.Services.AddHttpClient();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<WhatsAppService>();
builder.Services.AddScoped<AiAssistantService>();
builder.Services.AddScoped<PaymentService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddPolicy("web", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SpaDbContext>();
    db.Database.EnsureCreated();
    SeedData.Run(db);
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("web");
app.MapControllers();
app.Run();
