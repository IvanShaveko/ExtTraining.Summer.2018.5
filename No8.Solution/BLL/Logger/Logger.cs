using System.IO;

namespace No8.Solution.BLL.Logger
{
    public static class Logger
    {
        public static void Log(string s)
        {
            File.AppendText("log.txt").Write(s);
        }

        public static void OnPrinted(object sender, PrintEventArgs eventArgs)
        {
            Log(eventArgs.Message);
        }
    }
}
