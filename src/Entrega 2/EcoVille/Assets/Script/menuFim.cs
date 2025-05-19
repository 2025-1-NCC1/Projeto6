using UnityEngine;
using UnityEngine.SceneManagement;
public class menuFim : MonoBehaviour
{

    [SerializeField] private GameObject Integrantes;
    [SerializeField] private GameObject p1;
    [SerializeField] private GameObject p2;
    [SerializeField] private GameObject p3;
    [SerializeField] private GameObject p4;
    [SerializeField] private GameObject p5;
    [SerializeField] private string nomeDoLevel;

    public void abrirPr()
    {
        Integrantes.SetActive(true);
        p1.SetActive(true); 
        p2.SetActive(false);
        p3.SetActive(false);
        p4.SetActive(false);
        p5.SetActive(false);
    }

    public void p1p2()
    {
        p1.SetActive(false);
        p2.SetActive(true);
    }

    public void p2p1()
    {
        p1.SetActive(true);
        p2.SetActive(false);
    }

    public void p2p3()
    {
        p2.SetActive(false);
        p3.SetActive(true);
    }
    public void p3p2()
    {
        p2.SetActive(true);
        p3.SetActive(false);
    }
    public void p3p4()
    {
        p3.SetActive(false );
        p4.SetActive(true);
    }
    public void p4p3()
    {
        p3.SetActive(true);
        p4.SetActive(false);
    }
    public void p4p5()
    {
        p5.SetActive(true);
        p4.SetActive (false);

    }
    public void p5p4()
    {
        p4.SetActive(true);
        p5.SetActive(false);
    }
    public void sairPro()
    {
        Integrantes.SetActive(false);
    }
    public void voltarMenu()
    {
        SceneManager.LoadScene(nomeDoLevel);
    }
    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
