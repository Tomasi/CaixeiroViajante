using OfficeOpenXml;

string filePath = "Viagens.xlsx";

using (var package = new ExcelPackage(new FileInfo(filePath)))
{
    ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Definindo o contexto de licença
    ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Seleciona a primeira planilha

    int rowCount = worksheet.Dimension.Rows;
    int colCount = worksheet.Dimension.Columns;

    List<Viagem> viagens = new List<Viagem> { };
    List<string> cidadesDestino = new List<string> { };

    for (int row = 1; row <= rowCount; row++)
    {

        string cidadeOrigem = "";

        for (int col = 1; col <= colCount; col++)
        {

            string? cellValue = worksheet.Cells[row, col].Value?.ToString();

            if (row == 1)
            {

                if (cellValue != "" && cellValue != null)
                {
                    cidadesDestino.Add(cellValue);
                }
                else
                {
                    cidadesDestino.Add(string.Empty);
                }

                continue;
            }

            string cidadeDestino = cidadesDestino[col - 1];
            decimal distancia = 0;

            if (col == 1 && cellValue != "" && cellValue != null)
            {
                cidadeOrigem = cellValue;
                continue;
            }
            else
            {
                decimal.TryParse(cellValue, out distancia);
            }

            Viagem viagem = new Viagem(cidadeOrigem, cidadeDestino, distancia);
            viagens.Add(viagem);
        }

    }

    viagens.ForEach(x => Console.WriteLine($"Viagem de {x.CidadeOrigem} para {x.CidadeDestino} com distância {x.Distancia}"));

}
