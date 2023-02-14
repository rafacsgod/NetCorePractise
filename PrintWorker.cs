using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCorePractice
{
    class PrintWorker
    {
        private IPrintService _printer;
        private ILogger _logger;
        private IConfiguration _config;


        //внедрение зависимостей через конструктор класса
        public PrintWorker(IPrintService printer, ILogger<PrintWorker> logger, IConfiguration config)
        {
            _printer = printer;
            _logger = logger;
            _config = config;
        }

        public void Work()
        {
            int n = _config.GetValue<int>("NetCorePractise:TimesToPrint");

            for (int i = 1; i <= n; ++i)
            {
                _printer.Print(i);
                _logger.LogInformation($"Напечатана цифра: {i}");
            }
        }
    }
}
