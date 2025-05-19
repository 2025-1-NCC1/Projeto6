using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Jogador : MonoBehaviour
{
    [Header("Informações da Casa")]
    public float energia; // kWh
    public int numeroDePessoas;
    public float agua; // litros
    public float consumoMedio;
    [SerializeField] private GameObject painelAlvo;
    //public string painelAtributosTexto;

    [Header("Referências da UI")]
    [SerializeField] private TextMeshProUGUI painelAtributosTexto; // Texto onde será exibido os atributos
    [SerializeField] private TextMeshProUGUI energiaText;
    [SerializeField] private TextMeshProUGUI aguaText;
    [SerializeField] private TextMeshProUGUI pessoasText;
    [SerializeField] private TextMeshProUGUI consumoText;
    
    [SerializeField] private GameObject painelAtributosUI; // Painel pai para mostrar/ocultar


    [Header("Atributos que o jogador pode modificar")]
    [SerializeField] public List<AtributoJogador> atributosModificaveis = new List<AtributoJogador>();

    void Start()
    {
        GerarStatusInicial();
        AtualizarUI();
    }

    public void AlternarPainel()
    {
        if (painelAlvo != null)
        {
            bool ativo = painelAlvo.activeSelf;
            painelAlvo.SetActive(!ativo);
        }
    }

    public void GerarStatusInicial()
    {
        energia = Random.Range(100f, 300f);
        agua = Random.Range(5000f, 15000f);
        numeroDePessoas = Random.Range(1, 6);
        consumoMedio = (energia + agua) / 2f;
    }

    public void AtualizarConsumo(float novaEnergia, float novaAgua)
    {
        energia = novaEnergia;
        agua = novaAgua;
        consumoMedio = (energia + agua) / 2f;
        AtualizarUI();
    }

    public void DefinirAtributosModificaveis(List<AtributoJogador> novosAtributos)
    {
        atributosModificaveis.Clear();
        atributosModificaveis.AddRange(novosAtributos);
    }

    public void AtualizarUI()
    {
        if (energiaText != null) energiaText.text = $"Energia: {energia:F1} kWh";
        if (aguaText != null) aguaText.text = $"Água: {agua:F0} L";
        if (pessoasText != null) pessoasText.text = $"Pessoas: {numeroDePessoas}";
        if (consumoText != null) consumoText.text = $"Consumo Médio: {consumoMedio:F1}";
        MostrarAtributosModificaveis();
    }

    public void MostrarAtributosModificaveis()
    {
        if (painelAtributosTexto == null || painelAtributosUI == null) return;

        if (atributosModificaveis.Count == 0)
        {
            painelAtributosTexto.text = "Nenhum atributo para modificar.";
        }
        else
        {
            string texto = "<b>Atributos Modificáveis:</b>\n\n";
            foreach (var atributo in atributosModificaveis)
            {
                string cor = atributo.categoria == "ENERGIA" ? "red" :
                            atributo.categoria == "ÁGUA" ? "blue" : "white";
                texto += $"<color={cor}><b>{atributo.categoria}</b></color>: {atributo.descricao}\n\n";
            }

            painelAtributosTexto.text = texto;
        }

        painelAtributosUI.SetActive(true); // Exibe o painel
    }
}

[System.Serializable]
public class AtributoJogador
{
    public string categoria;
    public string descricao;
}