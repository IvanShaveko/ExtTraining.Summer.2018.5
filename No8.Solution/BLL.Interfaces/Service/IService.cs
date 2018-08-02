using System.Collections.Generic;

namespace No8.Solution.BLL.Interfaces.Service
{
    /*Абстракция для сервиса*/
    public interface IService
    {
        void AddPrinter(string name, string model);

        void RemovePrinter(string name, string model);

        void Print(string name, string model);

        Printer.Printer GetByNameAndModel(string name, string model);

        IEnumerable<Printer.Printer> GetPrinters();
    }
}
