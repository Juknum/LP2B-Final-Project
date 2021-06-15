using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMouvement : MonoBehaviour {

	private float speedPipe = 8.5f;
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

		transform.Translate(Vector2.left * Time.deltaTime * speedPipe);
	}
}
