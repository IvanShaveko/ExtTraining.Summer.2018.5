using System;
using System.Collections.Generic;
using No8.Solution.BLL.Interfaces.Printer;
using No8.Solution.DAL.Interfaces.Repository;

namespace No8.Solution.DAL.Repository
{

    /*Реализация репозитория на основе списка*/
    public class Repository : IRepository
    {
        private readonly List<Printer> _repository;

        public int Count => _repository.Count;

        public Repository()
        {
            _repository = new List<Printer>();
        }

        public void AddPrinter(Printer printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException($"{nameof(printer)} can not be null");
            }

            if (GetByNameAndModel(printer.Name, printer.Model) != null)
            {
                throw new ArgumentException($"{nameof(printer)} is already exist"); 
            }

            _repository.Add(printer);
        }

        public void RemovePrinter(Printer printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException($"{nameof(printer)} can not be null");
            }


            _repository.Remove(GetByNameAndModel(printer.Name, printer.Model));
        }
        
        public Printer GetByNameAndModel(string name, string model)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} can not be null");
            }

            if (string.IsNullOrEmpty(model))
            {
                throw new ArgumentException($"{nameof(model)} can not be null");
            }

            return _repository.Find(printer => name == printer.Name && model == printer.Model);
        }

        public IEnumerable<Printer> GetPrinters()
        {
            foreach (var item in _repository)
            {
                yield return item;
            }
        }
    }
}
