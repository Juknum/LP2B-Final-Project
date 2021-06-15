using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endGameScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public playerController playerController; 
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : " + playerController.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
