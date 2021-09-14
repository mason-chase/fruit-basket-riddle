using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using Xunit;

namespace FruitBasketRiddle
{
    public class FruitBasketBddTest
    {
        [Fact]
        public void TestSuccess()
        {
            // Arrange: Create all possible combination to test our function
            // +--------+--------+--------+ 
            // |  Apple | Orange |   Mix  | 
            // +--------+--------+--------+
            // | Orange |   Mix  |  Apple | 
            // +--------+--------+--------+
            // |   Mix  |  Apple | Orange | 
            // +--------+--------+--------+
            IEnumerable<DataSet> datasets = DataSet.DataSets;
            
            foreach (DataSet dataset in datasets)
            {
                // Act A: Take item from a basket and ask function to provide a prediction
                FruitOptions fruit = dataset.Basket1.RevealContent();
                
                // Act B: Create a prediction based on the basket content
                CalculatedContent calculatedContent = BasketService.ProcessTakeItem(fruit);
                
                // Assert : Our calculated content must have correct value for all baskets
                Assert.True( dataset.Basket1.TestAnswer(calculatedContent.Basket1) );
                Assert.True( dataset.Basket1.TestAnswer(calculatedContent.Basket2) );
                Assert.True( dataset.Basket1.TestAnswer(calculatedContent.Basket3) );
            }
        }

        // Ensure our basket constructor follows rules of the game,
        // It is invalid to arrange a basket with  During 
        [Fact]
        public void BasketWithCorrectLabel()
        {
            Assert.Throws<InvalidLabelException>(() => new Basket(FruitOptions.Apple, FruitOptions.Apple));
        }
        
        #region Test Coverage (Ensure everything is in compliance)

        [Fact]
        public void DataSetWithDuplicateValues()
        {
            Assert.Throws<InvalidDataSetException>(() => new DataSet(
                    new Basket(FruitOptions.Apple, FruitOptions.Orange),
                    new Basket(FruitOptions.Apple, FruitOptions.Mixed),
                    new Basket(FruitOptions.Orange, FruitOptions.Mixed)
                ) 
            );
        }
        #endregion
    }
}
