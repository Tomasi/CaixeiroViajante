﻿using GeneticSharp;
using OfficeOpenXml;
using Genetico;

string filePath = "Coordenadas.xlsx";

using (var package = new ExcelPackage(new FileInfo(filePath)))
{
    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

    int rowCount = worksheet.Dimension.Rows;
    int colCount = worksheet.Dimension.Columns;

    List<Cidade> cidades = new List<Cidade> { };

    for (int row = 1; row <= rowCount; row++)
    {

        string nomeCidade = "";
        decimal latitude = 0;
        decimal longitude = 0;

        for (int col = 1; col <= colCount; col++)
        {

            string? cellValue = worksheet.Cells[row, col].Value?.ToString();

            if (col == 1 && cellValue != "" && cellValue != null)
            {
                nomeCidade = cellValue;
            }
            else if (col == 2 && cellValue != "" && cellValue != null)
            {
                decimal.TryParse(cellValue, out latitude);
            }
            else if (col == 3 && cellValue != "" && cellValue != null)
            {
                decimal.TryParse(cellValue, out longitude);
            }

        }

        if (!String.IsNullOrWhiteSpace(nomeCidade))
        {
            Cidade cidade = new Cidade(nomeCidade, latitude, longitude);
            cidades.Add(cidade);
        }

    }

    var selection = new EliteSelection();
    var crossover = new UniformCrossover(1.0f);
    var mutation = new UniformMutation(false);
    int numberOfCities = cidades.Count;
    Fitness fitness = new Fitness(cidades, numberOfCities);
    TspChromosome tspChromosome = new TspChromosome(numberOfCities);

    var population = new Population(50, 100, tspChromosome);

    var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
    ga.Termination = new FitnessStagnationTermination(100);
    // ga.GenerationRan += (s, e) => Console.WriteLine($"Generation {ga.GenerationsNumber}. Best fitness: {ga.BestChromosome.Fitness.Value}");

    Console.WriteLine("GA running...");
    ga.Start();

    Console.WriteLine();
    Console.WriteLine($"Melhor solução encontrada algotimo genético: {ga.BestChromosome.Fitness}");
    Console.WriteLine($"Tempo de execução algoritmo genético: {ga.TimeEvolving}");
    Console.WriteLine($"Número de gerações {ga.GenerationsNumber}");

    TabuSearch.TabuSearch tabuSearch = new TabuSearch.TabuSearch(cidades);

    var bestSolution = ga.BestChromosome;
    var genes = bestSolution.GetGenes();
    List<Cidade> bestRoute = new List<Cidade>();
    List<Cidade> buscaTabu = tabuSearch.Search();

    foreach (var gene in genes)
    {
        int cityIndex = Convert.ToInt32(gene.Value);
        Cidade city = fitness.Cidades[cityIndex];
        bestRoute.Add(city);
    }

    Console.WriteLine();
    Console.WriteLine("A melhor rota calculada para o caixeiro viajante usando o algoritmo genético é: ");

    for (int i = 0; i < bestRoute.Count; i++)
    {
        Console.WriteLine($"{i + 1}: {bestRoute[i].Nome} - latitude {bestRoute[i].latitude} - longitude {bestRoute[i].longitude}");
    }

    Console.WriteLine();
    Console.WriteLine($"Tempo de execução da busca tabu: {tabuSearch.TempoDeExecucao}");
    Console.WriteLine("A melhor rota calculada para o caixeiro viajante usando a busca tabu é: ");

    for (int i = 0; i < buscaTabu.Count; i++)
    {
        Console.WriteLine($"{i + 1}: {buscaTabu[i].Nome} - latitude {buscaTabu[i].latitude} - longitude {buscaTabu[i].longitude}");
    }
}
