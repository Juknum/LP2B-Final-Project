using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMouvement : MonoBehaviour {

  private GameObject bird;
	private bool state;

	// Start is called before the first frame update
	void Start() {
		bird = GameObject.Find("Bird");
	}

	// Update is called once per frame
	void Update() {
    state = bird.GetComponent<playerController>().dead;
		if (state == true) return;
		
		transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x-0.35f, transform.position.y), 0.08f);
	}
}
