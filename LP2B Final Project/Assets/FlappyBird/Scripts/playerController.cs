using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;

public class playerController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    Rigidbody2D bird;
    public int score = 0;
    public bool dead = false;

    AudioSource audio;

    private SpriteRenderer spriteRenderer;
    private int count = 0;
    public Sprite first_Sprite;
    public Sprite second_Sprite;
    public Sprite dead_sprite;

    // Start is called before the first frame update
    void Start()
    {
        bird = transform.GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && !dead){
            bird.velocity = new Vector2(0, 8.5f);
            sprite_alternate();
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        dead = true;
        if(col.gameObject.CompareTag("pipe")){
            spriteRenderer.sprite = dead_sprite;
            audio.Play();
            Thread.Sleep(1000);
            SceneManager.LoadScene("FlappyBirdCrash");
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "pointTrigger"){
            ++score;
            scoreText.text = "Score : " + score.ToString();
        }
    }

    private void sprite_alternate(){
        if(!dead){
            if(count == 0){
                spriteRenderer.sprite = second_Sprite; 
                count = 1;
            }else{
                spriteRenderer.sprite = first_Sprite;
                count = 0 ;
            }
        }
    }
}
