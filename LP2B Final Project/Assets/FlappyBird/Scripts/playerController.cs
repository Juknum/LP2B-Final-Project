using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    Rigidbody2D bird;
    public int score = 0;
    public bool dead = false;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        bird = transform.GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && !dead){
            bird.velocity = new Vector2(0, 8.5f);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        dead = true;
        if(col.gameObject.CompareTag("pipe")){
            audio.Play();
            SceneManager.LoadScene("FlappyBirdCrash");
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "pointTrigger"){
            ++score;
            scoreText.text = "Score : " + score.ToString();
        }
    }

}
