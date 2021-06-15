using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeGenerator : MonoBehaviour {

	[SerializeField] GameObject pipes;
	public GameObject bird;
	int timer = 500;
	private bool state;

  // Start is called before the first frame update
  void Start() {}

	// Update is called once per frame
	void Update() {
    state = bird.GetComponent<playerController>().dead;
    if (state == true) return;

		timer++;
		if(timer >= 500){
			timer = 0;
			GameObject pipe = Instantiate(pipes, new Vector2(pipes.transform.position.x, pipes.transform.position.y + Random.Range(-2, 2)), pipes.transform.rotation);
			Destroy(pipe, 7);
		}
	}
}
