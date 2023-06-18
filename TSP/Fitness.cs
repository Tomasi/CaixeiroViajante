using System.Globalization;
using GeneticSharp;

namespace TSP
{

    public class Fitness : IFitness
    {
        public List<Cidade> Cidades { get; private set; }
        public decimal MinX { get; set; }
        public decimal MinY { get; set; }
        public decimal MaxX { get; set; }
        public decimal MaxY { get; set; }

        public Fitness(List<Cidade> cidades, int qtdCidades)
        {
            this.Cidades = new List<Cidade>(qtdCidades);
            MinX = cidades.Min(x => x.latitude);
            MinY = cidades.Min(x => x.longitude);
            MaxX = cidades.Max(x => x.latitude);
            MaxY = cidades.Min(x => x.longitude);

            if (MaxX >= int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(MaxX));
            }

            if (MaxY >= int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(MaxY));
            }

            for (int i = 0; i < qtdCidades; i++)
            {
                var city = new Cidade(cidades[i].Nome, cidades[i].latitude, cidades[i].longitude);
                this.Cidades.Add(city);
            }
        }

        public double Evaluate(IChromosome chromosome)
        {
            var genes = chromosome.GetGenes();
            var distanceSum = 0.0;
            var lastCityIndex = Convert.ToInt32(genes[0].Value, CultureInfo.InvariantCulture);
            var citiesIndexes = new List<int>
            {
                lastCityIndex
            };

            for (int i = 0, genesLength = genes.Length; i < genesLength; i++)
            {
                var currentCityIndex = Convert.ToInt32(genes[i].Value, CultureInfo.InvariantCulture);
                distanceSum += CalcDistanceTwoCities(Cidades[currentCityIndex], Cidades[lastCityIndex]);
                lastCityIndex = currentCityIndex;

                citiesIndexes.Add(lastCityIndex);
            }

            distanceSum += CalcDistanceTwoCities(Cidades[citiesIndexes.Last()], Cidades[citiesIndexes.First()]);

            var fitness = 1.0 - (distanceSum / (Cidades.Count * 1000.0));

            ((TspChromosome)chromosome).Distance = distanceSum;

            // There is repeated cities on the indexes?
            var diff = Cidades.Count - citiesIndexes.Distinct().Count();

            if (diff > 0)
            {
                fitness /= diff;
            }

            if (fitness < 0)
            {
                fitness = 0;
            }

            return fitness;
        }

        private static double CalcDistanceTwoCities(Cidade one, Cidade two)
        {
            return Math.Sqrt(Math.Pow((double)two.latitude - (double)one.latitude, 2) +
                             Math.Pow((double)two.longitude - (double)one.longitude, 2));
        }
    }

}