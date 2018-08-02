using System;
using No8.Solution.BLL.Interfaces.Printer;

namespace No8.Solution.BLL.Service
{
    public class CreatePrinter 
    {
        /*Класс для создания принтера по имени
         нужен для того, чтобы мы могли создавать нужный вид принтера из сервиса*/
        public static Printer Create(string name, string model)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} can not be null");
            }

            if (string.IsNullOrEmpty(model))
            {
                throw new ArgumentException($"{nameof(model)} can not be null");
            }

            /*Не лучшее решение. Лучшим решением является фабрика*/
            switch (name)
            {
                case "Canon":
                    return new CanonPrinter(model);
                case "Epson":
                    return new EpsonPrinter(model);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
