using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculation.IO.Contracts;

namespace TaxCalculation.IO
{
    public class Writer : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
