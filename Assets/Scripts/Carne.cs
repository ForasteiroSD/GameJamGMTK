using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carne : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public static bool grande = false;

    void Update()
    {
        if (grande == false)
        {
        animator.SetBool("estaGrande", false);
        }
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Carne")
        {
            grande = true;
            animator.SetBool("estaGrande", true);
            Debug.Log("carne in");
        }
    }
}
