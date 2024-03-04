namespace ZooFoodApi.Core
{
    public class CostCalculator : ICostCalculator
    {
        public double CalculateTotalCost(double meatPrice, double fruitPrice, double totalMeatNeeded, double totalFruitNeeded)
        {
            return (meatPrice * totalMeatNeeded) + (fruitPrice * totalFruitNeeded);
        }
    }
}
