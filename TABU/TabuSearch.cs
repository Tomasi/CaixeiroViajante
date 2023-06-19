using System;
using System.Collections.Generic;
using System.Linq;

namespace TabuSearch
{
    public class TabuSearch
    {
        private const int TabuSize = 17;
        private const int MaxIterations = 100;

        public TimeSpan TempoDeExecucao;

        private List<Cidade> tabuList;
        private List<Cidade> cities;

        public TabuSearch(List<Cidade> cities)
        {
            tabuList = new List<Cidade>();
            this.cities = cities;
        }

        public List<Cidade> Search()
        {
            DateTime inicial = DateTime.Now;
            DateTime final;
            List<Cidade> bestSolution = new List<Cidade>(cities);
            try
            {

                for (int i = 0; i < MaxIterations; i++)
                {
                    List<Cidade> currentSolution = GetBestNeighbor(bestSolution);

                    if (CalculateTotalDistance(currentSolution) < CalculateTotalDistance(bestSolution))
                    {
                        bestSolution = currentSolution;
                    }

                    tabuList.Add(currentSolution.Last());

                    if (tabuList.Count > TabuSize)
                    {
                        tabuList.RemoveAt(0);
                    }
                }

            }
            finally
            {
                final = DateTime.Now;
            }

            this.TempoDeExecucao = final.TimeOfDay - inicial.TimeOfDay;

            return bestSolution;
        }

        private List<Cidade> GetBestNeighbor(List<Cidade> solution)
        {
            List<Cidade> bestNeighbor = null;
            double bestNeighborDistance = double.MaxValue;

            foreach (Cidade city in solution)
            {
                List<Cidade> neighbor = new List<Cidade>(solution);
                neighbor.Remove(city);
                neighbor.Add(city);

                double distance = CalculateTotalDistance(neighbor);

                if (!IsTabu(neighbor) && distance < bestNeighborDistance)
                {
                    bestNeighbor = neighbor;
                    bestNeighborDistance = distance;
                }
            }

            return bestNeighbor;
        }

        private bool IsTabu(List<Cidade> solution)
        {
            return tabuList.Contains(solution.Last());
        }

        private double CalculateDistance(Cidade city1, Cidade city2)
        {
            double lat1 = (double)city1.latitude;
            double lon1 = (double)city1.longitude;
            double lat2 = (double)city2.latitude;
            double lon2 = (double)city2.longitude;

            double r = 6371; // Earth's radius in kilometers

            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return r * c;
        }

        private double CalculateTotalDistance(List<Cidade> solution)
        {
            double totalDistance = 0;

            for (int i = 0; i < solution.Count - 1; i++)
            {
                totalDistance += CalculateDistance(solution[i], solution[i + 1]);
            }

            totalDistance += CalculateDistance(solution.Last(), solution.First());

            return totalDistance;
        }

        private double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }


}