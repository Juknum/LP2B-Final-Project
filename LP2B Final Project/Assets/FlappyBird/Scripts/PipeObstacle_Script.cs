using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeObstacle_Script : MonoBehaviour
{
    const float pipeSpeed = 4f;
    const float despawn_posX = -12f;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gameManager.gameOver2 == false){
        transform.Translate( -pipeSpeed * Time.deltaTime , 0, 0 );
        }
        if (transform.position.x < despawn_posX)
        {
            Destroy(gameObject);
        }
    }
}
