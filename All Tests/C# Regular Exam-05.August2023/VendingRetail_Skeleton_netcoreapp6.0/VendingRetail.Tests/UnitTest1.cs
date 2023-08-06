using NUnit.Framework;
using VendingRetail;

namespace VendingRetail.Tests
{
    public class CoffeeMatTests
    {
        private CoffeeMat coffeeMat;

        [SetUp]
        public void Setup()
        {
            this.coffeeMat = new CoffeeMat(1000, 5);
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            Assert.AreEqual(1000, this.coffeeMat.WaterCapacity);
            Assert.AreEqual(5, this.coffeeMat.ButtonsCount);
        }

        [Test]
        public void FillWaterTank_ShouldIncreaseWaterTankLevel()
        {
            var result = this.coffeeMat.FillWaterTank();
            Assert.AreEqual("Water tank is filled with 1000ml", result);
        }

        [Test]
        public void FillWaterTank_ShouldReturnMessageWhenTankIsFull()
        {
            this.coffeeMat.FillWaterTank();
            var result = this.coffeeMat.FillWaterTank();
            Assert.AreEqual("Water tank is already full!", result);
        }

        [Test]
        public void AddDrink_ShouldAddDrinkSuccessfully()
        {
            var result = this.coffeeMat.AddDrink("Coffee", 2.5);
            Assert.IsTrue(result);
        }

        [Test]
        public void AddDrink_ShouldNotAddDrinkWhenButtonsCountIsExceeded()
        {
            for (int i = 0; i < 5; i++)
            {
                this.coffeeMat.AddDrink($"Drink{i}", 2.5);
            }

            var result = this.coffeeMat.AddDrink("Coffee", 2.5);
            Assert.IsFalse(result);
        }

        [Test]
        public void AddDrink_ShouldNotAddDrinkWhenDrinkWithSameNameExists()
        {
            this.coffeeMat.AddDrink("Coffee", 2.5);
            var result = this.coffeeMat.AddDrink("Coffee", 3.0);
            Assert.IsFalse(result);
        }

        [Test]
        public void BuyDrink_ShouldDecreaseWaterTankLevelAndIncreaseIncome()
        {
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.AddDrink("Coffee", 2.5);
            var result = this.coffeeMat.BuyDrink("Coffee");
            Assert.AreEqual("Your bill is 2.50$", result);
        }

        [Test]
        public void BuyDrink_ShouldReturnMessageWhenDrinkIsNotAvailable()
        {
            this.coffeeMat.FillWaterTank();
            var result = this.coffeeMat.BuyDrink("Coffee");
            Assert.AreEqual("Coffee is not available!", result);
        }

        [Test]
        public void BuyDrink_ShouldReturnMessageWhenWaterTankLevelIsLessThan80()
        {
            this.coffeeMat.AddDrink("Coffee", 2.5);
            var result = this.coffeeMat.BuyDrink("Coffee");
            Assert.AreEqual("CoffeeMat is out of water!", result);
        }

        [Test]
        public void CollectIncome_ShouldResetIncome()
        {
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.AddDrink("Coffee", 2.5);
            this.coffeeMat.BuyDrink("Coffee");
            var collectedIncome = this.coffeeMat.CollectIncome();
            Assert.AreEqual(2.5, collectedIncome);
        }

        [Test]
        public void CollectIncome_ShouldReturnZeroWhenThereIsNoIncome()
        {
            var collectedIncome = this.coffeeMat.CollectIncome();
            Assert.AreEqual(0, collectedIncome);
        }
        [Test]
        public void BuyDrink_ShouldReturnMessageWhenDrinkIsNotAvailableAndWaterTankIsFull()
        {
            this.coffeeMat.FillWaterTank();
            var result = this.coffeeMat.BuyDrink("Tea");
            Assert.AreEqual("Tea is not available!", result);
        }

        [Test]
        public void BuyDrink_ShouldReturnMessageWhenWaterTankIsEmptyAndDrinkIsAvailable()
        {
            this.coffeeMat.AddDrink("Coffee", 2.5);
            var result = this.coffeeMat.BuyDrink("Coffee");
            Assert.AreEqual("CoffeeMat is out of water!", result);
        }

        [Test]
        public void AddDrink_ShouldNotAddDrinkWithSameNameButDifferentPrice()
        {
            this.coffeeMat.AddDrink("Coffee", 2.5);
            var result = this.coffeeMat.AddDrink("Coffee", 3.0);
            Assert.IsFalse(result);
        }

        [Test]
        public void FillWaterTank_ShouldFillWaterTankCorrectlyWhenPartiallyFilled()
        {
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.AddDrink("Coffee", 2.5);
            this.coffeeMat.BuyDrink("Coffee"); 
            var result = this.coffeeMat.FillWaterTank();
            Assert.AreEqual("Water tank is filled with 80ml", result);
        }


        [Test]
        public void CollectIncome_ShouldResetIncomeEvenIfNoSales()
        {
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.AddDrink("Coffee", 2.5);
            this.coffeeMat.CollectIncome();
            var collectedIncome = this.coffeeMat.Income;
            Assert.AreEqual(0, collectedIncome);
        }

        [Test]
        public void BuyDrink_ShouldReturnMessageWhenWaterTankIsNotFullEnough()
        {
            this.coffeeMat.AddDrink("Coffee", 2.5);
            var result = this.coffeeMat.BuyDrink("Coffee");
            Assert.AreEqual("CoffeeMat is out of water!", result);
        }

