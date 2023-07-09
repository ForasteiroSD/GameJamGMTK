using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject gameControler;

    [Header("Ground Detection")]
    private bool groundDetected;
    [SerializeField] Transform groundPos;
    [SerializeField] private float groundCheckSize;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Wall Detection")]
    private bool wallDetected;
    [SerializeField] Transform wallPos;
    [SerializeField] private float wallCheckSize;
    [SerializeField] private LayerMask whatIsWall;

    private int x = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    void Update()
    {
        groundDetected = Physics2D.Raycast(groundPos.position, -transform.up, groundCheckSize, whatIsGround);
        wallDetected = Physics2D.Raycast(wallPos.position, transform.right, wallCheckSize, whatIsWall);

        //Deteccion de Suelo
        if (!groundDetected)
        {
            speed = -speed;
            x = -x;
        }

        //Deteccion de Pared
        if (wallDetected)
        {
            speed = -speed;
            x = -x;
        }
        transform.localScale = new Vector3(x, 3, 1);
        rb.velocity = transform.right * speed;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundPos.position, new Vector2(groundPos.position.x, groundPos.position.y - groundCheckSize));
        Gizmos.DrawLine(wallPos.position, new Vector2(wallPos.position.x + wallCheckSize, wallPos.position.y));
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

