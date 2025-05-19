[System.Serializable]
public class Atributo
{
    public float energia;
    public float agua;
    public int membros;
    public float consumoTotal;
    public int numeroDaCasa;

    public Atributo(float energia, float agua, int membros, float consumoTotal, int numeroDaCasa)
    {
        this.energia = energia;
        this.agua = agua;
        this.membros = membros;
        this.consumoTotal = consumoTotal;
        this.numeroDaCasa = numeroDaCasa;
    }
}
