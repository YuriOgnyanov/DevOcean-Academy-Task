using System;
using TaxCalculation.Core.Contract;
using TaxCalculation.IO;
using TaxCalculation.IO.Contracts;
using TaxCalculation.Models;
using TaxCalculation.Models.Contract;
using TaxCalculation.Utilities.Messages;

namespace TaxCalculation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
        }
        public void Run()
        {
            //Read from console
            string[] shipData = reader.ReadLine()
            .Split();

            int boughtYear;
            int milesTraveled;
            int YearTaxCalculation;
            
            bool boughtYearSuccess = int.TryParse(shipData[1], out boughtYear);
            bool milesTraveledSuccess = int.TryParse(shipData[2], out milesTraveled);
            bool YearTaxCalculationSuccess = int.TryParse(shipData[3], out YearTaxCalculation);

            if (!boughtYearSuccess || !milesTraveledSuccess || !YearTaxCalculationSuccess)
            {
                throw new FormatException(ExceptionMessages.InvalidParse);
            }

            //There are two types of spaceships – Cargo and Family
            if (shipData[0] == "Family")
            {
                FamilyModelCreation(boughtYear, milesTraveled, YearTaxCalculation);
            }
            else if (shipData[0] == "Cargo")
            {
                CargoModelCreation(boughtYear, milesTraveled, YearTaxCalculation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidShipType);
            }
        }

        private void CargoModelCreation(int boughtYear, int milesTraveled, int YearTaxCalculation)
        {
            IShip cargoShip = new Cargo(boughtYear, milesTraveled, YearTaxCalculation);

            cargoShip.LightMilesCalculation(milesTraveled);
            cargoShip.TaxCalculation(YearTaxCalculation);

            var shipType = cargoShip.GetType().Name;
            var taxResult = cargoShip.TotalTax();

            PrintTaxResult(shipType, taxResult);
        }

        private void PrintTaxResult(string shipType, int taxResult)
        {
            writer.WriteLine(string.Format(OutputMessages.TaxResult, shipType, taxResult));
        }

        private void FamilyModelCreation(int boughtYear, int milesTraveled, int YearTaxCalculation)
        {
            IShip familyShip = new Family(boughtYear, milesTraveled, YearTaxCalculation);

            familyShip.LightMilesCalculation(milesTraveled);
            familyShip.TaxCalculation(YearTaxCalculation);

            var shipType = familyShip.GetType().Name;
            var taxResult = familyShip.TotalTax();

            PrintTaxResult(shipType, taxResult);
        }
    }
}
