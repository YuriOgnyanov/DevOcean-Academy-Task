using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculation.IO.Contracts;

namespace TaxCalculation.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
