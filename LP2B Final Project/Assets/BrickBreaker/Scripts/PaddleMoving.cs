using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMoving : MonoBehaviour
{
    public GameManager gameManager;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameOver) return;

        if(Input.GetKey(KeyCode.RightArrow)){
            if(transform.position.x > 5){

            }else{
                transform.Translate(10f * Time.deltaTime, 0, 0);
            }
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
        if(transform.position.x < -4.85){

            }else{
                transform.Translate(-10f * Time.deltaTime, 0, 0);
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D col){
        if(col.transform.CompareTag("ball")){
            audio.Play();
        }
    }

}
