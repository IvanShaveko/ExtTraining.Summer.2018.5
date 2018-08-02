using System;

namespace No8.Solution.BLL
{
    public sealed class PrintEventArgs : EventArgs
    {
        public PrintEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
