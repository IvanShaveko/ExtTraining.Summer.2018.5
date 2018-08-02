using System.Collections.Generic;
using No8.Solution.BLL.Interfaces.Printer;

namespace No8.Solution.DAL.Interfaces.Repository
{
    /*Абстракция для репозитория
     Нужна для расширяемости, если надо будет добавить новый репозиторий или сменить старый, не удаляя логику 
     старого*/
    public interface IRepository
    {
        void AddPrinter(Printer printerDto);

        void RemovePrinter(Printer printerDto);

        Printer GetByNameAndModel(string name, string model);

        IEnumerable<Printer> GetPrinters();

        int Count { get; }
    }
}
