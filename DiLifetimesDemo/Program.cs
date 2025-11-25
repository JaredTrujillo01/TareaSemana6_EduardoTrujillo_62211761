using DiLifetimesDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro corregido: registra los tipos concretos para permitir inyección directa
builder.Services.AddTransient<TransientServices>();
builder.Services.AddScoped<ScopedServices>();
builder.Services.AddSingleton<SingletonServices>();

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
app.Run();