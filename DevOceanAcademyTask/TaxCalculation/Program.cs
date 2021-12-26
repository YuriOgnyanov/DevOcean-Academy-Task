using System;
using TaxCalculation.Core;
using TaxCalculation.Core.Contract;
using TaxCalculation.Models;
using TaxCalculation.Models.Contract;

namespace TaxCalculation
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
