using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class DiceRoller : MonoBehaviour
{
    [SerializeField] private Button GirarDado;
    [SerializeField] private GameObject PainelResultado;
    [SerializeField] private TextMeshProUGUI TextoResultado;
    [SerializeField] private TextMeshProUGUI TextoBotao; // Novo: Texto dentro do botão


    public class Atributo
    {
        public string categoria;
        public string descricao;
    }

    public List<Atributo> todosAtributos = new List<Atributo>();
    public List<Atributo> atributosSorteados = new List<Atributo>();

    private bool podeRolar = true;
    private float tempoEspera = 300f; // 5 minutos em segundos
    private float tempoRestante = 0f;

    public void Awake()
    {
        GirarDado.onClick.AddListener(OnGirarDadoClick);
    }

    void Start()
    {
        InicializarAtributos();
        PainelResultado.SetActive(false);
    }

    private void OnGirarDadoClick()
    {
        if (podeRolar)
        {
            RolarDado();
            StartCoroutine(ContadorEspera());
        }
    }

    public void RolarDado()
    {
        atributosSorteados.Clear();
        PainelResultado.SetActive(true);

        int maxAtributos = Mathf.Min(todosAtributos.Count, 6);
        int quantidade = Random.Range(1, maxAtributos + 1);

        string texto = $"É possível modificar até <b>{quantidade}</b> atributos:\n\n";
        List<int> usados = new List<int>();

        int i = 0;
        while (i < quantidade)
        {
            int indice = Random.Range(0, todosAtributos.Count);

            if (usados.Contains(indice))
                continue;

            usados.Add(indice);
            var atributo = todosAtributos[indice];
            atributosSorteados.Add(atributo);

            if (atributo.categoria == "ENERGIA")
                texto += $"<color=red><b>{atributo.categoria}</b></color>: {atributo.descricao}\n\n";
            else if (atributo.categoria == "ÁGUA")
                texto += $"<color=blue><b>{atributo.categoria}</b></color>: {atributo.descricao}\n\n";

            i = i + 1;
        }

        TextoResultado.text = texto;
    }

    IEnumerator ContadorEspera()
    {
        podeRolar = false;
        GirarDado.interactable = false;
        tempoRestante = tempoEspera;

        while (tempoRestante > 0)
        {
            int minutos = Mathf.FloorToInt(tempoRestante / 60);
            int segundos = Mathf.FloorToInt(tempoRestante % 60);
            TextoBotao.text = $"Espere {minutos}:{segundos}";//Aguarde {minutos:D2}:{segundos:D2} ...
            tempoRestante -= Time.deltaTime;
            yield return null;
        }

        TextoBotao.text = "Girar Dado";
        podeRolar = true;
        GirarDado.interactable = true;
    }

    public void FecharPainel()
    {
        PainelResultado.SetActive(false);
    }

    public void InicializarAtributos()
    {
        todosAtributos = new List<Atributo>
        {
            new Atributo { categoria = "ENERGIA", descricao = "Medo do Escuro(Luzes acesas por muito tempo)!" },
            new Atributo { categoria = "ENERGIA", descricao = "Ar-condicionado e aquecedores elétricos" },
            new Atributo { categoria = "ENERGIA", descricao = "Uso frequente de eletrodomésticos de alta potência" },
            new Atributo { categoria = "ENERGIA", descricao = "Muitos equipamentos eletrônicos ligados ou em modo standby" },
            new Atributo { categoria = "ÁGUA", descricao = "Hora da Beleza(banhos demorados)!" },
            new Atributo { categoria = "ÁGUA", descricao = "Descargas frequentes, sem a necessidade!" },
            new Atributo { categoria = "ÁGUA", descricao = "Mania de Limpeza!(Uso excessido de torneiras e máquina de lavar)" },
            new Atributo { categoria = "ÁGUA", descricao = "Anda lavando demais sua calçada!" },
            new Atributo { categoria = "ÁGUA", descricao = "Torneiras Vazando!" }
        };
    }
}