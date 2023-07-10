using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvancaPtero : MonoBehaviour {
    [SerializeField] private float avancar;
    [SerializeField] private SpriteRenderer imagem;
    [SerializeField] private BoxCollider2D boxCol;
    private Boolean liberado;
    private Vector3 mover;
    private void Start()
    {
        liberado = false;
        mover = transform.position;
        imagem.enabled = false;
        boxCol.enabled = false;
    }
    private void FixedUpdate()
    {
        if (liberado)
        {
            mover.x += -avancar;
            transform.position = mover;
        }
    }
    public void liberar()
    {
        imagem.enabled = true;
        boxCol.enabled = true;
        liberado = true;
    }
}
