using Newtonsoft.Json;
using System.Diagnostics;
using System.Dynamic;
using WebApiAsService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddWindowsService();
builder.Services.AddHostedService<ServiceTest>();

// Dependence appsettings.json
var path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule!.FileName);
Directory.SetCurrentDirectory(path!);
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true);
IConfigurationSection identifierAppSettings = builder.Configuration
    .AddEnvironmentVariables()
    .Build()
    .GetSection("Identifier");
if (string.IsNullOrEmpty(identifierAppSettings.Value))
{
    string nameFile = "appsettings.json";
    var json = File.ReadAllText(nameFile);

    dynamic appSettings = JsonConvert.DeserializeObject<ExpandoObject>(json)!;
    appSettings.Identifier = Guid.NewGuid().ToString();

    var newJson = JsonConvert.SerializeObject(appSettings, Formatting.Indented);
    File.WriteAllText(nameFile, newJson);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
