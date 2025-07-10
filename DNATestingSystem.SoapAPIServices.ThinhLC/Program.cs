using DNATestingSystem.Services.ThinhLC;
using DNATestingSystem.SoapAPIServices.ThinhLC.SoapServices;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServiceProviders, ServiceProviders>();
builder.Services.AddScoped<ISampleThinhLCSoapService, SampleThinhLCSoapService>();
builder.Services.AddScoped<ISampleTypeThinhLCService, SampleTypeThinhLCService>();
builder.Services.AddScoped<ISampleTypeThinhLCSoapService, SampleTypeThinhLCSoapService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSoapEndpoint<ISampleThinhLCSoapService>("/SampleThinhLCSoapService.asmx", new SoapEncoderOptions());
app.UseSoapEndpoint<ISampleTypeThinhLCSoapService>("/SampleTypeThinhLCSoapService.asmx", new SoapEncoderOptions());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
