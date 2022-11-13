using BasicWebApi.Endpoints;
using BasicWebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

// Configure JSON logging to the console.
builder.Logging.AddJsonConsole();

Console.WriteLine($"Application Name: {builder.Environment.ApplicationName}");
Console.WriteLine($"Environment Name: {builder.Environment.EnvironmentName}");
Console.WriteLine($"ContentRoot Path: {builder.Environment.ContentRootPath}");
Console.WriteLine($"WebRootPath: {builder.Environment.WebRootPath}");

var app = builder.Build();

// app.UseCors();
// app.UseAuthentication();
// app.UseAuthorization();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

var all = app.MapGroup("")
    .AddEndpointFilter<ExceptionFilter>()
    .WithOpenApi();

all.MapGroup("/info")
    .MapHostInfoApi()
    .WithTags("Public");

app.Run();
