using System;

namespace FruitBasketRiddle
{
    /// <summary>
    /// Static service that guesses what is the content of other two basket based on
    /// the content of the first basket. 
    /// </summary>
    public static class BasketService
    {
        /// <summary>
        /// We will receive content and make our guess revealed
        /// </summary>
        /// <param name="fruit"></param>
        /// <exception cref="NotImplementedException"></exception>
        public static CalculatedContent ProcessTakeItem(FruitOptions fruit)
        {
            throw new NotImplementedException();
        }
    }

    public class CalculatedContent
    {
        public CalculatedContent(FruitOptions basket1, FruitOptions basket2, FruitOptions basket3)
        {
            Basket1 = basket1;
            Basket2 = basket2;
            Basket3 = basket3;
        }
        public FruitOptions Basket1 { get; }
        public FruitOptions Basket2 { get; }
        public FruitOptions Basket3 { get; }
    }

    /// <summary>
    /// DataSet assumes Basket1, Basket2 and Basket3 are unique with mislabeled basket.
    /// </summary>
    public class DataSet
    {
        public Basket Basket1 { get; }
        public Basket Basket2 { get; }
        public Basket Basket3 { get; }

        public static DataSet[] Generate()
        {
            return new DataSet[]
            {
            }
        }
    }

    /// <summary>
    /// Because Basket containment must be unique during data set generation, inherits IEquatable because
    /// </summary>
    public class Basket : IEquatable<Basket>
    {
        public Basket(FruitOptions content, FruitOptions label)
        {
            if (content == label)
                throw new InvalidLabelException(label);

            Content = content;
            Label = label;
        }


        /// <summary>
        /// Fruit type must be secret, therefore private
        /// </summary>
        private FruitOptions Content { get; }

        public FruitOptions Label { get; }

        /// <summary>
        /// Test if calculated value is correct.
        /// </summary>
        /// <param name="testValue"></param>
        /// <returns></returns>
        public bool TestAnswer(FruitOptions testValue)
        {
            return testValue == Content.Value;
        }

        /// <summary>
        /// Without revealing content it ensures it is not duplicate
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Basket other)
        {
            return other.TestAnswer(Content);
        }

        /// <summary>
        /// User is only allowed to r only run
        /// </summary>
        /// <returns></returns>
        public FruitOptions RevealContent() => Content;
    }

    public struct Fruit
    {
        public Fruit(FruitOptions options)
        {
            Value = options;
        }

        public FruitOptions Value { get; init; }
    }

    public enum FruitOptions
    {
        Apple,
        Orange,
        Mixed
    }


    public class InvalidLabelException : Exception
    {
        public InvalidLabelException(FruitOptions labelValue) :
            base("Duh! Basket's label must not match content " + labelValue.ToString())
        {
            LabelValue = labelValue;
        }

        public FruitOptions LabelValue { get; }
    }
}