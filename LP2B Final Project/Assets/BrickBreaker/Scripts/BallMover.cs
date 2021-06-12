using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public GameManager gameManager;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!inPlay) transform.position = paddle.position;

        if(gameManager.gameOver) return;

        if(Input.GetButtonDown("Jump") && !inPlay){ 
            inPlay = true; 
            rb.AddForce(Vector2.down * speed);
        }

    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("bottom")){
            Debug.Log("Ball lost");
            rb.velocity = Vector2.zero;
            inPlay = false;
            gameManager.scoreUpdate(-500);
            if(gameManager.scoreValue < 0){
                gameManager.scoreValue = 0;
                gameManager.scoreUpdate(0);
            }
            gameManager.GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.transform.CompareTag("brick")){

            gameManager.scoreUpdate(col.gameObject.GetComponent<Brick>().points);
            gameManager.UpdateBricksLeft();

            Destroy(col.gameObject);
            audio.Play();
        }

    }
}
