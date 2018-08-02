namespace No8.Solution.BLL.Interfaces.Printer
{
    public class EpsonPrinter : Printer
    {
        public EpsonPrinter(string model) : base("Epson", model)
        {
        }
    }
}
