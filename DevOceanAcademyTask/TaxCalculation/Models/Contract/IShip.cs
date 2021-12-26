using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculation.Models.Contract
{
    public interface IShip
    {
        int BoughtYear { get; }
        int MilesTraveled { get; }

        int YearTaxCalculation { get; }
        int LightMilesCalculation(int miles);
        int TaxCalculation(int tex);

        int TotalTax();
    }
}
