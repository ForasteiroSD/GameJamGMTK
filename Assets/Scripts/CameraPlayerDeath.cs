using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraPlayerDeath : MonoBehaviour {
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject gameControler;
    [SerializeField] GameObject _player;
    [SerializeField] Camera cam;
    private Boolean ICanSee = true;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(!ICanSee) {
            canvas.SetActive(true);
            gameControler.SetActive(true);
            Camera.main.GetComponent<AudioSource>().mute = true;
            Time.timeScale = 0;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
           ICanSee = false;
        }
    }


    // private bool I_Can_See(GameObject Object) {
    //     Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
    //     if (GeometryUtility.TestPlanesAABB(planes, Object.GetComponent<Collider2D>().bounds))
    //         return true;
    //     else
    //         return false;
    // }
}
