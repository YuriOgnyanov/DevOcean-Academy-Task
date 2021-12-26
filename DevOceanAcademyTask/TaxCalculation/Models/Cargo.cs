using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculation.Models.Contract;

namespace TaxCalculation.Models
{
    public class Cargo : IShip
    {
        private const int InitialTax = 10000;
        private const int DefaultTaxIncreases = 1000;
        private const int DefaultTaxDeclines = 736;
        public Cargo(int boughtYear, int milesTraveled, int yearTaxCalculation)
        {
            this.BoughtYear = boughtYear;
            this.MilesTraveled = milesTraveled;
            this.YearTaxCalculation = yearTaxCalculation;
        }
        public int BoughtYear { get; }

        public int MilesTraveled { get; }

        public int YearTaxCalculation { get; }

        public int LightMilesCalculation(int miles)
        {
            //For every 1_000 light miles traveled, the tax increases by 1_000 DVS
            int counter = 0;
            for (int i = 1000; i < miles; i += 1000)
            {
                counter++;
            }

            var taxMilesResult = counter * DefaultTaxIncreases;

            return taxMilesResult;
        }

        public int TaxCalculation(int tex)
        {
            //Declines every year by 736 DVS
            var years = tex - this.BoughtYear;

            var taxDiscount = years * DefaultTaxDeclines;

            return taxDiscount;
        }

        public int TotalTax()
        {
            //Example: Cargo spaceship bought in 2332 has traveled 344_789 light miles, so in 2369 owes:
            //10_000 + 344 * 1_000 - (2369 - 2332) * 736
            var lightResult = LightMilesCalculation(MilesTraveled);
            var taxtResult = TaxCalculation(YearTaxCalculation);

            var totalResult = InitialTax + lightResult - taxtResult;
            
            return totalResult;
        }
    }
}
