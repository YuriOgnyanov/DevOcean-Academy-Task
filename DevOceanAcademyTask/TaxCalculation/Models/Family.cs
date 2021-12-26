using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculation.Models.Contract;

namespace TaxCalculation.Models
{
    public class Family : IShip
    {
        private const int InitialTax = 5000;
        private const int DefaultTaxIncreases = 100;
        private const int DefaultTaxDeclines = 355;
        public Family(int boughtYear, int milesTraveled, int yearTaxCalculation)
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
            //for every 1_000 light miles traveled, the tax increases by 100 DVS
            int counter = 0;
            for (int i = 1000; i < miles; i+=1000)
            {
                counter++;
            }

            var taxMilesResult = counter * DefaultTaxIncreases;

            return taxMilesResult;
        }

        public int TaxCalculation(int tex)
        {
            //Declines every year by 355 DVS
            var years = tex - this.BoughtYear;

            var taxDiscount = years * DefaultTaxDeclines;

            return taxDiscount;
        }

        public int TotalTax()
        {
            //Example: Family spaceship bought in 2300 has traveled 2_344 light miles, so in 2307 owes:
            //5_000 + 2 * 100 - 7 * 355
            var lightResult = LightMilesCalculation(MilesTraveled);
            var taxtResult = TaxCalculation(YearTaxCalculation);
            
            var totalResult = InitialTax + lightResult - taxtResult;

            return totalResult;
        }
    }
}
