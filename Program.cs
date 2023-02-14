
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCorePractice;

var builder = Host.CreateDefaultBuilder(args);

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
