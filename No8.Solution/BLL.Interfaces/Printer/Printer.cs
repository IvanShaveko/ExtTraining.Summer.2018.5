using System;
using System.IO;

namespace No8.Solution.BLL.Interfaces.Printer
{
    /*Абстракция для различных принтеров.
     Нужна для расширяемости кода, так как может добавиться новый принтер*/
    public abstract class Printer
    {
        public string Name { get; set; }
        public string Model { get; set; }

        protected Printer()
        {
        }

        protected Printer(string name, string model)
        {
            Name = name;
            Model = model;
        }

        /*Виртуальный так как, есть возможность переопределить, если будет другая печать*/
        public virtual void Print(FileStream fs)
        {
            for (var i = 0; i < fs.Length; i++)
            {
                Console.WriteLine(fs.ReadByte());
            }
        }
    }
}
