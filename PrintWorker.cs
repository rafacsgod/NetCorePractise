using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;

namespace NetCorePractice
{
    class PrintWorker
    {
        private readonly IPrintService _printer;
        private readonly IConfiguration _config;

        //внедрение зависимостей через конструктор класса
        public PrintWorker(IPrintService printer, IConfiguration config)
        {
            _printer = printer;
            _config = config;
        }

        public void Work()
        {
            //конфигурирование логгера
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            //считывание переменной окружения PROPERTY1 из конфигурации
            int n = _config.GetValue<int>("PROPERTY1");


            for (int i = 1; i <= n; ++i)
            {
                _printer.Print(i);
                Log.Information($"Напечатана цифра: {i}");
            }
        }
    }
}
