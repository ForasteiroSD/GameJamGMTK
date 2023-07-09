using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanciaPercorrida : MonoBehaviour
{
    void awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private Transform posicaoInicial;
    [SerializeField] private Transform posicaoPlayer;
    public float distancia = 0;
    void Start()
    {
        posicaoInicial = posicaoPlayer;
    }
    void Update()
    {
        distancia = posicaoPlayer.position.x - posicaoInicial.position.x;
    }

    public float getScore()
    {
        return distancia;
    }
}
