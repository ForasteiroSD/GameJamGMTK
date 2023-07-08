using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanciaPercorrida : MonoBehaviour {
    private Vector3 posicaoInicial;
    private Vector3 posicaoPlayer;
    public float distancia = 0;

    void Start() {
        posicaoInicial = transform.position;
    }

    // Update is called once per frame
    void Update() {
        posicaoPlayer = transform.position;
        distancia = posicaoPlayer.x - posicaoInicial.x; 
    }
}