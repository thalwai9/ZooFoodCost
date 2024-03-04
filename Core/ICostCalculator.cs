using System.Collections.Generic;

namespace ZooFoodApi.Core
{
    public interface ICostCalculator
    {
        double CalculateTotalCost(double meatPrice, double fruitPrice, double totalMeatNeeded, double totalFruitNeeded);
    }
}
