using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
public GameObject Pipe_prefab;
public GameObject Bird;
private float max_height = 2;
private float min_height = -2;
private int score = 0;
public TextMeshPro displayed_text;
public bool gameOver;
public GameObject gameOverPanel;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Pipe_generate", 1.0f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        displayed_text.SetText(score.ToString());
    }

    private void Pipe_generate(){
        if(gameOver == false){
        GameObject newPipe = Instantiate(Pipe_prefab);
        float random = Random.Range(min_height, max_height);
        newPipe.transform.position = new Vector3 (14f, random, 0f);
        newPipe.GetComponent<PipeObstacle_Script>().gameManager = this;
        }
    }

    public void GameOver(){
        /*Rigidbody2D refBird = GameObject.Find("Bird_01").GetComponent<Rigidbody2D>();
        refBird.velocity = new Vector2(0, 0);
        refBird.gravityScale = 0;*/
        Bird.GetComponent<Bird_Scr>().bird_gameover();
        Debug.Log("gameover");
        gameOver = true;
        gameOverPanel.SetActive(true);

        
    }

    public void score_increment(){
        score += 1;
        Debug.Log(score);
    }

    public void PlayAgain(){
        SceneManager.LoadScene("SampleScene");
    }

}
