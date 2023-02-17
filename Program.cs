
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCorePractice;

var builder = Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((context, configuration) =>
{
    configuration
    .AddJsonFile("appsettings.json", optional: true)
    .AddEnvironmentVariables(); //добавление в конфигурацию переменных окружения
});

//добавляем сервисы
builder.ConfigureServices(services =>
{
    services.AddSingleton<IPrintService, ConsolePrinterService>();
    services.AddSingleton<PrintWorker>();
});

//cоздаем host
using IHost host = builder.Build();

PrintWorker? worker = host.Services.GetService<PrintWorker>();
worker?.Work();
