using Microsoft.AspNetCore.Mvc;
using ZooFoodApi.Core;

namespace ZooFoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZooCostController : ControllerBase
    {

        private readonly IDataReader _dataReader;
        private readonly ICostCalculator _costCalculator;

        public ZooCostController(IDataReader dataReader, ICostCalculator costCalculator)
        {
            _dataReader = dataReader;
            _costCalculator = costCalculator;
        }

        [HttpGet]
        public IActionResult GetTotalCost()
        {
            string pricesFilePath = "prices.txt";
            string animalsFilePath = "animals.csv";
            string zooFilePath = "zoo.xml";

            (double meatPrice, double fruitPrice) = _dataReader.ReadPrices(pricesFilePath);
            var animalRates = _dataReader.ReadAnimalRates(animalsFilePath);
            var animalWeights = _dataReader.ReadAnimalWeights(zooFilePath);

            (double totalMeatNeeded, double totalFruitNeeded) = CalculateFoodNeeded(animalWeights, animalRates);

            double totalCost = _costCalculator.CalculateTotalCost(meatPrice, fruitPrice, totalMeatNeeded, totalFruitNeeded);

            return Ok(new { TotalCost = totalCost });
        }

        public static (double, double) CalculateFoodNeeded(Dictionary<string, double> animalWeights, Dictionary<string, (double, string, double?)> animalRates)
        {
            double totalMeatNeeded = 0;
            double totalFruitNeeded = 0;
            foreach (var kvp in animalWeights)
            {
                string[] animalInfo = kvp.Key.Split(' ');
                string animalType = animalInfo[0];
                double animalWeight = kvp.Value;
                (double rate, string foodType, double? meatPercentage) = animalRates[animalType];
                double foodNeeded = rate * animalWeight;
                if (foodType == "meat")
                    totalMeatNeeded += foodNeeded;
                else if (foodType == "fruit")
                    totalFruitNeeded += foodNeeded;
                else // omnivore
                {
                    if (meatPercentage != null)
                    {
                        totalMeatNeeded += foodNeeded * meatPercentage.Value;
                        totalFruitNeeded += foodNeeded * (1 - meatPercentage.Value);
                    }
                }
            }
            return (totalMeatNeeded, totalFruitNeeded);
        }
    }
}
