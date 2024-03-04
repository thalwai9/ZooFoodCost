using System;
using System.Collections.Generic;
using System.Xml;

namespace ZooFoodApi.Core
{
    public class DataReader : IDataReader
    {
        public Dictionary<string, (double, string, double?)> ReadAnimalRates(string filePath)
        {
            Dictionary<string, (double, string, double?)> animalRates = new Dictionary<string, (double, string, double?)>();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                string animal = parts[0];
                double rate = double.Parse(parts[1]);
                string foodType = parts[2];
                double? meatPercentage = null;
                if (parts.Length > 3 && parts[3].EndsWith("%"))
                {
                    meatPercentage = double.Parse(parts[3].Trim('%')) / 100;
                }
                animalRates.Add(animal, (rate, foodType, meatPercentage));
            }
            return animalRates;
        }

        public Dictionary<string, double> ReadAnimalWeights(string filePath)
        {
            Dictionary<string, double> animalWeights = new Dictionary<string, double>();
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNodeList animalNodes = doc.DocumentElement.SelectNodes("//Zoo/*/*");
            foreach (XmlNode animalNode in animalNodes)
            {
                string animalType = animalNode.ParentNode.Name;
                string animalName = animalNode.Attributes["name"].Value;
                double animalWeight = double.Parse(animalNode.Attributes["kg"].Value);
                string animalKey = $"{animalType} {animalName}";
                animalWeights.Add(animalKey, animalWeight);
            }
            return animalWeights;

        }

        public (double, double) ReadPrices(string filePath)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            double meatPrice = double.Parse(lines[0].Split('=')[1]);
            double fruitPrice = double.Parse(lines[1].Split('=')[1]);
            return (meatPrice, fruitPrice);
        }
    }
}
