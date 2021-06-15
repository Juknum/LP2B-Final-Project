using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;

public class playerController : MonoBehaviour {

	[SerializeField] TextMeshProUGUI scoreText;
	Rigidbody2D bird;
	public int score = 0;
	public bool dead = false;
	public GameObject gameOverPanel;
	public GameObject gameInfoPanel;
	AudioSource audio;

	private SpriteRenderer spriteRenderer;
	public Sprite first_Sprite;
	public Sprite second_Sprite;
	public Sprite dead_sprite;
	private int count = 0;

	// Start is called before the first frame update
	void Start() {
		bird = transform.GetComponent<Rigidbody2D>();
		audio = GetComponent<AudioSource>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

		// StartCoroutine(Coroutine());
	}

	// IEnumerator Coroutine() {
	// 	yield return new WaitForSeconds(2);
	// }

	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.UpArrow) && !dead) {
			bird.velocity = new Vector2(0, 8.5f);
			sprite_alternate();
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		this.dead = true;

		if (col.gameObject.CompareTag("pipe")) {
			spriteRenderer.sprite = dead_sprite;
			audio.Play();
			gameInfoPanel.SetActive(false);
			gameOverPanel.SetActive(true);

      Invoke("goToMain", 2);
		}
	}

	private void goToMain() {
    SceneManager.LoadScene("Main");
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "pointTrigger") {
			++score;
			scoreText.text = "Score : " + score.ToString();
		}
	}

	private void sprite_alternate() {
		if (count == 0) {
			spriteRenderer.sprite = second_Sprite; 
			count = 1;
		}
		else {
			spriteRenderer.sprite = first_Sprite;
			count = 0 ;
		}
	}
}
