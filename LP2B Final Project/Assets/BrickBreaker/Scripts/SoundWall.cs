using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWall : MonoBehaviour
{
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.transform.CompareTag("ball")){
            audio.Play();
        }
    }
}
