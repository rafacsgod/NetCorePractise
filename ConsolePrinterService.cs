using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCorePractice
{
    //реализация сервиса
    class ConsolePrinterService : IPrintService
    {
        public void Print(int n)
        {
            Console.WriteLine(n);
        }
    }
}
