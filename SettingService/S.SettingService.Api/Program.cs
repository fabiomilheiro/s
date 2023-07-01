using S.SettingService.Api.Health;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks()
    .AddCheck<TestHealthCheck>("Test");
builder.Services.AddHttpClient();


var app = builder.Build();

app.MapGet("/", () => "setting service");
app.MapGet("/health", () => "Healthy");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // app.UseSwagger();
    // app.UseSwaggerUI();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.UsePathBase("/settingService");
app.UseRouting();
app.MapControllers();
app.UseHealthChecks("/health");

app.Run();