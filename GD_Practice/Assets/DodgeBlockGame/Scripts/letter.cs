using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class letter : MonoBehaviour {

	private float gravityScaler;
	// Use this for initialization
	void Start () {
		if(blockSpawner.currentLetterNumber < blockSpawner.jumbledWord.Length)
		GetComponent<TextMesh> ().text = blockSpawner.jumbledWord [blockSpawner.currentLetterNumber-1].ToString ();
		gravityScaler = Random.Range (2f,10f);
		GetComponent<Rigidbody2D> ().gravityScale += Time.timeSinceLevelLoad /5/gravityScaler;
	}
	void Update () {
		if (transform.position.y <= -2f) {
			Destroy (gameObject);
		}
	}
}