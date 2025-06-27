using Paymob.Services.Payment;
using Paymob.Services.Paymob.Egy.v1;
using Paymob.Services.Paymob.Egy.v2;
using Paymob.Services.Paymob.Uae;
using Paymob.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPaymobEgy1Service, PaymobEgy1Service>();
builder.Services.AddScoped<IPaymobEgy2Service, PaymobEgy2Service>();
builder.Services.AddScoped<IPaymobUaeService, PaymobUaeService>();

builder.Services.Configure<PaymentSettings>(builder.Configuration.GetSection(nameof(PaymentSettings)));
builder.Services.Configure<PaymobEgy1Settings>(builder.Configuration.GetSection(nameof(PaymobEgy1Settings)));
builder.Services.Configure<PaymobEgy2Settings>(builder.Configuration.GetSection(nameof(PaymobEgy2Settings)));
builder.Services.Configure<PaymobUaeSettings>(builder.Configuration.GetSection(nameof(PaymobUaeSettings)));


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
