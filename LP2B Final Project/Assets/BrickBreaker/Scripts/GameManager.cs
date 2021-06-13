using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int scoreValue;
    public Text score;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int bricksLeft;


    // Start is called before the first frame update
    void Start()
    {   
        score.text = "Score : " + scoreValue;

        bricksLeft = GameObject.FindGameObjectsWithTag("brick").Length;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void scoreUpdate(int points){
        scoreValue += points;

        score.text = "Score : " + scoreValue;
    }

    public void UpdateBricksLeft(){
        bricksLeft--;
        if(bricksLeft <= 0){
            GameOver();
        }
    }

    public void GameOver(){
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain(){
            SceneManager.LoadScene("BrickBreaker");
    }

    public void LeaveGame(){
        Application.Quit();
        Debug.Log("Game quit !");
    }

}
