using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject gameControler;
    [SerializeField] public float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _tempoVariacaoVelocidade;
    [SerializeField] private float _quantidadeVariacaoVelocidade;
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _layerCollider;
    [SerializeField] private Animator animator;
    [SerializeField] private bool grande = false;
    private Rigidbody2D _rigidBody;
    public Vector2 movement;
    private float _deltaTime;     // Tempo para variar a velocidade do personagem
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _deltaTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //_rigidBody.velocity = new Vector2(_speed, _rigidBody.velocity.y);
        _deltaTime += Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, _range, _layerCollider);
        if (hit.collider)
        {
            // Para o player 
            animator.SetBool("bateParede", true);
            
            
        }
        else
        {
            animator.SetBool("bateParede", false);

            if (_speed < _maxSpeed)
            {
                if (_deltaTime > _tempoVariacaoVelocidade)
                {
                    _speed = _speed + (Time.deltaTime * _quantidadeVariacaoVelocidade);
                    _deltaTime = 0;
                }
            }
        }
        // Debug.Log(_speed);
        movement = new Vector2(_speed, _rigidBody.velocity.y);
        _rigidBody.velocity = movement;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * _range);
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Carne")
        {
            grande = true;
            animator.SetBool("estaGrande", true);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Pterodatilo") {
            if (grande == true)
            {
                grande = false;
                animator.SetBool("estaGrande", false);
                Destroy(collision.gameObject);
            }
            else {
                canvas.SetActive(true);
                gameControler.SetActive(true);
                Camera.main.GetComponent<AudioSource>().mute = true;
                Time.timeScale = 0;
            }

        }
    }

}
