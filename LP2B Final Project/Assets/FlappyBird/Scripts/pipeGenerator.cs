using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeGenerator : MonoBehaviour {

  [SerializeField] GameObject pipes;
	[SerializeField] GameObject pipes1;
	[SerializeField] GameObject pipes2;
	[SerializeField] GameObject pipes3;
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
		if(timer >= 100){
      timer = Random.Range(0, 80);

			int pipeType = Random.Range(0, 3);
			GameObject pipe;
			switch (pipeType) {
				case 0:
					pipe = Instantiate(pipes, new Vector2(pipes.transform.position.x, pipes.transform.position.y + Random.Range(-2, 2)), pipes.transform.rotation);
					break;
				case 1:
					pipe = Instantiate(pipes1, new Vector2(pipes1.transform.position.x, pipes.transform.position.y + Random.Range(-2, 2)), pipes.transform.rotation);
					break;
				case 2:
					pipe = Instantiate(pipes2, new Vector2(pipes2.transform.position.x, pipes.transform.position.y + Random.Range(-2, 2)), pipes.transform.rotation);
					break;
				case 3:
					pipe = Instantiate(pipes3, new Vector2(pipes3.transform.position.x, pipes.transform.position.y + Random.Range(-2, 2)), pipes.transform.rotation);
					break;
				default:
          pipe = Instantiate(pipes, new Vector2(pipes.transform.position.x, pipes.transform.position.y + Random.Range(-2, 2)), pipes.transform.rotation);
					break;
			}
			
			Destroy(pipe, 7);
		}
	}
}
