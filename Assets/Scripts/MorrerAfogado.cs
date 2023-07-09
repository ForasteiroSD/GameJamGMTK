using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MorrerAfogado : MonoBehaviour
{
    // Colocar nas aguas e em lugares que s�o poss�veis cair do mapa, colocar um collider com Trigger ligado.
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Death") {
            SceneManager.LoadScene("GameOver");
        }
    }
}
