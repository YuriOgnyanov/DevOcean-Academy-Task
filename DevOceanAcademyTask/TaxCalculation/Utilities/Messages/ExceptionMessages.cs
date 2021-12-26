using System;

namespace TaxCalculation.Utilities.Messages
{
    public class ExceptionMessages : Exception
    {
        public const string InvalidShipType = "The name cannot be different of Family or Cargo.";
        public const string InvalidParse = "Failed to parse to an integer.";
    }
}
