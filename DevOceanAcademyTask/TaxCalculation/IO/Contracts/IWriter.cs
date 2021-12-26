using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculation.IO.Contracts
{
    public interface IWriter
    {
        void WriteLine(string message);
    }
}
