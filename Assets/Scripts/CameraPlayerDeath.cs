using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraPlayerDeath : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!I_Can_See(_player))
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    private bool I_Can_See(GameObject Object)
    {

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(planes, Object.GetComponent<Collider2D>().bounds))
            return true;
        else
            return false;
    }
}
