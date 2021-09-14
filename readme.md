# Fruit Test

There are 3 baskets labeled ‘Apples’, ‘Oranges’ & ‘Mixture’. One of them contains only Apples, one only Oranges and  one has mix of apples and oranges both.
These baskets are not labeled correctly. In fact, the labels on these baskets always lie. (i.e. if the label says Oranges, Then you are sure the basket either has only Apples or Mixture).
You are allowed to pick one fruit from one basket (Not allowed to see other fruits), and you have to put all the labels correctly on the basis of that information (by seeing only one fruit from any one basket).
How will you do that ?

[Reference](https://www.ritambhara.in/3-basket-puzzle-appleorange-puzzle/)


|  🍎 Apple 	| 🍊Orange 	    |   🍎 Mix 🍊 	|
|:------:	    |:------:	    |:------:	    |
| 🍊 Orange 	|  🍎 Mix 🍊 	|  🍎 Apple 	|
|  🍎  Mix 🍊  	|  🍎 Apple 	| 🍊 Orange   	|


Below is my BDD Approach before solving the issue
```C#
// Arrange: Create all possible combination to test our function
DataSet[] datasets = DataSet.Generate();

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
```


Solution to solve the riddle:
```C#
BasketService.ProcessTakeItem(fruit);
```

You are here, maybe because you have an interview question,
buy me a coffee if you like this.
