var builder = WebApplication.CreateBuilder(args);

// ? Controllers'ý kullanmak için gerekli servisleri ekle
builder.Services.AddControllers();

// ? Swagger UI desteði ekleyelim (API'yi test etmek için)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ? Geliþtirme ortamýnda Swagger kullan
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ? Routing, Authentication ve Authorization iþlemlerini baþlat
app.UseRouting();
app.UseAuthorization();

// ? Controllers'ý API olarak kullan (Minimal API yerine klasik yöntem)
app.MapControllers();

app.Run();
