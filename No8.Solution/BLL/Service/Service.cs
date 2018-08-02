using System;
using System.IO;
using System.Windows.Forms;
using No8.Solution.BLL.Interfaces.Printer;
using No8.Solution.BLL.Interfaces.Service;
using No8.Solution.DAL.Interfaces.Repository;

namespace No8.Solution.BLL.Service
{
    using Logger;

    /*Выделил сервис для работы с репозиторием и принтером не напрямую*/
    public class Service : IService
    {
        private readonly IRepository _repository;

        public int Count => _repository.Count;

        public event EventHandler<PrintEventArgs> Printed = Logger.OnPrinted;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public void AddPrinter(string name, string model)
        {
            Printer printer = CreatePrinter.Create(name, model);

            _repository.AddPrinter(printer);
        }

        public void RemovePrinter(string name, string model)
        {
            Printer printer = CreatePrinter.Create(name, model);

            _repository.RemovePrinter(printer);
        }

        public void Print(string name, string model)
        {
            Printer printer = _repository.GetByNameAndModel(name, model);

            if (printer == null)
            {
                throw new ArgumentNullException($"This {nameof(printer)} does not exist");
            }

            OnPrinted(this, new PrintEventArgs("Print started"));
            Print(printer);
            OnPrinted(this, new PrintEventArgs("Print finished"));
        }

        public Printer GetByNameAndModel(string name, string model)
        {
            return _repository.GetByNameAndModel(name, model);
        }

        protected virtual void OnPrinted(object sender, PrintEventArgs eventArgs)
        {
            EventHandler<PrintEventArgs> tmp = Printed;
            tmp?.Invoke(this, eventArgs);
        }

        private static void Print(Printer printer)
        {
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);
            printer.Print(f);
        }
    }
}
