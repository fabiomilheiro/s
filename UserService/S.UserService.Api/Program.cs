using S.UserService.Api.Health;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = Environment.GetEnvironmentVariable("environment"),
    ContentRootPath = Directory.GetCurrentDirectory(),
    Args = args,
});
var environmentName = builder.Environment.EnvironmentName;
Console.WriteLine($"builder.Environment.WebRootPath: {builder.Environment.WebRootPath}");
Console.WriteLine($"builder.Environment.ContentRootPath: {builder.Environment.ContentRootPath}");
Console.WriteLine($"typeof(Program).Assembly.Location: {typeof(Program).Assembly.Location}");

// TODO: Encapsulate logic in S.Shared project.
// TODO: appSettings.json and appSettings.local.json should also be in the shared location, no?
builder.Configuration
    .AddJsonFile("appSettings.json")
    .AddJsonFile($"appSettings.{environmentName}.json")
    .AddJsonFile(Path.Combine(builder.Environment.ContentRootPath, "..", "S.UserService.Shared", "sharedAppSettings.json"), true)
    .AddJsonFile("sharedAppSettings.json")
    .AddEnvironmentVariables();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks()
    .AddCheck<TestHealthCheck>("Test");
builder.Services.AddHttpClient();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/health", () => "Healthy");

if (app.Environment.IsEnvironment("local"))
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

app.UsePathBase("/userService");
app.UseRouting();
app.MapControllers();
app.UseHealthChecks("/health");

app.Run();