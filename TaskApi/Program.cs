using TaskApi.Repositories;
using TaskApi.Services;

var builder = WebApplication.CreateBuilder(args);

// ѕодключаем контроллеры
builder.Services.AddControllers();

// DI: регистрируем репозиторий и сервис
builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

// Swagger (оставл€ем включенным дл€ удобства теста)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
