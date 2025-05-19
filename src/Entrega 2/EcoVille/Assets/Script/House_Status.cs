using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_Status : MonoBehaviour
{
    public float energia = 0;
    public float agua = 0;
    public int membros = 0;
    public int tempo = 80;

    public List<Atributo> listaCasas = new List<Atributo>();

    void Start()
    {
        StartCoroutine(Temporizador());
    }

    IEnumerator Temporizador()
    {
        int segundos = 0;

        while (true)
        {
            if (segundos >= tempo)
            {
                GeraStatus();
                segundos = 0; // reinicia o tempo
            }

            segundos = segundos + 1;
            yield return new WaitForSeconds(1f);
        }
    }

    void GeraStatus()
    {
        int totalCasas = 10;

        for (int numeroDaCasa = 1; numeroDaCasa < totalCasas; numeroDaCasa = numeroDaCasa + 1)
        {
            float energiaGerada = Random.Range(30f, 120f);   // Antes era 120f a 250f
            float aguaPorPessoa = Random.Range(1000f, 2500f); // Antes era 2000f a 3500f
            float aguaGerada = membros * aguaPorPessoa;

            float fatorEnergia = energiaGerada / 100f;
            float ajusteEnergia = Mathf.Clamp(fatorEnergia, 0.5f, 2f);
            float consumoTotal = aguaGerada * ajusteEnergia;

            // Verifica se a casa já existe
            Atributo casaExistente = listaCasas.Find(c => c.numeroDaCasa == numeroDaCasa);

            if (casaExistente != null)
            {
                // Atualiza os valores da casa existente
                casaExistente.energia = energiaGerada;
                casaExistente.agua = aguaGerada;
                casaExistente.membros = Random.Range(1, 5);
                casaExistente.consumoTotal = consumoTotal;
            }
            else
            {
                // Adiciona uma nova casa
                listaCasas.Add(new Atributo(energiaGerada, aguaGerada, membros, consumoTotal, numeroDaCasa));
            }
        }
    }
}
