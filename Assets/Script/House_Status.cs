using UnityEngine;

public class HouseInfo : MonoBehaviour
{   // Var teste 
    public float energia = 120.5f; 
    public float agua = 250.75f; 
    public int numero_casa = 1;
    public int membros = 3;

    void OnMouseDown()
    {
        MostrarInfo();
    }

    void MostrarInfo()
    {
        Debug.Log($"Casa n° {numero_casa} selecionada!\nEnergia: {energia} kWh\nÁgua: {agua} L\n Memrbros da Família: {membros} pessoas.");
    }
}