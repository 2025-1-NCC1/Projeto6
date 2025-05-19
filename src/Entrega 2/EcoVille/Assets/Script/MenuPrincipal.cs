using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject MenuPrincipalInicial;
    [SerializeField] private GameObject Opcoes;
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject Integrantes;
    public void Jogar()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void AbrirOpcoes()
    {
        MenuPrincipalInicial.SetActive(false);
        Opcoes.SetActive(true);
    }
    
    public void FecharOpcoes()
    {
        MenuPrincipalInicial.SetActive(true);
        Opcoes.SetActive(false);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

    public void AbrirInter()
    {
        MenuPrincipalInicial.SetActive(false);
        Integrantes.SetActive(true);
    }

    public void SairInter()
    {
        MenuPrincipalInicial.SetActive(true);
        Integrantes.SetActive(false);
    }
}
