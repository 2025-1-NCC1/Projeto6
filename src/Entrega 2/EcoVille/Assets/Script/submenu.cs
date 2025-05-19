using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class submenu : MonoBehaviour
{
    [SerializeField] private GameObject botoes;
    [SerializeField] private GameObject menuJogando;
    [SerializeField] private GameObject menuPausado;
    [SerializeField] private GameObject Ranking;
    [SerializeField] private GameObject Opcoes;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject tutorialp1;
    [SerializeField] private GameObject tutorialp2;
    [SerializeField] private GameObject sairJogo;
    [SerializeField] private string nomeDoLevel;
    [SerializeField] private string Fim;
    public void paused()
    {
        Time.timeScale = 0f;
        menuPausado.SetActive(true);
        menuJogando.SetActive(false);
        botoes.SetActive(false);
    }

    public void jogando()
    {
        Time.timeScale = 1.0f;
        menuJogando.SetActive(true);
        menuPausado.SetActive(false);
        botoes.SetActive(true);
    }

    public void ranking()
    {
        Ranking.SetActive(true);
    }

    public void back()
    {
        Ranking.SetActive(false);
    }

    public void abrirOpcoes()
    {
        Opcoes.SetActive(true);
        menuPausado.SetActive(false);
    }

    public void fecharOpcoes()
    {
        Opcoes.SetActive(false);
        menuPausado.SetActive(true);
    }

    public void abriTuto()
    {
        tutorial.SetActive(true);
        tutorialp1 .SetActive(true);
        tutorialp2 .SetActive(false);
        menuPausado .SetActive(false);
    }

    public void abrirtuto2()
    {
        tutorialp2.SetActive(true);
        tutorialp1 .SetActive(false);
    }

    public void abritTuto1()
    {
        tutorialp2.SetActive(false);
        tutorialp1 .SetActive(true);
    }

    public void sairTuto()
    {
        tutorial.SetActive(false);
        menuPausado .SetActive(true);
    }

    public void menu() 
    {
        SceneManager.LoadScene(nomeDoLevel);
    }
    public void fim()
    {
        SceneManager.LoadScene(Fim);
    }
}
