using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Scr : MonoBehaviour
{

    public Sprite first_Sprite;
    public Sprite second_Sprite;
    public Sprite dead_Sprite;
    private SpriteRenderer spriteRenderer;
    private int count = 0;
    public GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        InvokeRepeating("sprite_alternate", 0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
            if( transform.position.y <=5 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))){
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, (float)9);  
            }
        if(transform.position.y < -5 ){
            gameManager.GameOver();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D col){
            if(col.collider.name == "Pipe Top" || col.collider.name == "Pipe Bottom"){
                gameManager.GameOver();
            }
        }

    private void OnTriggerEnter2D(Collider2D Collision){
        gameManager.score_increment();
    }
    private void sprite_alternate(){
        if(gameManager.gameOver == false){
            if(count == 0){
            spriteRenderer.sprite = second_Sprite; 
            count = 1;
            }else{
                spriteRenderer.sprite = first_Sprite;
                count =0 ;
            }
        }
    }

    public void bird_gameover(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().gravityScale = 0;
        spriteRenderer.sprite = dead_Sprite;
    }

}
