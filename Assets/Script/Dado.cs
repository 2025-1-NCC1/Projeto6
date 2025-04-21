using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dado : MonoBehaviour
{
    void OnMouseDown()
    {
        RolarDadoAtributos();
    }


    void RolarDadoAtributos()
    {
        int atributosModificaveis = Random.Range(0, 4); // Gera de 0 até 3 (4 exclusivo)

        Debug.Log("Dado rolado! O dono da casa poderá modificar " + atributosModificaveis +
                  (atributosModificaveis == 1 ? " atributo." : " atributos."));

        // Exemplo opcional: mostrar quais atributos podem ser modificados
        List<string> todosAtributos = new List<string> { "Água", "Energia", "Pessoas" };
        List<string> atributosSelecionados = new List<string>();

        while (atributosSelecionados.Count < atributosModificaveis)
        {
            string atributo = todosAtributos[Random.Range(0, todosAtributos.Count)];
            if (!atributosSelecionados.Contains(atributo))
            {
                atributosSelecionados.Add(atributo);
            }
        }

        if (atributosSelecionados.Count > 0)
        {
            Debug.Log("Atributos que poderão ser modificados: " + string.Join(", ", atributosSelecionados));
        }
        else
        {
            Debug.Log("Nenhum atributo poderá ser modificado desta vez.");
        }
    }
}