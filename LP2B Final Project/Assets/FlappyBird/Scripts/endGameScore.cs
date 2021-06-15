using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endGameScore : MonoBehaviour
{

    public playerController playerController;
    TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : " + playerController.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
