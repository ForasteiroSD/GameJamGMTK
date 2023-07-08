using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPtero : MonoBehaviour
{
    [SerializeField] private Transform jogador;
    [SerializeField] private AvancaPtero avancar;
    [SerializeField] private SpriteRenderer imagem;
    [SerializeField] private float distancia;

    void Start()
    {
        imagem.enabled = false;
        avancar.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x - jogador.position.x < distancia)
        {
            imagem.enabled = true;
            avancar.enabled = true;
        }
    }
}
