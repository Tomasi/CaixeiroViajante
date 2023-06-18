using System;
using GeneticSharp;

namespace TSP
{
    [Serializable]
    public class TspChromosome : ChromosomeBase
    {
        private readonly int m_numberOfCities;

        public TspChromosome(int numberOfCities) : base(numberOfCities)
        {
            m_numberOfCities = numberOfCities;

            // Create a list of city indexes excluding the index of Brasilia (0)
            var citiesIndexes = RandomizationProvider.Current.GetUniqueInts(numberOfCities - 1, 1, numberOfCities).ToList();

            citiesIndexes.Insert(0, 0);

            for (int i = 0; i < numberOfCities; i++)
            {
                ReplaceGene(i, new Gene(citiesIndexes[i]));
            }
        }

        public double Distance { get; internal set; }

        public override Gene GenerateGene(int geneIndex)
        {
            return new Gene(RandomizationProvider.Current.GetInt(1, m_numberOfCities));
        }

        public override IChromosome CreateNew()
        {
            return new TspChromosome(m_numberOfCities);
        }

        public override IChromosome Clone()
        {
            var clone = base.Clone() as TspChromosome;
            clone.Distance = Distance;
            return clone;
        }
    }
}