using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour {
  public Rigidbody2D rb;
  public bool inPlay;
  public Transform paddle;
  public float speed;
  public GameManager gm;
  AudioSource audio;

  public AudioClip bouncePad;
  public AudioClip bounceWall;
  public AudioClip gameOver;
  public AudioClip gameStart;
  public AudioClip pointWin;
  public AudioClip pointLoss;
  public float audioVolume;

  // Start is called before the first frame update
  void Start() {
    rb = GetComponent<Rigidbody2D>();
    audio = GetComponent<AudioSource>();
  }
  
  void Update() {
    if (gm.gameOver) return;

    // if the ball isn't moving (not played), then ball follow the paddle
    if (!inPlay) {
      transform.position = paddle.position;
      
    }

    // space bar trigger to starts to play
    if (Input.GetButtonDown("Jump") && !inPlay) {
      SetInPlay(true);
      rb.AddForce(Vector2.up * speed);
      if (gm.GetScore() == 0) audio.PlayOneShot(gameStart, audioVolume);
    }
  }

  public void SetInPlay(bool that) {
    // if the ball keep it's momentum
    if (!that) rb.velocity = Vector2.zero;

    this.inPlay = that;
  }

  // If the ball hit a trigger collider (the ground collider)
  void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Ground")) {

      // set the ball back on top of the paddle
      SetInPlay(false);

      gm.UpdateScore(-500);
      audio.PlayOneShot(pointLoss, audioVolume);
      if (gm.GetScore() == 0) audio.PlayOneShot(gameOver, audioVolume);
    }
  }

  void OnCollisionEnter2D(Collision2D other) {
    if (other.transform.CompareTag("Brick")) {
      gm.UpdateScore(50);
      gm.UpdateBricksCount(-1);
      Destroy(other.gameObject);

      audio.PlayOneShot(bouncePad, audioVolume);
      audio.PlayOneShot(pointWin, audioVolume);
    }
    if (other.transform.CompareTag("Paddle")) audio.PlayOneShot(bouncePad, audioVolume);
    if (other.transform.CompareTag("Wall")) audio.PlayOneShot(bounceWall, audioVolume);
  }
}
