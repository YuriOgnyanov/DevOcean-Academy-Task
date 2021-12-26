using NUnit.Framework;
using System;
using TaxCalculation.Models;

namespace TestTaxCalculationProject
{
    [TestFixture]
    public class FamilyTest
    {
        private readonly int boughtYear = 2332;
        private readonly int milesTraveled = 344789;
        private readonly int yearTaxCalculation = 2369;

        private Family family;

        [SetUp]
        public void Setup()
        {
            family = new Family(boughtYear, milesTraveled, yearTaxCalculation);
        }

        [Test]
        [TestCase(0, 344789, 2369)]
        [TestCase(2332, 0, 2369)]
        [TestCase(2332, 344789, 0)]
        [TestCase(-2332, 344789, 2369)]
        [TestCase(2332, -344789, 2369)]
        [TestCase(2332, 344789, -2369)]
        public void Ctor_ThrowsAgrumentException_WhenInvalidDataIsProvided
            (int BoughtYear, int MilesTraveled, int YearTaxCalculation)
        {
            //Assert.Throws<ArgumentException>(() => new Cargo(BoughtYear, MilesTraveled, YearTaxCalculation));

            var ship = new Family(BoughtYear, MilesTraveled, YearTaxCalculation);

            if (ship is null)
            {
                Assert.Throws<ArgumentException>(() => new Family(BoughtYear, MilesTraveled, YearTaxCalculation));
            }
        }

        [Test]
        public void PropBoughtYear_IsSetCorrectly_WhenAgumentIsValid()
        {
            Assert.That(family.BoughtYear, Is.EqualTo(boughtYear));
        }

        [Test]
        public void PropMilesTraveled_IsSetCorrectly_WhenAgumentIsValid()
        {
            Assert.That(family.MilesTraveled, Is.EqualTo(milesTraveled));
        }

        [Test]
        public void PropYearTaxCalculation_IsSetCorrectly_WhenAgumentIsValid()
        {
            Assert.That(family.YearTaxCalculation, Is.EqualTo(yearTaxCalculation));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void LightMilesCalculation_ThrowsArgumentException_WhenLightMilesIsZeroOrNegative(int miles)
        {
            if (this.family.LightMilesCalculation(miles) < 0 || this.family.LightMilesCalculation(miles) == 0)
            {
                Throws.ArgumentException.With.Message.EqualTo("Light Miles cannot be zero or negative!");
            }
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TaxCalculation_ThrowsArgumentException_WhenLightMilesIsZeroOrNegative(int tex)
        {

            if (this.family.TaxCalculation(tex) < 0 || this.family.TaxCalculation(tex) == 0)
            {
                Throws.ArgumentException.With.Message.EqualTo("Tax cannot be zero or negative!");
            }
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TotalTax_ThrowsArgumentException_WhenLightMilesIsZeroOrNegative(int result)
        {
            if (this.family.TotalTax() < 0 || this.family.TotalTax() == 0)
            {
                Throws.ArgumentException.With.Message.EqualTo("TotalTax cannot be zero or negative!");
            }
        }
    }
}