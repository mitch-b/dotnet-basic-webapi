using BasicWebApi.Endpoints;
using BasicWebApi.Filters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;

const string allowAnyCorsPolicy = "allowAnyCorsPolicy";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
// builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
    opt.AddPolicy(name: allowAnyCorsPolicy, p =>
    {
        p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }));

builder.Services.AddHttpContextAccessor();

// Configure JSON logging to the console.
builder.Logging.AddJsonConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
app.UseHttpsRedirection();

app.UseCors();

// app.UseAuthentication();
// app.UseAuthorization();

var all = app.MapGroup("")
    .AddEndpointFilter<ExceptionFilter>()
    .WithOpenApi();

all.MapGroup("/host-info")
    .MapHostInfoApi()
    //.RequireAuthorization()
    .WithTags("Public");

app.MapGet("/demo", () => "demo endpoint works")
    .WithTags("Demo");

await app.RunAsync();
