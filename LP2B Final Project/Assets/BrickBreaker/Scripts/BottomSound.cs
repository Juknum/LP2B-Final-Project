using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomSound : MonoBehaviour
{
   AudioSource audio;
   void Start()
    {
        audio = GetComponent<AudioSource>();
    }
   void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("ball")){
            audio.Play();
        }
    }
}
