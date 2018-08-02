using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.BLL.Service;
using No8.Solution.DAL.Repository;

namespace No8.Solution.Console
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var service = new Service(new Repository());
            int i;
            do
            {
                System.Console.WriteLine("Menu:");
                System.Console.WriteLine("1) Add printer");
                System.Console.WriteLine("2) Print");
                System.Console.WriteLine("3) Exit");
                i = int.Parse(System.Console.ReadLine());
                switch (i)
                {
                    case 1:
                        AddToRepository(service);
                        break;
                    case 2:
                        Print(service);
                        break;
                    case 3:
                        System.Console.WriteLine("Are you sure?");
                        break;
                    default:
                        System.Console.WriteLine("You write another. Write again");
                        break;
                }
                System.Console.ReadLine();
                System.Console.Clear();
            }
            while (i != 3);
        }

        static void AddToRepository(Service service)
        {

            System.Console.WriteLine("Name of printer");
            string name = System.Console.ReadLine();
            System.Console.WriteLine("Name of model");
            string model = System.Console.ReadLine();
            service.AddPrinter(name, model);
        }

        static void Print(Service service)
        { 

            System.Console.WriteLine("Name of printer");
            string name = System.Console.ReadLine();
            System.Console.WriteLine("Name of model");
            string model = System.Console.ReadLine();
            service.AddPrinter(name, model);
        }
    }
}
