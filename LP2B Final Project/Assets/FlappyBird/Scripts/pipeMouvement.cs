using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMouvement : MonoBehaviour
{
    public playerController pc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while(!pc.dead == false){
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x-0.35f, transform.position.y), 0.08f);
        }
    }
}
