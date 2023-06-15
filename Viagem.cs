internal class Viagem
{

    public Viagem(string cidadeOrigem, string cidadesDestino, decimal distancia)
    {
        this.CidadeOrigem = cidadeOrigem;
        this.CidadeDestino = cidadesDestino;
        this.Distancia = distancia;
    }

    public string CidadeOrigem { get; }
    public string CidadeDestino { get; }
    public decimal Distancia { get; }

}