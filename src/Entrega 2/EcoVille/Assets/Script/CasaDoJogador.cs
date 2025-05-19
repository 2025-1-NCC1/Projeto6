using UnityEngine;

public class CasaDoJogador : MonoBehaviour
{
    [SerializeField] private GameObject casaJogador;
    [SerializeField] private Color corSelecionada = Color.yellow;

    private Renderer rend;
    private Color corOriginal;
    private bool foiSelecionada = false;

    void Start()
    {
        if (casaJogador != null)
        {
            rend = casaJogador.GetComponent<Renderer>();
            corOriginal = rend.material.color;
        }
        else
        {
            Debug.LogError("⚠️ Nenhuma casa do jogador foi atribuída!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !foiSelecionada)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == casaJogador)
                {
                    SelecionarCasa();
                }
            }
        }
    }

    void SelecionarCasa()
    {
        rend.material.color = corSelecionada;
        foiSelecionada = true;

        Debug.Log("✅ Casa do jogador selecionada: " + casaJogador.name);
    }
}