        [Test]
        public void BuyDrink_ShouldDecreaseWaterTankLevelCorrectly()
        {
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.AddDrink("Coffee", 2.5);
            this.coffeeMat.BuyDrink("Coffee");
            var result = this.coffeeMat.FillWaterTank();
            Assert.AreEqual("Water tank is filled with 80ml", result);
        }

        [Test]
        public void BuyDrink_ShouldIncreaseIncomeCorrectly()
        {
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.AddDrink("Coffee", 2.5);
            this.coffeeMat.BuyDrink("Coffee");
            Assert.AreEqual(2.5, this.coffeeMat.Income);
        }
        [Test]
        public void BuyDrink_ShouldReturnMessageWhenDrinkNotAdded()
        {
            this.coffeeMat.FillWaterTank();
            var result = this.coffeeMat.BuyDrink("Tea");
            Assert.AreEqual("Tea is not available!", result);
        }


        [Test]
        public void BuyDrink_ShouldReturnMessageWhenWaterTankIsEmpty()
        {
            this.coffeeMat.AddDrink("Coffee", 2.5);
            var result = this.coffeeMat.BuyDrink("Coffee");
            Assert.AreEqual("CoffeeMat is out of water!", result);
        }

        [Test]
        public void BuyDrink_ShouldIncreaseIncomeCorrectlyWhenBoughtMultipleTimes()
        {
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.AddDrink("Coffee", 2.5);
            this.coffeeMat.BuyDrink("Coffee");
            this.coffeeMat.BuyDrink("Coffee");
            Assert.AreEqual(5.0, this.coffeeMat.Income);
        }

        [Test]
        public void CollectIncome_ShouldReturnTotalIncomeWhenDrinkBoughtMultipleTimes()
        {
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.AddDrink("Coffee", 2.5);
            this.coffeeMat.BuyDrink("Coffee");
            this.coffeeMat.BuyDrink("Coffee");
            var collectedIncome = this.coffeeMat.CollectIncome();
            Assert.AreEqual(5.0, collectedIncome);
        }

        [Test]
        public void BuyDrink_ShouldReturnMessageWhenDrinkNameIsEmpty()
        {
            this.coffeeMat.FillWaterTank();
            var result = this.coffeeMat.BuyDrink("");
            Assert.AreEqual(" is not available!", result);
        }

        [Test]
        public void BuyDrink_ShouldDecreaseWaterTankLevelCorrectlyWhenBoughtMultipleTimes()
        {
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.AddDrink("Coffee", 2.5);
            this.coffeeMat.BuyDrink("Coffee");
            this.coffeeMat.BuyDrink("Coffee");
            var result = this.coffeeMat.FillWaterTank();
            Assert.AreEqual("Water tank is filled with 160ml", result);
        }

        [Test]
        public void FillWaterTank_ShouldFillWaterTankCorrectlyWhenPartiallyFilledMultipleTimes()
        {
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.AddDrink("Coffee", 2.5);
            this.coffeeMat.BuyDrink("Coffee");
            this.coffeeMat.BuyDrink("Coffee");
            var result = this.coffeeMat.FillWaterTank();
            Assert.AreEqual("Water tank is filled with 160ml", result);
        }
        [Test]
        public void BuyDrink_ShouldReturnMessageWhenDrinkNameIsWhitespace()
        {
            this.coffeeMat.FillWaterTank();
            var result = this.coffeeMat.BuyDrink(" ");
            Assert.AreEqual("  is not available!", result);
        }

        [Test]
        public void BuyDrink_ShouldDecreaseWaterTankLevelToZeroWhenBoughtUntilEmpty()
        {
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.AddDrink("Coffee", 2.5);
            for (int i = 0; i < 12; i++)
            {
                this.coffeeMat.BuyDrink("Coffee");
            }
            var result = this.coffeeMat.BuyDrink("Coffee");
            Assert.AreEqual("CoffeeMat is out of water!", result);
        }

        [Test]
        public void FillWaterTank_ShouldFillWaterTankCorrectlyWhenEmptiedMultipleTimes()
        {
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.AddDrink("Coffee", 2.5);
            for (int i = 0; i < 12; i++)
            {
                this.coffeeMat.BuyDrink("Coffee");
            }
            var result = this.coffeeMat.FillWaterTank();
            Assert.AreEqual("Water tank is filled with 960ml", result);
        }
        [Test]
        public void BuyDrink_ShouldReturnMessageWhenDrinkNameDoesNotExist()
        {
            this.coffeeMat.FillWaterTank();
            var result = this.coffeeMat.BuyDrink("NonExistingDrink");
            Assert.AreEqual("NonExistingDrink is not available!", result);
        }

        [Test]
        public void FillWaterTank_ShouldFillWaterTankCorrectlyWhenEmptiedAndPartiallyFilledMultipleTimes()
        {
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.AddDrink("Coffee", 2.5);
            for (int i = 0; i < 12; i++)
            {
                this.coffeeMat.BuyDrink("Coffee");
            }
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.BuyDrink("Coffee");
            var result = this.coffeeMat.FillWaterTank();
            Assert.AreEqual("Water tank is filled with 80ml", result);
        }
        
        [Test]
        public void FillWaterTank_ShouldNotOverfillWaterTank()
        {
            this.coffeeMat.FillWaterTank();
            var result = this.coffeeMat.FillWaterTank();
            Assert.AreEqual("Water tank is already full!", result);
        }
    }
}
