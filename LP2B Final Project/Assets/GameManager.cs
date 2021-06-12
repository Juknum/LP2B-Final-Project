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
    public Scene activeScene;

    public GameObject Pipe_prefab;
    public GameObject Bird;
    private float max_height = 2;
    private float min_height = -2;
    private int score2 = 0;
    public TextMeshPro displayed_text;
    public bool gameOver2;
    public GameObject gameOverPanel2;


    // Start is called before the first frame update
    void Start()
    {   
        activeScene = SceneManager.GetActiveScene();
        if(activeScene.name == "BrickBreaker"){
        score.text = "Score : " + scoreValue;

        bricksLeft = GameObject.FindGameObjectsWithTag("brick").Length;
        }
        else if(activeScene.name == FurapiBird){
            InvokeRepeating("Pipe_generate", 1.0f, 2.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(activeScene.name == "FurapiBird"){
            displayed_text.SetText(score.ToString());
        }
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

        activeScene = SceneManager.GetActiveScene();
        if(activeScene.name == "BrickBreaker"){
            gameOver = true;
        gameOverPanel.SetActive(true);
        }
        else if(activeScene.name == FurapiBird){
        /*Rigidbody2D refBird = GameObject.Find("Bird_01").GetComponent<Rigidbody2D>();
        refBird.velocity = new Vector2(0, 0);
        refBird.gravityScale = 0;*/
        Bird.GetComponent<Bird_Scr>().bird_gameover();
        Debug.Log("gameover");
        gameOver2 = true;
        gameOverPanel2.SetActive(true);
        }
    }

    public void PlayAgain(){

        activeScene = SceneManager.GetActiveScene();
        if(activeScene.name == "BrickBreaker"){
            SceneManager.LoadScene("BrickBreaker");
        }
        else if(activeScene.name == FurapiBird){
            SceneManager.LoadScene("FurapiBird");
        }
    }

    public void LeaveGame(){
        Application.Quit();
        Debug.Log("Game quit !");
    }

     private void Pipe_generate(){
        if(gameOver2 == false){
        GameObject newPipe = Instantiate(Pipe_prefab);
        float random = Random.Range(min_height, max_height);
        newPipe.transform.position = new Vector3 (14f, random, 0f);
        newPipe.GetComponent<PipeObstacle_Script>().gameManager = this;
        }
    }

    public void score_increment(){
        score2 += 1;
        Debug.Log(score2);
    }
}
