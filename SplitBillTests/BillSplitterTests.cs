using System;
using System.Collections.Generic;
using Xunit;
using SplitBillLibrary;

namespace SplitBillTests
{
    public class BillSplitterTests
    {
        [Fact]
        public void SplitBill_DividesAmountEquallyAmongPeople()
        {
            // Arrange
            var billSplitter = new BillSplitter();

            // Act
            var result = billSplitter.SplitBill(100m, 4);

            // Assert
            Assert.Equal(25m, result);
        }

        [Fact]
        public void CalculateTipPerPerson_CalculatesCorrectTip()
        {
            // Arrange
            var billSplitter = new BillSplitter();

            // Act
            var result = billSplitter.CalculateTipPerPerson(100m, 4, 20f);

            // Assert
            Assert.Equal(5m, result);
        }

        [Fact]
        public void CalculateIndividualTips_CalculatesCorrectTipForEachPerson()
        {
            // Arrange
            var billSplitter = new BillSplitter();
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Alice", 25m },
                { "Bob", 30m },
                { "Charlie", 45m }
            };

            // Act
            var result = billSplitter.CalculateIndividualTips(mealCosts, 20f);

            // Assert
            Assert.Equal(5m, result["Alice"]);
            Assert.Equal(6m, result["Bob"]);
            Assert.Equal(9m, result["Charlie"]);
        }

        // Additional tests to cover edge cases and other scenarios
        [Fact]
        public void SplitBill_ThrowsExceptionForZeroPeople()
        {
            // Arrange
            var billSplitter = new BillSplitter();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => billSplitter.SplitBill(100m, 0));
        }

        [Fact]
        public void CalculateTipPerPerson_ThrowsExceptionForZeroPeople()
        {
            // Arrange
            var billSplitter = new BillSplitter();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => billSplitter.CalculateTipPerPerson(100m, 0, 20f));
        }

        [Fact]
        public void CalculateIndividualTips_ThrowsExceptionForNegativeTipPercentage()
        {
            // Arrange
            var billSplitter = new BillSplitter();
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Alice", 25m },
                { "Bob", 30m },
                { "Charlie", 45m }
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => billSplitter.CalculateIndividualTips(mealCosts, -20f));
        }
    }
}
