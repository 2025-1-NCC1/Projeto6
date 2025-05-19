using UnityEngine;

public class Casa : MonoBehaviour
{
    public int idCasa; // Define qual índice da lista esta casa usa
    private House_Status houseInfo;

    void Start()
    {
        houseInfo = FindFirstObjectByType<House_Status>(); // Busca a referência global
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        // Lógica de quando a casa é clicada
        if (houseInfo != null && houseInfo.listaCasas.Count > idCasa)
        {
            Atributo dados = houseInfo.listaCasas[idCasa];
            // Debug 
            Debug.Log($"[Casa {idCasa + 1}] Energia: {dados.energia}, Água: {dados.agua}, Membros: {dados.membros}");
        }
    }
}


