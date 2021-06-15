using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
  public float speed;
  public float rightScreenEdge;
  public float leftScreenEdge;
  public GameManager gm;

  void Start() {}

  // Update is called once per frame
  void Update() {
    if (gm.gameOver) return;

    // Velocity management
    float horizontal = Input.GetAxis("Horizontal");
    transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);

    // Check if the paddle is outside the boundaries
    if (transform.position.x < leftScreenEdge) {
      transform.position = new Vector2(leftScreenEdge, transform.position.y);
    }
    if (transform.position.x > rightScreenEdge) {
      transform.position = new Vector2(rightScreenEdge, transform.position.y);
    }

  }

  
}