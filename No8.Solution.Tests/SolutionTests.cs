using System.ComponentModel.Design;
using No8.Solution.BLL.Interfaces.Printer;
using No8.Solution.BLL.Service;
using No8.Solution.DAL.Interfaces.DTO;
using No8.Solution.DAL.Repository;
using NUnit.Framework;

namespace No8.Solution.Tests
{
    [TestFixture]
    public class SolutionTests
    {
        private readonly Service service = new Service(new Repository());

        [Test]
        public void Add()
        {
            service.AddPrinter("Epson", "1234");
            Assert.AreEqual(service.Count, 1);
        }

        [Test]
        public void AddSeveral()
        {
            service.AddPrinter("Epson", "1234567");
            service.AddPrinter("Canon", "13");

            Assert.AreEqual(service.Count, 3);
        }

        [Test]
        public void Remove()
        {
            service.RemovePrinter("Epson", "1234567");

            Assert.AreEqual(service.Count, 2);
        }

        [Test]
        public void GetByNameAndModel()
        {
            Printer printer = service.GetByNameAndModel("Epson", "1234");

            Assert.AreEqual(printer.Name, "Epson");
            Assert.AreEqual(printer.Model, "1234");
        }
    }
}
