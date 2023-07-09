using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostraScoreGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    //[SerializeField] private GameObject _scoreHandler;
    private float _actualScore;
    // Start is called before the first frame update
    void Start()
    {
        _actualScore = GetComponent<DistanciaPercorrida>().getScore();
        _score.text = _actualScore.ToString();
    }

    
}
