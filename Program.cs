using GeneticSharp;
using OfficeOpenXml;
using TSP;

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

        Cidade cidade = new Cidade(nomeCidade, latitude, longitude);
        cidades.Add(cidade);
    }

    var selection = new EliteSelection();
    var crossover = new UniformCrossover();
    var mutation = new UniformMutation(true);
    int numberOfCities = cidades.Count;
    Fitness fitness = new Fitness(cidades, numberOfCities);
    TspChromosome tspChromosome = new TspChromosome(numberOfCities);

    var population = new Population(50, 70, tspChromosome);

    var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
    ga.Termination = new FitnessStagnationTermination(100);
    ga.GenerationRan += (s, e) => Console.WriteLine($"Generation {ga.GenerationsNumber}. Best fitness: {ga.BestChromosome.Fitness.Value}");

    Console.WriteLine("GA running...");
    ga.Start();

    Console.WriteLine();
    Console.WriteLine($"Best solution found has fitness: {ga.BestChromosome.Fitness}");
    Console.WriteLine($"Elapsed time: {ga.TimeEvolving}");

    var bestSolution = ga.BestChromosome;
    var genes = bestSolution.GetGenes();
    List<Cidade> bestRoute = new List<Cidade>();

    foreach (var gene in genes)
    {
        int cityIndex = Convert.ToInt32(gene.Value);
        Cidade city = fitness.Cidades[cityIndex];
        bestRoute.Add(city);
    }

    Console.WriteLine();
    Console.WriteLine("A melhor rota calculada para o caixeiro viajante é: ");
    bestRoute.ForEach(x => Console.WriteLine($"{x.Nome}"));
}
