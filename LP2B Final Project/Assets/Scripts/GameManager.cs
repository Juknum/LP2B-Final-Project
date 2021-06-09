using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
  public int score;
  public Text scoreText;
  public int numberOfBricks;
  public bool gameOver;
  public GameObject gameOverPanel;
  public Transform[] levels;
  public int currentLevelIndex = 0;
  public GameObject ball;

  // Start is called before the first frame update
  void Start() {
    scoreText.text = "Score: " + score;
    numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
  }

  // Update is called once per frame
  void Update() {
    // if the game is over, press enter to "restart" the game
    if (Input.GetKey(KeyCode.Return) && gameOver) {
      gameOver = false;
      gameOverPanel.SetActive(false);
    }

    // Load next level when there is no bricks anymore
    if (numberOfBricks == 0) LoadNextLevel();

  }

  void LoadNextLevel() {
    // Custom Vector because I messed up when saving prefabs
    Instantiate(levels[currentLevelIndex % levels.Length], Vector2.zero, Quaternion.identity);
    currentLevelIndex++;

    numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    ball.GetComponent<Ball>().SetInPlay(false);
  }

  // public function to update the score from anywhere it's called
  public void UpdateScore(int changeInScore) {
    score = score + changeInScore > 0 ? score + changeInScore : 0; // avoid -30129313 of score
    scoreText.text = "Score: " + score;

    if (score == 0) GameOver();
  }

  public int GetScore() {
    return score;
  }

  // Use to be the "ReportBrickDeath()"
  // decrease the number of bricks by the given value (can't go below 0)
  public void UpdateBricksCount(int changeInBricks) {
    numberOfBricks = numberOfBricks + changeInBricks > 0 ? numberOfBricks + changeInBricks : 0;
  }

  void GameOver() {
    gameOver = true;
    gameOverPanel.SetActive(true);
  }
}
