using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvancaPtero : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject gameControler;
    [SerializeField] private float avancar;
    [SerializeField] private SpriteRenderer imagem;
    private Boolean liberado;
    private Vector3 mover;
    private void Start()
    {
        liberado = false;
        mover = transform.position;
        imagem.enabled = false;
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
        liberado = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {

            if (Carne.grande)
            {
                Carne.grande = false;
                Debug.Log("tome");
                Destroy(gameObject);
            }
            else
            {
                canvas.SetActive(true);
                gameControler.SetActive(true);
                Camera.main.GetComponent<AudioSource>().mute = true;
                Time.timeScale = 0;
            }
        }
    }
}
