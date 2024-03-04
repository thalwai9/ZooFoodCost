namespace ZooFoodApi.Core
{
    public interface IDataReader
    {
        (double, double) ReadPrices(string filePath);
        Dictionary<string, (double, string, double?)> ReadAnimalRates(string filePath);
        Dictionary<string, double> ReadAnimalWeights(string filePath);
    }

}
