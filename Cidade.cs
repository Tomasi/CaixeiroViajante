public class Cidade
{

    public Cidade(string nome, decimal latitude, decimal longitude)
    {
        this.Nome = nome;
        this.latitude = latitude;
        this.longitude = longitude;
    }

    public string Nome { get; }
    public decimal latitude { get; }
    public decimal longitude { get; }

}
