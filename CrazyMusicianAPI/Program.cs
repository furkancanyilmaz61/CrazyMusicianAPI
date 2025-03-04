var builder = WebApplication.CreateBuilder(args);

// ? Controllers'� kullanmak i�in gerekli servisleri ekle
builder.Services.AddControllers();

// ? Swagger UI deste�i ekleyelim (API'yi test etmek i�in)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ? Geli�tirme ortam�nda Swagger kullan
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ? Routing, Authentication ve Authorization i�lemlerini ba�lat
app.UseRouting();
app.UseAuthorization();

// ? Controllers'� API olarak kullan (Minimal API yerine klasik y�ntem)
app.MapControllers();

app.Run();
