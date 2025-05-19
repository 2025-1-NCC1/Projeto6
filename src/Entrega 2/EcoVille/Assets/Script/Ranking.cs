using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Ranking : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ranking;
    [SerializeField] private House_Status houseInfo; // NPCs
    [SerializeField] private Jogador jogador;        // Jogador principal

    void Update()
    {
        ListaRanking();
    }

    void ListaRanking()
    {   
        /* Verifica se houseInfo, listaCasas ou jogador são nulos
        Se algum deles for nulo, não faz nada */
        if (houseInfo == null || houseInfo.listaCasas == null || jogador == null)
            return;

        // Cria uma lista temporária com todos os NPCs
        List<Atributo> listaTemporaria = new List<Atributo>(houseInfo.listaCasas);

        // Ordena a lista do maior para o menor consumo
        listaTemporaria.Sort((a, b) => a.consumoTotal.CompareTo(b.consumoTotal));

        Atributo jogadorComoCasa = new Atributo
        (
            jogador.energia,
            jogador.agua,
            jogador.numeroDePessoas,
            jogador.consumoMedio,
            -1 // -1 para indicar que é o jogador
        );

        // Adiciona o jogador à lista temporária
        listaTemporaria.Add(jogadorComoCasa);

        // Criando uma variável vazioa para armazenar o texto do rankeamento
        string textoFinal = "";
        
        
        /* Atribuindo o i (indice) a 0 para percorrer todos os elementos da lista
           Iterando para cada loop i = i + 1 para acessar o proximo
           .Count para saber a quantiadade de casas */ 
        for (int i = 0; i < listaTemporaria.Count; i = i + 1)
        {   
            
            //Acessando a lista temporária e atribuindo o valor a variável casa
            var casa = listaTemporaria[i];

            // Caso o numero da casa seja -1, significa que é o jogador
            if (casa.numeroDaCasa == -1)
            {
                textoFinal += $"\n {i + 1}° -> <color=yellow> <b>[ VOCÊ ]</b> - Média p/ consumo: {casa.consumoTotal:F1}</color>\n";
            }
            // Caso contrário, é um NPC
            else
            {
                textoFinal += $"\n{i + 1}° -> [ Casa {casa.numeroDaCasa} ] - Média p/ consumo: {casa.consumoTotal:F1}\n";
            }
        }

        // Atualiza o texto do ranking
        ranking.text = textoFinal;
    }
}
