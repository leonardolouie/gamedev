using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {
	public Text waveScore,score,highScore,coins;
	private float speed = 10f;
	public float mapWidth = 3.2f;
	private Rigidbody2D rb;
	private float a,b;
	public static int x,lives;
	int consecutiveScore;
	public static int collectedLetters = 0;
	shopManager shop;


	void Update(){
		waveScore.text = x.ToString();
		coins.text = PlayerPrefs.GetInt ("coins", 0).ToString();
	}
	void Start(){
		
		Application.targetFrameRate = 60;
		shop = FindObjectOfType<shopManager> ();
		if (shopManager.skinSelected != null) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = shopManager.skinSelected;
		}

		x = 0;
		lives = 3;
		rb = GetComponent<Rigidbody2D> ();
		highScore.text = PlayerPrefs.GetInt ("highScore",0).ToString();
		coins.text = PlayerPrefs.GetInt ("coins", 0).ToString ();


	}



		
	void FixedUpdate(){
		//PLAYER MOVEMENT


		if (Input.touchCount > 0) {
			a = Input.GetTouch (0).deltaPosition.x;
			//a = Mathf.Clamp (a, -1f, 1f);
		} else
			a = 0f;

		float x = /*Input.GetAxis ("Horizontal")*/a * Time.fixedDeltaTime / speed;
		Vector2 newPosition = rb.position + Vector2.right * x;
		newPosition.x = Mathf.Clamp (newPosition.x, -mapWidth, mapWidth);
		rb.MovePosition (newPosition);
	}



	//COLLIDE WITH SCORES,COINS,LETTERS
	void OnTriggerEnter2D(Collider2D e){
			if(e.tag == "coins") {
				PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins",0)+10);
				Destroy (e.gameObject);
				FindObjectOfType<Canvas>().GetComponent<Animator>().SetTrigger("text");
			}
			
			else if(e.tag == "score"){
				Destroy(e.gameObject);
				x++;
				consecutiveScore ++;

			}

			else if(e.tag == "letter")
			{
				Destroy(e.gameObject);
				collectedLetters++;
				isCollidedWithLetters();
			}


			if(consecutiveScore == 5)
			{
				if(lives < 3){
					FindObjectOfType<Canvas> ().GetComponent<Animator> ().SetTrigger ("heart");
					FindObjectOfType<GameManager>().addLife(lives);
					lives++;
					consecutiveScore = 0;
				}
			}

	}

	public void isCollidedWithLetters(){
		
	}




	//COLLIDES WITH OBSTACLE
	void OnCollisionEnter2D(Collision2D e){
		if (e.collider.tag == "block") {
			consecutiveScore = -1;
			lives--;
			FindObjectOfType<GameManager>().minusLife(lives);
			if(lives > 0){
					e.gameObject.GetComponent<BoxCollider2D>().enabled = false;
				}
			else{
					FindObjectOfType<GameManager> ().endGame ();
					gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					gameObject.GetComponentInChildren<ParticleSystem> ().Play ();
					gameObject.GetComponent<SpriteRenderer> ().enabled = false;
					score.text = x.ToString();
					if (x > PlayerPrefs.GetInt ("highScore", 0)) {
						FindObjectOfType<Canvas> ().GetComponent<Animator> ().SetTrigger ("hs");
						PlayerPrefs.SetInt ("highScore", x);
						highScore.text = x.ToString ();
						}
				}
			}
	}



}
 